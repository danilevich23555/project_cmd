import asyncio
import datetime
from typing import Type
from types import TracebackType
import asyncpg

from settings.settings import settings


class Postgres:

    def __init__(self):
        self.dsn = settings.POSTGRES_DSN




    async def get_pool_by_dsn(self):
        return await asyncpg.create_pool(self.dsn)



    async def insert_users(self, pool: asyncpg.Pool, user_list):
        async with pool.acquire() as conn:
            print('Данные не доступны')
            query = await conn.fetchrow(
                "insert into users (first_name, last_name, is_tutor, created) values ($1, $2, $3, $4) returning *",
                user_list[0], user_list[1], True, datetime.datetime.now()
            )
        return print(query)


# async def start():
#     postgres = Postgres()
#     pool = await asyncpg.create_pool(settings.POSTGRES_DSN)
#     mu_tuple = ['Danila', 'Dolgov', True, datetime.datetime.now()]
#     await postgres.insert_users(pool=pool, user_list=mu_tuple)
#
# asyncio.run(start())





