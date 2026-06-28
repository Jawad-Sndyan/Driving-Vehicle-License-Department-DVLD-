
CREATE TABLE Countries (
    CountryID   INT          IDENTITY(1,1) NOT NULL,
    CountryName NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Countries PRIMARY KEY (CountryID)
);
GO

INSERT INTO Countries (CountryName) VALUES
(N'Afghanistan'),(N'Albania'),(N'Algeria'),(N'Andorra'),(N'Angola'),
(N'Antigua and Barbuda'),(N'Argentina'),(N'Armenia'),(N'Australia'),(N'Austria'),
(N'Azerbaijan'),(N'Bahamas'),(N'Bahrain'),(N'Bangladesh'),(N'Barbados'),
(N'Belarus'),(N'Belgium'),(N'Belize'),(N'Benin'),(N'Bhutan'),
(N'Bolivia'),(N'Bosnia and Herzegovina'),(N'Botswana'),(N'Brazil'),(N'Brunei'),
(N'Bulgaria'),(N'Burkina Faso'),(N'Burundi'),(N'Cabo Verde'),(N'Cambodia'),
(N'Cameroon'),(N'Canada'),(N'Central African Republic'),(N'Chad'),(N'Chile'),
(N'China'),(N'Colombia'),(N'Comoros'),(N'Congo (Congo-Brazzaville)'),(N'Costa Rica'),
(N'Croatia'),(N'Cuba'),(N'Cyprus'),(N'Czech Republic'),(N'Denmark'),
(N'Djibouti'),(N'Dominica'),(N'Dominican Republic'),(N'Ecuador'),(N'Egypt'),
(N'El Salvador'),(N'Equatorial Guinea'),(N'Eritrea'),(N'Estonia'),(N'Eswatini'),
(N'Ethiopia'),(N'Fiji'),(N'Finland'),(N'France'),(N'Gabon'),
(N'Gambia'),(N'Georgia'),(N'Germany'),(N'Ghana'),(N'Greece'),
(N'Grenada'),(N'Guatemala'),(N'Guinea'),(N'Guinea-Bissau'),(N'Guyana'),
(N'Haiti'),(N'Honduras'),(N'Hungary'),(N'Iceland'),(N'India'),
(N'Indonesia'),(N'Iran'),(N'Iraq'),(N'Ireland'),(N'Italy'),
(N'Jamaica'),(N'Japan'),(N'Jordan'),(N'Kazakhstan'),(N'Kenya'),
(N'Kiribati'),(N'Kuwait'),(N'Kyrgyzstan'),(N'Laos'),(N'Latvia'),
(N'Lebanon'),(N'Lesotho'),(N'Liberia'),(N'Libya'),(N'Liechtenstein'),
(N'Lithuania'),(N'Luxembourg'),(N'Madagascar'),(N'Malawi'),(N'Malaysia'),
(N'Maldives'),(N'Mali'),(N'Malta'),(N'Marshall Islands'),(N'Mauritania'),
(N'Mauritius'),(N'Mexico'),(N'Micronesia'),(N'Moldova'),(N'Monaco'),
(N'Mongolia'),(N'Montenegro'),(N'Morocco'),(N'Mozambique'),(N'Myanmar'),
(N'Namibia'),(N'Nauru'),(N'Nepal'),(N'Netherlands'),(N'New Zealand'),
(N'Nicaragua'),(N'Niger'),(N'Nigeria'),(N'North Korea'),(N'North Macedonia'),
(N'Norway'),(N'Oman'),(N'Pakistan'),(N'Palau'),(N'Palestine'),
(N'Panama'),(N'Papua New Guinea'),(N'Paraguay'),(N'Peru'),(N'Philippines'),
(N'Poland'),(N'Portugal'),(N'Palestine'),          -- duplicate kept (CountryID 138)
(N'Qatar'),(N'Romania'),(N'Russia'),(N'Rwanda'),
(N'Saint Kitts and Nevis'),(N'Saint Lucia'),(N'Saint Vincent and the Grenadines'),
(N'Samoa'),(N'San Marino'),(N'Sao Tome and Principe'),(N'Saudi Arabia'),
(N'Senegal'),(N'Serbia'),(N'Seychelles'),(N'Sierra Leone'),(N'Singapore'),
(N'Slovakia'),(N'Slovenia'),(N'Solomon Islands'),(N'Somalia'),(N'South Africa'),
(N'South Korea'),(N'South Sudan'),(N'Spain'),(N'Sri Lanka'),(N'Sudan'),
(N'Suriname'),(N'Sweden'),(N'Switzerland'),(N'Syria'),(N'Taiwan'),
(N'Tajikistan'),(N'Tanzania'),(N'Thailand'),(N'Timor-Leste'),(N'Togo'),
(N'Tonga'),(N'Trinidad and Tobago'),(N'Tunisia'),(N'Turkey'),(N'Turkmenistan'),
(N'Tuvalu'),(N'Uganda'),(N'Ukraine'),(N'United Arab Emirates'),
(N'United Kingdom'),(N'United States'),(N'Uruguay'),(N'Uzbekistan'),
(N'Vanuatu'),(N'Vatican City'),(N'Venezuela'),(N'Vietnam'),
(N'Yemen'),(N'Zambia'),(N'Zimbabwe'),(N'Kosovo');
GO

