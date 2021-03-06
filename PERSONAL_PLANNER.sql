CREATE TABLE TBL_USER
(
USERNAME VARCHAR(255),
FIRST_NAME VARCHAR(255) NOT NULL,
SECOND_NAME VARCHAR(255) NOT NULL,
SAVED_PASSWORD VARCHAR(255) NOT NULL,
PRIMARY KEY(USERNAME)
);

CREATE TABLE TBL_USER_INCOME
(
FK_USERNAME VARCHAR(255) NOT NULL,
GROSS_INCOME DECIMAL(18,2) NOT NULL,
TAX DECIMAL(3,2)NOT NULL,
NET_INCOME DECIMAL(18,2) NOT NULL,
TOTAL_EXPENSES DECIMAL(18,2) NOT NULL,
INCOME_AFTER_TAX DECIMAL(18,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);

CREATE TABLE TBL_GENERAL_EXPENSES
(
FK_USERNAME VARCHAR(255) NOT NULL,
GROCERIES DECIMAL(15,2) NOT NULL,
WATER_LIGHTS DECIMAL(15,2) NOT NULL,
TRAVEL DECIMAL(15,2) NOT NULL,
COMMUNICATION DECIMAL(15,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);

CREATE TABLE OTHER_EXPENSES
(
FK_USERNAME VARCHAR(255) NOT NULL,
OTHER_EXPENSE VARCHAR(255) NOT NULL,
COST DECIMAL(15,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);

CREATE TABLE TBL_HOUSELOAN
(
FK_USERNAME VARCHAR(255) NOT NULL,
HOUSE_PURCHASE_PRICE DECIMAL(18,2) NOT NULL,
HOUSE_DEPOSIT DECIMAL(18,2) NOT NULL,
HOUSE_INTEREST DECIMAL(13,2) NOT NULL,
MONTHS_TO_PAY INT NOT NULL,
MONTHLY_PAYMENT DECIMAL(18,2) NOT NULL,
TOTAL_PAYMENT DECIMAL(18,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);

CREATE TABLE TBL_RENTAL
(
FK_USERNAME VARCHAR(255) NOT NULL,
RENTAL_AMOUNT DECIMAL(17,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);

CREATE  TABLE TBL_VEHICLE_LOAN
(
FK_USERNAME VARCHAR(255) NOT NULL,
MODEL VARCHAR(255) NOT NULL,
MAKE VARCHAR(255) NOT NULL,
VEHICLE_PURCHASE_PRICE DECIMAL(18,2) NOT NULL,
VEHICLE_DEPOSIT DECIMAL(18,2) NOT NULL,
VEHICLE_INTEREST DECIMAL(13,2) NOT NULL,
INSURANCE DECIMAL(15,2) NOT NULL,
VEHICLE_MONTHS_TO_PAY INT NOT NULL,
VEHICLE_MONTHLY_PAYMENT DECIMAL(18,2) NOT NULL,
VEHICLE_TOTAL_PAYMENT DECIMAL(18,2) NOT NULL,
FOREIGN KEY(FK_USERNAME) REFERENCES TBL_USER(USERNAME)
);
