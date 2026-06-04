CREATE TABLE Users (
    UserID   INT          IDENTITY(1,1) NOT NULL,
    PersonID INT          NOT NULL,
    UserName NVARCHAR(20) NOT NULL,
    Password NVARCHAR(20) NOT NULL,
    IsActive BIT          NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
    CONSTRAINT PK_Users       PRIMARY KEY (UserID),
    CONSTRAINT UQ_Users_Name  UNIQUE      (UserName),
    CONSTRAINT FK_Users_Person
        FOREIGN KEY (PersonID) REFERENCES People (PersonID)
);

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_PersonID UNIQUE (PersonID);

INSERT INTO Users (PersonID, UserName,            Password,     IsActive) VALUES
(1,  N'Admin',            N'Admin@1234',  1),
(4,  N'omar.rashid',      N'Pass@1234',   1),
(5,  N'nour.masri',       N'Pass@1234',   1),
(6,  N'tariq.barakat',    N'Pass@1234',   1),
(7,  N'fatima.elsayed',   N'Pass@1234',   1),
(8,  N'a.ghamdi',         N'Pass@1234',   1),
(9,  N'emily.thompson',   N'Pass@1234',   0),  -- inactive
(10, N'michael.anderson', N'Pass@1234',   0),  -- inactive
(11, N'hassan.zubaidi',   N'Pass@1234',   1),
(12, N'layla.khoury',     N'Pass@1234',   1),
(13, N'rami.natour',      N'Pass@1234',   1);