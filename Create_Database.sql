﻿DROP TABLE History;
DROP TABLE Solutions;
DROP TABLE Users;
DROP TABLE Levels;


CREATE TABLE Users(
UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR (20) NOT NULL CHECK (LEN(Username) > 4),
Password VARCHAR (30) NOT NULL CHECK (LEN(Password) > 5),
Score INT NOT NULL DEFAULT 0
);

CREATE TABLE History(
HistoryID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserID INT NOT NULL CHECK (UserID > 0),
LevelID INT NOT NULL CHECK (LevelID > 0),
Time TIME NOT NULL,
Score INT NOT NULL
);

CREATE TABLE Levels(
LevelID  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR (30) NOT NULL, 
Size INT NOT NULL  CHECK (Size >= 1010 AND Size <= 8989),  --first 2 digits are horizontal size, next 2 are vertical
Letters VARCHAR (MAX) NOT NULL    --(LEN(Letters) = (Size%100) * (Size-(Size%100)/100))
);

CREATE TABLE Solutions(
LevelID INT NOT NULL,
Word VARCHAR (20) NOT NULL
PRIMARY KEY (LevelID, Word)
);

ALTER TABLE History
ADD CONSTRAINT FK_History_Users
FOREIGN KEY (UserID) REFERENCES Users(UserID);

ALTER TABLE History
ADD CONSTRAINT FK_History_Levels
FOREIGN KEY (LevelID) REFERENCES Levels(LevelID);

ALTER TABLE Solutions
ADD CONSTRAINT FK_Solutions_Levels
FOREIGN KEY (LevelID) REFERENCES Levels(LevelID);

