CREATE TABLE Countries (
    CountryID   INT           IDENTITY(1,1) NOT NULL,
    CountryName NVARCHAR(50)  NOT NULL,
    CONSTRAINT PK_Countries PRIMARY KEY (CountryID)
);

CREATE TABLE People (
    PersonID             INT           IDENTITY(1,1) NOT NULL,
    NationalNo           NVARCHAR(20)  NOT NULL,
    FirstName            NVARCHAR(20)  NOT NULL,
    SecondName           NVARCHAR(20)  NOT NULL,
    ThirdName            NVARCHAR(20)  NOT NULL,
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


INSERT INTO People
    (NationalNo,    FirstName,     SecondName,  ThirdName,  LastName,
     DateOfBirth,  Gendor,
     Address,                                Phone,             Email,
     NationalityCountryID,                   ImagePath)
VALUES
(N'10000001', N'Jawad',      N'Maher',   N'Lotfy',    N'Sindian',
     '1980-01-01', 0,
     N'DVLD Headquarters, Main Street',      N'00962799000001', N'admin@dvld.gov',
     168, 'C:\Users\j7664\OneDrive\Pictures\photo_2026-03-23_22-18-04.jpg'),

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