CREATE TABLE People (
    PersonID             INT           IDENTITY(1,1) NOT NULL,
    NationalNo           NVARCHAR(20)  NOT NULL,
    FirstName            NVARCHAR(20)  NOT NULL,
    SecondName           NVARCHAR(20)  NOT NULL,
    ThirdName            NVARCHAR(20)  NULL,
    LastName             NVARCHAR(20)  NOT NULL,
    DateOfBirth          DATE          NOT NULL,
    Gendor               TINYINT       NOT NULL,  -- 0=Male, 1=Female
    Address              NVARCHAR(500) NOT NULL,
    Phone                NVARCHAR(20)  NOT NULL,
    Email                NVARCHAR(50)  NULL,
    NationalityCountryID INT           NOT NULL,
    ImagePath            NVARCHAR(250) NULL,
    CONSTRAINT PK_People        PRIMARY KEY (PersonID),
    CONSTRAINT UQ_People_NatNo  UNIQUE      (NationalNo),
    CONSTRAINT FK_People_Country
        FOREIGN KEY (NationalityCountryID) REFERENCES Countries (CountryID)
);
GO



INSERT INTO People
    (NationalNo,    FirstName,     SecondName,  ThirdName,  LastName,
     DateOfBirth,  Gendor,
     Address,                                Phone,             Email,
     NationalityCountryID,                   ImagePath)
VALUES
(N'10000001', N'Jawad',      N'Maher',   N'Lotfy',    N'Sindian',
     '2006-07-13', 0,
     N'DVLD Headquarters, Main Street',      N'00962799000001', N'admin@dvld.gov',
     168, 'C:\Users\j7664\OneDrive\Pictures\جواد سنديان.jpg'),
(N'10000002', N'Sarah',      N'James',    N'Lee',     N'Walker',
     '1995-06-20', 1,
     N'42 Oak Avenue, Springfield',          N'00962799000002', N'sarah.walker@email.com',
     185, 'C:\Users\j7664\OneDrive\Pictures\Avatar 1.png'),
(N'10000003', N'Ahmad',      N'Khalid',   N'Yousef',  N'Al-Hassan',
     '1990-03-10', 0,
     N'15 Palm Street, Amman',               N'00962799000003', N'ahmad.hassan@email.com',
     83,  'C:\Users\j7664\OneDrive\Pictures\Avatar 4.png'),
