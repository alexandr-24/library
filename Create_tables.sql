CREATE TABLE Author(
	[ID_Author] INT PRIMARY KEY IDENTITY(1,1),
	[Surname] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Middle_name] NVARCHAR(50) NULL,
	[Birthday] DATE NOT NULL,
	[Nationality] NVARCHAR(50) NOT NULL
)

CREATE TABLE Book(
	[ID_Book] INT PRIMARY KEY IDENTITY(1,1),
	[ID_Author] INT FOREIGN KEY REFERENCES Author(ID_Author) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Year_of_publishing] INT NOT NULL,
	[Number_of_pages] INT NOT NULL,
	[Publisher] NVARCHAR(50) NOT NULL
)

CREATE TABLE Reader(
	[ID_Reader] INT PRIMARY KEY IDENTITY(1,1),
	[Surname] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Middle_name] NVARCHAR(50) NULL,
	[Birthday] DATE NOT NULL,
	[Passport_data] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[Contact_number] NVARCHAR(50) NOT NULL
)

CREATE TABLE Subscription(
	[Date_of_issue] DATE,
	[ID_Book] INT FOREIGN KEY REFERENCES Book(ID_Book),
	[ID_Reader] INT FOREIGN KEY REFERENCES Reader(ID_Reader),
	PRIMARY KEY(Date_of_issue, ID_Book, ID_Reader),
	[Return_period] INT NOT NULL,
	[Return_stamp] BIT NOT NULL
)

CREATE TABLE Fine(
	[ID_Book] INT,
	[ID_Reader] INT,
	[Date_of_issue] DATE,
	FOREIGN KEY (Date_of_issue, ID_Book, ID_Reader) REFERENCES Subscription (Date_of_issue, ID_Book, ID_Reader),
	PRIMARY KEY (ID_Book, ID_Reader, Date_of_issue),
	[Return_date] DATE NULL,
	[Status] NVARCHAR(50) NULL,
	[Book_is_lost] BIT NOT NULL,
	[Fine] DECIMAL(18,2) NOT NULL
)