CREATE TABLE ApplicationTypes (
    ApplicationTypeID    INT           IDENTITY(1,1) NOT NULL,
    ApplicationTypeTitle NVARCHAR(150) NOT NULL,
    ApplicationFees      SMALLMONEY    NOT NULL,
    CONSTRAINT PK_ApplicationTypes PRIMARY KEY (ApplicationTypeID)
);
GO

-- ApplicationStatus: 1=New  2=Cancelled  3=Completed
CREATE TABLE Applications (
    ApplicationID     INT        IDENTITY(1,1) NOT NULL,
    ApplicantPersonID INT        NOT NULL,
    ApplicationDate   DATETIME   NOT NULL CONSTRAINT DF_App_Date       DEFAULT (GETDATE()),
    ApplicationTypeID INT        NOT NULL,
    ApplicationStatus TINYINT    NOT NULL CONSTRAINT DF_App_Status     DEFAULT (1),
    LastStatusDate    DATETIME   NOT NULL CONSTRAINT DF_App_LastStatus  DEFAULT (GETDATE()),
    PaidFees          SMALLMONEY NOT NULL,
    CreatedByUserID   INT        NOT NULL,
    CONSTRAINT PK_Applications PRIMARY KEY (ApplicationID),
    CONSTRAINT FK_App_Person FOREIGN KEY (ApplicantPersonID) REFERENCES People           (PersonID),
    CONSTRAINT FK_App_Type   FOREIGN KEY (ApplicationTypeID) REFERENCES ApplicationTypes (ApplicationTypeID),
    CONSTRAINT FK_App_User   FOREIGN KEY (CreatedByUserID)   REFERENCES Users            (UserID),
    CONSTRAINT CK_App_Status CHECK (ApplicationStatus IN (1,2,3))
);
GO

INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees) VALUES
(N'New Local Driving License Service',         15.00),
(N'Renew Driving License Service',              5.00),
(N'Replacement for a Lost Driving License',    10.00),
(N'Replacement for a Damaged Driving License',  5.00),
(N'Release Detained Driving License',          15.00),
(N'New International License',                 50.00),
(N'Retake Test',                                5.00);
GO



INSERT INTO Applications
    (ApplicantPersonID, ApplicationDate,
     ApplicationTypeID, ApplicationStatus, LastStatusDate,
     PaidFees, CreatedByUserID)
VALUES
(2,  '2020-03-01 09:00:00', 1, 3, '2020-03-15 10:30:00', 15.00, 1),
(3,  '2019-05-10 08:30:00', 1, 3, '2019-06-10 11:00:00', 15.00, 1),
(3,  '2021-01-05 09:00:00', 1, 3, '2021-01-20 10:00:00', 15.00, 1),
(2,  '2024-04-01 10:00:00', 2, 3, '2024-04-01 11:00:00',  5.00, 1),
(2,  '2024-04-01 11:30:00', 6, 3, '2024-04-01 12:00:00', 50.00, 1),
(3,  '2023-09-05 09:00:00', 3, 3, '2023-09-05 09:45:00', 10.00, 1),
(3,  '2022-11-20 14:00:00', 5, 3, '2022-11-20 14:30:00', 15.00, 1),
(4,  '2024-06-01 09:00:00', 1, 1, '2024-06-01 09:00:00', 15.00, 2),
(4,  '2024-07-10 10:00:00', 7, 1, '2024-07-10 10:00:00',  5.00, 2),
(5,  '2023-02-10 08:00:00', 1, 3, '2023-03-10 11:00:00', 15.00, 3);