(N'10000004', N'Omar',       N'Faris',    N'Saeed',   N'Al-Rashid',
     '1988-07-14', 0,
     N'12 King Abdullah Street, Amman',      N'00962799000004', N'omar.rashid@email.com',
     83,  NULL),
(N'10000005', N'Nour',       N'Khalid',   N'Hassan',  N'Al-Masri',
     '1997-02-28', 1,
     N'7 Rainbow Street, Amman',             N'00962799000005', N'nour.masri@email.com',
     83,  'C:\Users\j7664\OneDrive\Pictures\Avatar 2.png'),
(N'10000006', N'Tariq',      N'Ibrahim',  N'Yousef',  N'Barakat',
     '1983-11-05', 0,
     N'33 Nablus Road, Ramallah',            N'00962799000006', N'tariq.barakat@email.com',
     130, NULL),   -- 130 = Palestine
(N'10000007', N'Fatima',     N'Mohamed',  N'Ali',     N'El-Sayed',
     '1992-04-17', 1,
     N'21 Tahrir Square, Cairo',             N'00962799000007', N'fatima.elsayed@email.com',
     50,  'C:\Users\j7664\OneDrive\Pictures\Avatar 2.png'),   -- 50 = Egypt
(N'10000008', N'Abdulaziz',  N'Saad',     N'Nasser',  N'Al-Ghamdi',
     '1979-09-30', 0,
     N'55 Olaya Street, Riyadh',             N'00962799000008', N'a.ghamdi@email.com',
     149,'C:\Users\j7664\OneDrive\Pictures\Avatar 3.png'),   -- 149 = Saudi Arabia
(N'10000009', N'Emily',      N'Rose',     N'Anne',    N'Thompson',
     '1994-12-03', 1,
     N'18 Baker Street, London',             N'00962799000009', N'emily.thompson@email.com',
     184, 'C:\Users\j7664\OneDrive\Pictures\Avatar 4.png'),   -- 184 = United Kingdom
(N'10000010', N'Michael',    N'James',    N'Robert',  N'Anderson',
     '1986-03-22', 0,
     N'900 Michigan Avenue, Chicago',        N'00962799000010', N'michael.anderson@email.com',
     185, 'C:\Users\j7664\OneDrive\Pictures\Avatar 3.png'),   -- 185 = United States
(N'10000011', N'Hassan',     N'Ali',      N'Mahdi',   N'Al-Zubaidi',
     '1991-08-19', 0,
     N'14 Karrada Street, Baghdad',          N'00962799000011', N'hassan.zubaidi@email.com',
     78,  NULL),   -- 78 = Iraq
(N'10000012', N'Layla',      N'Antoine',  N'Georges', N'Khoury',
     '1999-05-11', 1,
     N'3 Hamra Street, Beirut',              N'00962799000012', N'layla.khoury@email.com',
     91,  'C:\Users\j7664\OneDrive\Pictures\Avatar 1.png'),   -- 91 = Lebanon
(N'10000013', N'Rami',       N'Samer',    N'Ziad',    N'Al-Natour',
     '1985-01-27', 0,
     N'9 Straight Street, Damascus',         N'00962799000013', N'rami.natour@email.com',
     168, 'C:\Users\j7664\OneDrive\Pictures\Avatar 4.png');   -- 168 = Syria
GO



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
GO

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_PersonID UNIQUE (PersonID);
GO

INSERT INTO Users (PersonID, UserName, Password, IsActive) VALUES
(1,  N'jsindian',   N'123456', 1),  -- Jawad Maher Sindian (main user)
(2,  N'swalker',    N'123456', 1),  -- Sarah Walker
(3,  N'ahassan',    N'123456', 1),  -- Ahmad Al-Hassan
(4,  N'orashid',    N'12345', 1),  -- Omar Al-Rashid
(5,  N'nmasri',     N'12345', 1),  -- Nour Al-Masri
(6,  N'tbarakat',   N'12345', 0),  -- Tariq Barakat (inactive example)
(7,  N'felsayed',   N'12345', 1),  -- Fatima El-Sayed
(8,  N'aghamdi',    N'12345', 1),  -- Abdulaziz Al-Ghamdi
(9,  N'ethompson',  N'12345', 1),  -- Emily Thompson
(10, N'manderson',  N'12345', 1),  -- Michael Anderson
(11, N'hzubaidi',   N'12345', 0),  -- Hassan Al-Zubaidi (inactive example)
(12, N'lkhoury',    N'12345', 1),  -- Layla Khoury
(13, N'rnatour',    N'12345', 1);  -- Rami Al-Natour
GO


