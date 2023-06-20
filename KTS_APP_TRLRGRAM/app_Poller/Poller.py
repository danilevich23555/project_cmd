import asyncio
import os
import asyncpg

from telegramm.tg import TgClientWithFile
from telegramm.dcs import Message
from sqlite.sqllite_db import sqllite_DB
from app_rabbitMQ.rabbit_client import RabbitClient
from settings.settings import settings
from postgress_db.Postgress import Postgres


class Poller:

    def __init__(self, token):
        self.tg_client = TgClientWithFile(token)
        self.is_running = False
        self.sql = sqllite_DB(os.path.join(os.getcwd().replace('/app_Poller', ''), 'update_chat_id.db'))
        self._task = asyncio.Task
        self.postgres = Postgres()


    async def _worker(self, pool):
        while self.is_running:
            res = await self.tg_client.get_updates()
            for x in res['result']:
                r = Message.Schema().load(x['message'])
                response_id = await self.sql.select_id(r.chat.id)
                if response_id == None:
                    response_id = (0, 0)
                if x['update_id'] > int(response_id[0]):
                    my_tuple = [r.from_.first_name, r.from_.username]
                    await self.postgres.insert_users(pool=pool, user_list=my_tuple)
                    await self.sql.insert_records((x['update_id'], r.chat.id))
                    async with RabbitClient() as rabbit:
                        await rabbit.put(message_data=f"{x['message']}", queue_name='hello_1')

    async def start(self):
        self.is_running = True
        pool = await asyncpg.create_pool(settings.POSTGRES_DSN)
        self._task = await asyncio.create_task(self._worker(pool))

poller = Poller(settings.TELEGRAM_TOKEN)

async def start():
    await poller.start()


if __name__ == '__main__':
    loop = asyncio.get_event_loop()
    loop.create_task(start())
    loop.run_forever()





