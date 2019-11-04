CREATE DATABASE HsrtechDB

GO

USE HsrtechDB

GO

CREATE TABLE HistoricalTransaction(
    HistoricalId int primary key IDENTITY(1,1),
    NumberAccount int  NOT NULL,
    Date DATETIME NOT NULL,
    Value decimal NOT NULL,
    FlagTransaction bit NOT NULL
);

GO

CREATE TABLE Client(
    ClientId int primary key,
    Name varchar(250) NOT NULL,
    Login varchar(250) NOT NULL,
    Password varchar(250) NOT NULL,
);

GO

CREATE TABLE BankAccount(
    NumberAccount int primary KEY IDENTITY(1,1),
    OpenDate DATETIME NOT NULL,
    Balance decimal NOT NULL,
    ClientId int NOT NULL,
    Limit int NOT NULL,

    CONSTRAINT Fk_Client FOREIGN KEY (ClientId) REFERENCES Client (ClientId)
);