CREATE TABLE ApplicationTypes (
    ApplicationTypeID    INT           IDENTITY(1,1) NOT NULL,
    ApplicationTypeTitle NVARCHAR(150) NOT NULL,
    ApplicationFees      SMALLMONEY    NOT NULL,
    CONSTRAINT PK_ApplicationTypes PRIMARY KEY (ApplicationTypeID)
);
GO

INSERT INTO ApplicationTypes
    (ApplicationTypeTitle, ApplicationFees)
VALUES
(N'New Local Driving License Service',         15.00),
(N'Renew Driving License Service',              6.00),
(N'Replacement for a Lost Driving License',    10.00),
(N'Replacement for a Damaged Driving License',  5.00),
(N'Release Detained Driving License',          15.00),
(N'New International License',                 50.00),
(N'Retake Test',                                5.00);
GO


CREATE TABLE TestTypes (
    TestTypeID          INT           IDENTITY(1,1) NOT NULL,
    TestTypeTitle       NVARCHAR(100) NOT NULL,
    TestTypeDescription NVARCHAR(500) NOT NULL,
    TestTypeFees        SMALLMONEY    NOT NULL,
    CONSTRAINT PK_TestTypes PRIMARY KEY (TestTypeID)
);
GO

INSERT INTO TestTypes
    (TestTypeTitle, TestTypeDescription, TestTypeFees)
VALUES
(N'Vision Test',            N'Assesses visual acuity to ensure the applicant has adequate eyesight for safe driving.', 10.00),
(N'Written (Theory) Test',  N'Assesses knowledge of traffic rules, road signs, and driving regulations.',              20.00),
(N'Practical (Street) Test', N'Evaluates driving skills and ability to operate a motor vehicle safely on the road.',  30.00);
GO


CREATE TABLE Applications (
    ApplicationID     INT        IDENTITY(1,1) NOT NULL,
    ApplicantPersonID INT        NOT NULL,
    ApplicationDate   DATETIME   NOT NULL CONSTRAINT DF_App_Date       DEFAULT (GETDATE()),
    ApplicationTypeID INT        NOT NULL,
    ApplicationStatus TINYINT    NOT NULL CONSTRAINT DF_App_Status     DEFAULT (1),
    LastStatusDate    DATETIME   NOT NULL CONSTRAINT DF_App_LastStatus DEFAULT (GETDATE()),
    PaidFees          SMALLMONEY NOT NULL,
    CreatedByUserID   INT        NOT NULL,
    CONSTRAINT PK_Applications PRIMARY KEY (ApplicationID),
    CONSTRAINT FK_App_Person FOREIGN KEY (ApplicantPersonID) REFERENCES People           (PersonID),
    CONSTRAINT FK_App_Type   FOREIGN KEY (ApplicationTypeID) REFERENCES ApplicationTypes (ApplicationTypeID),
    CONSTRAINT FK_App_User   FOREIGN KEY (CreatedByUserID)   REFERENCES Users            (UserID),
    CONSTRAINT CK_App_Status CHECK (ApplicationStatus IN (1,2,3))
);
GO

INSERT INTO Applications
    (ApplicantPersonID, ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID)
