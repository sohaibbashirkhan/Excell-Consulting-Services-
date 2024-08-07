Create Database ExcellOnService

Use ExcellOnService

create table Branches(
BranchID int primary key identity,
BranchName varchar(255),
BranchAddress varchar(255),
City varchar(255),
StateProvince varchar(255),
Country varchar(255),
EmailAddress varchar(255),
PhoneNumber varchar(255),
Manager varchar(255),
OpeningDate varchar(255)
)
Create Table InboundServices(
InboundID int primary key identity,
ServiceName varchar(255),
Cnic Varchar(255),
PhoneNo varchar(255),
Email varchar(255),
Country varchar(255),
ServiceType varchar(255),
Price int
)

create table OutboundServices(
OutboundID int primary key identity,
ServiceName varchar(255),
Cnic varchar(255),
City varchar(255),
PhoneNo varchar(255),
Email Varchar(255),
Country Varchar(255),
ServiceType varchar(255),
UserExperience varchar(255),
Price int
)
create table TeleMarketingServices(
TeleID int primary key identity,
ServiceName varchar(255),
Cnic varchar(255),
City varchar(255),
PhoneNo varchar(255),
Email Varchar(255),
Country Varchar(255),
ServiceType varchar(255),
UserStatus varchar(255),
Price int
)

create table HrManagement(
HRID int Primary key identity,
HRName varchar(255),
PhoneNo varchar(255),
Email varchar(255),
HRAddress varchar(255)
)
create table Administration(
AdminID int Primary key identity,
AdminName varchar(255),
PhoneNo varchar(255),
Email varchar(255),
AdminPassword varchar(255)
)
create table ProductService(
ID int Primary key identity,
Title varchar(255),
ServiceType varchar(255),
Descriptions varchar(255),
Picture varchar(255),
Price int
)

create table Training(
ID int Primary key identity,
Title varchar(255),
Descriptions varchar(255),
Picture varchar(255),
Duration varchar(255),
TrainingStatus varchar(255)
)

create table Contact(
ID int primary key identity,
Username varchar(255),
PhoneNo varchar(255),
Email varchar(255),
ContactMessage varchar(255)
)

create table logins(
id int primary key identity,
username varchar(255),
useremail varchar(255),
userpass varchar(255)
)
select * From Branches
