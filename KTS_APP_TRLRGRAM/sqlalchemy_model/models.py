from sqlalchemy import (
    Column,
    DateTime,
    ForeignKey,
    Integer,
    String,
    create_engine,
    func,
)
from sqlalchemy.ext.declarative import declarative_base




Base = declarative_base()



class User(Base):
    __tablename__ = "users"
    id = Column(Integer, primary_key=True)
    user_name = Column(String(100), nullable=False, unique=True)
    first_name = Column(String(200), nullable=False)
    registration_time = Column(DateTime, server_default=func.now())