VALUES
(2,  1, 3, 15.00, 1),  -- Sarah Walker      - New Local License - Completed
(3,  1, 3, 15.00, 1),  -- Ahmad Al-Hassan   - New Local License - Completed
(4,  1, 1, 15.00, 1),  -- Omar Al-Rashid    - New Local License - New
(5,  1, 1, 15.00, 1),  -- Nour Al-Masri     - New Local License - New
(7,  1, 2, 15.00, 1);  -- Fatima El-Sayed   - New Local License - Cancelled
GO


CREATE TABLE LicenseClasses (
    LicenseClassID         INT           IDENTITY(1,1) NOT NULL,
    ClassName              NVARCHAR(100) NOT NULL,
    ClassDescription       NVARCHAR(500) NOT NULL,
    MinimumAllowedAge      TINYINT       NOT NULL,
    DefaultValidityLength  TINYINT       NOT NULL,   -- in years
    ClassFees              SMALLMONEY    NOT NULL,
    CONSTRAINT PK_LicenseClasses PRIMARY KEY (LicenseClassID)
);
GO

INSERT INTO LicenseClasses
    (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
VALUES
(N'Class 1 - Small Motorcycle',         N'Allows driving small motorcycles with small engines.',                18, 5,  15.00),
(N'Class 2 - Heavy Motorcycle License', N'Allows driving large and powerful motorcycles.',                       21, 5,  30.00),
(N'Class 3 - Ordinary Driving License', N'Allows driving light vehicles and personal cars.',                     18, 10, 20.00),
(N'Class 4 - Commercial',               N'Allows driving taxis or limousines.',                                  21, 10, 200.00),
(N'Class 5 - Agricultural',             N'Allows driving all agricultural vehicles used in farming.',            21, 10, 50.00),
(N'Class 6 - Small and Medium Bus',     N'Allows driving small and medium buses.',                               21, 10, 250.00),
(N'Class 7 - Truck and Heavy Vehicle',  N'Allows driving trucks and heavy vehicles such as trailers.',           21, 10, 300.00);
GO


CREATE TABLE LocalDrivingLicenseApplication (
    LocalDrivingLicenseApplicationID INT IDENTITY(1,1) NOT NULL,
    ApplicationID    INT NOT NULL,
    LicenseClassID   INT NOT NULL,
    CONSTRAINT PK_LocalDrivingLicenseApplication
        PRIMARY KEY (LocalDrivingLicenseApplicationID),
    CONSTRAINT UQ_LDLA_ApplicationID
        UNIQUE (ApplicationID),
    CONSTRAINT FK_LDLA_Application
        FOREIGN KEY (ApplicationID) REFERENCES Applications (ApplicationID),
    CONSTRAINT FK_LDLA_LicenseClass
        FOREIGN KEY (LicenseClassID) REFERENCES LicenseClasses (LicenseClassID)
);
GO



INSERT INTO LocalDrivingLicenseApplication
    (ApplicationID, LicenseClassID)
VALUES
(1, 3),  -- Sarah Walker    -> Ordinary Driving License
(2, 1),  -- Ahmad Al-Hassan -> Small Motorcycle
(3, 3),  -- Omar Al-Rashid  -> Ordinary Driving License
(4, 3),  -- Nour Al-Masri   -> Ordinary Driving License
(5, 3);  -- Fatima El-Sayed -> Ordinary Driving License (application was cancelled)
GO


CREATE TABLE TestAppointments (
    TestAppointmentID                INT            IDENTITY(1,1) NOT NULL,
    TestTypeID                       INT            NOT NULL,
    LocalDrivingLicenseApplicationID INT            NOT NULL,
    AppointmentDate                  SMALLDATETIME  NOT NULL,
    PaidFees                         SMALLMONEY     NOT NULL,
    CreatedByUserID                  INT            NOT NULL,
    IsLocked                         BIT            NOT NULL CONSTRAINT DF_TestAppt_IsLocked DEFAULT (0),
    RetakeTestApplicationID          INT            NULL,
    CONSTRAINT PK_TestAppointments PRIMARY KEY (TestAppointmentID),
    CONSTRAINT FK_TestAppt_TestType
        FOREIGN KEY (TestTypeID) REFERENCES TestTypes (TestTypeID),
    CONSTRAINT FK_TestAppt_LDLA
        FOREIGN KEY (LocalDrivingLicenseApplicationID) REFERENCES LocalDrivingLicenseApplication (LocalDrivingLicenseApplicationID),
    CONSTRAINT FK_TestAppt_User
        FOREIGN KEY (CreatedByUserID) REFERENCES Users (UserID),
    CONSTRAINT FK_TestAppt_RetakeApplication
        FOREIGN KEY (RetakeTestApplicationID) REFERENCES Applications (ApplicationID),
);
GO


-- ===========================================================================
-- "Retake Test" Applications (ApplicationTypeID = 7).
-- Applications currently has exactly 5 rows (IDs 1-5), so these three land
-- on ApplicationID 6, 7, and 8.
-- ===========================================================================
INSERT INTO Applications
    (ApplicantPersonID, ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID)
VALUES
(3, 7, 1, 5.00, 1);  -- Ahmad Al-Hassan - Retake Test request (Written) -> ApplicationID 6
GO
 
INSERT INTO Applications
    (ApplicantPersonID, ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID)
VALUES
(4, 7, 1, 5.00, 1);  -- Omar Al-Rashid - Retake Test request (Written) -> ApplicationID 7
GO
 
INSERT INTO Applications
    (ApplicantPersonID, ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID)
VALUES
(5, 7, 1, 5.00, 1);  -- Nour Al-Masri - Retake Test request (Vision) -> ApplicationID 8
GO
 
 
-- ===========================================================================
-- LDLA 1 (ApplicationID 1, Sarah Walker, Status: Completed)
-- Passed Vision, Written, and Practical in order. No retakes needed.
-- ===========================================================================
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 1, '2026-01-05 09:00:00', 10.00, 1, 1, NULL),  -- Vision    - passed, locked
(2, 1, '2026-01-12 09:30:00', 20.00, 1, 1, NULL),  -- Written   - passed, locked
(3, 1, '2026-01-20 10:00:00', 30.00, 1, 1, NULL);  -- Practical - passed, locked
GO
 
 
-- ===========================================================================
-- LDLA 2 (ApplicationID 2, Ahmad Al-Hassan, Status: Completed)
-- Passed Vision, then FAILED Written once before passing it on retake,
-- then passed Practical.
-- ===========================================================================
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 2, '2025-12-15 13:00:00', 10.00, 1, 1, NULL);  -- Vision    - passed, locked
GO
 
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(2, 2, '2026-01-06 09:00:00', 20.00, 1, 1, NULL);  -- Written   - 1st attempt, FAILED, locked
GO
 
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(2, 2, '2026-01-13 09:30:00', 20.00, 1, 1, 6);     -- Written   - retake, passed, locked, linked to retake Application 6
GO
 
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(3, 2, '2026-01-21 10:00:00', 30.00, 1, 1, NULL);  -- Practical - passed, locked
GO
 
 
-- ===========================================================================
-- LDLA 3 (ApplicationID 3, Omar Al-Rashid, Status: New, in progress)
-- Passed Vision, then FAILED Written once. A retake is booked but not yet taken.
-- ===========================================================================
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 3, '2026-02-02 09:00:00', 10.00, 1, 1, NULL),  -- Vision  - passed, locked
(2, 3, '2026-02-10 09:30:00', 20.00, 1, 1, NULL);  -- Written - taken, FAILED, locked
GO
 
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(2, 3, '2026-04-15 09:00:00', 20.00, 1, 0, 7);     -- Written - RETAKE appointment, NOT yet taken, linked to retake Application 7
GO
 
 
-- ===========================================================================
-- LDLA 4 (ApplicationID 4, Nour Al-Masri, Status: New, just starting)
-- FAILED Vision once. A retake is booked but not yet taken.
-- ===========================================================================
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 4, '2026-02-03 11:00:00', 10.00, 1, 1, NULL);  -- Vision - 1st attempt, FAILED, locked
GO
 
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 4, '2026-02-18 11:00:00', 10.00, 1, 0, 8);     -- Vision - RETAKE appointment, NOT yet taken, linked to retake Application 8
GO
 
 
-- ===========================================================================
-- LDLA 5 (ApplicationID 5, Fatima El-Sayed, Status: Cancelled)
-- Took Vision and Written before the application was cancelled. Never reached Practical.
-- ===========================================================================
INSERT INTO TestAppointments
    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES
(1, 5, '2026-01-08 08:30:00', 10.00, 1, 1, NULL),  -- Vision  - passed, locked
(2, 5, '2026-01-09 09:00:00', 20.00, 1, 1, NULL);  -- Written - taken, locked (application cancelled afterward)
GO


UPDATE A
SET A.ApplicationStatus = 3,          
    A.LastStatusDate    = GETDATE()
FROM Applications A
JOIN LocalDrivingLicenseApplication LDLA
    ON LDLA.ApplicationID = A.ApplicationID
WHERE A.ApplicationStatus = 1           
                                        
  AND EXISTS ( 
        SELECT 1 FROM TestAppointments TA
        WHERE TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
          AND TA.TestTypeID = 1
          AND TA.IsLocked = 1
      )
  AND EXISTS (  
        SELECT 1 FROM TestAppointments TA
        WHERE TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
          AND TA.TestTypeID = 2
          AND TA.IsLocked = 1
      )
  AND EXISTS (  
        SELECT 1 FROM TestAppointments TA
        WHERE TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
          AND TA.TestTypeID = 3
          AND TA.IsLocked = 1
      );



CREATE TABLE Tests
(
   TestID            INT           IDENTITY(1,1) NOT NULL,
   TestAppointmentID INT           NOT NULL,
   CreatedByUserID   INT           NOT NULL,
   TestResult        BIT           NOT NULL, -- 0 Failed, 1 Passed
   Notes             NVARCHAR(500) NULL,
   CONSTRAINT PK_Tests PRIMARY KEY (TestID),
   CONSTRAINT FK_Tests_TestAppointment
       FOREIGN KEY (TestAppointmentID) REFERENCES TestAppointments (TestAppointmentID),
   CONSTRAINT FK_Tests_CreatedByUser
       FOREIGN KEY (CreatedByUserID) REFERENCES Users (UserID)
);
GO


INSERT INTO Tests
    (TestAppointmentID, CreatedByUserID, TestResult, Notes)
VALUES
-- LDLA 1: Sarah Walker — Vision, Written, Practical all passed
(1,  1, 1, NULL),
(2,  1, 1, NULL),
(3,  1, 1, N'Needs improvement in parallel parking.'),

-- LDLA 2: Ahmad Al-Hassan — Vision passed, Written failed then passed on retake, Practical passed
(4,  1, 1, NULL),
(5,  1, 0, N'Failed due to insufficient knowledge of road signs.'),
(6,  1, 1, NULL),
(7,  1, 1, N'Good control overall; needs improvement in reverse parking.'),

-- LDLA 3: Omar Al-Rashid — Vision passed, Written failed (retake booked, not yet taken)
(8,  1, 1, NULL),
(9,  1, 0, N'Failed due to low score on traffic law questions.'),

-- LDLA 4: Nour Al-Masri — Vision failed (retake booked, not yet taken)
(10, 1, 0, N'Failed due to poor visual acuity in right eye; corrective lenses recommended.'),

-- LDLA 5: Fatima El-Sayed — Vision passed, Written taken before cancellation
(13, 1, 1, NULL),
(14, 1, 1, NULL);
GO