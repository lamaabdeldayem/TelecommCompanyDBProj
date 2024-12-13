INSERT INTO Customer_Profile (nationalID, first_name, last_name, email, address, date_of_birth)
VALUES (1, 'John', 'Doe', 'john.doe@example.com', '123 Elm Street', '1990-01-01'),
       (2, 'Jane', 'Smith', 'jane.smith@example.com', '456 Oak Avenue', '1985-05-15'),
       (3, 'Robert', 'Brown', 'robert.brown@example.com', '789 Pine Street', '1988-11-22'),
       (4, 'Emily', 'Davis', 'emily.davis@example.com', '101 Maple Drive', '1995-04-14'),
       (5, 'Michael', 'Johnson', 'michael.johnson@example.com', '202 Birch Lane', '1992-07-30'),
       (6, 'Sarah', 'Wilson', 'sarah.wilson@example.com', '303 Cedar Ave', '1990-10-05'),
       (7, 'David', 'Lee', 'david.lee@example.com', '404 Spruce Road', '1993-03-18');
      
SET IDENTITY_INSERT Service_Plan ON;
INSERT INTO Service_Plan (planID, SMS_offered, minutes_offered, data_offered, name, price, description)
VALUES (101, 100, 500, 2048, 'Basic Plan', 20, 'Affordable basic plan'),
       (102, 200, 1000, 4096, 'Premium Plan', 50, 'High-end plan with more data'),
       (103, 50, 300, 1024, 'Starter Plan', 10, 'Beginner-level plan'),
       (104, 300, 1500, 8192, 'Ultra Plan', 70, 'Best value for heavy users'),
       (105, 150, 800, 3072, 'Mid-Range Plan', 30, 'Mid-tier data offering'),
       (106, 500, 2500, 12288, 'Enterprise Plan', 100, 'Business-level plan'),
       (107, 75, 400, 1536, 'Budget Plan', 15, 'Low-cost option');
SET IDENTITY_INSERT Service_Plan OFF;

SET IDENTITY_INSERT Shop ON;
INSERT INTO Shop (shopID, name, category)
VALUES (1, 'Tech Store', 'Electronics'),
       (2, 'Fashion Hub', 'Clothing'),
       (3, 'Grocery Mart', 'Groceries'),
       (4, 'Sports Arena', 'Sports Equipment'),
       (5, 'Book Haven', 'Books'),
       (6, 'Music World', 'Music'),
       (7, 'Home Essentials', 'Furniture');
SET IDENTITY_INSERT Shop OFF;

INSERT INTO Customer_Account (mobileNo, pass, balance, account_type, start_date, status, points, nationalID)
VALUES ('01234567890', 'password123', 100.0, 'prepaid', '2023-01-01', 'active', 50, 1),
       ('09876543210', 'securepass', 200.0, 'postpaid', '2023-02-01', 'active', 75, 2),
       ('01122334455', 'mypassword', 150.0, 'prepaid', '2023-03-01', 'active', 30, 3),
       ('02233445566', 'mypin123', 250.0, 'postpaid', '2023-04-01', 'onhold', 60, 4),
       ('03344556677', 'safepass', 120.0, 'prepaid', '2023-05-01', 'active', 40, 5),
       ('04455667788', 'simplepass', 80.0, 'postpaid', '2023-06-01', 'active', 55, 6),
       ('05566778899', 'supersecure', 300.0, 'prepaid', '2023-07-01', 'active', 90, 7);
       SET IDENTITY_INSERT Wallet ON;
INSERT INTO Wallet (walletID, current_balance, currency, last_modified_date, nationalID, mobileNo)
VALUES (1, 150.50, 'USD', '2023-10-01', 1, '01234567890'),
       (2, 300.75, 'USD', '2023-10-02', 2, '09876543210'),
       (3, 180.00, 'USD', '2023-10-03', 3, '01122334455'),
       (4, 225.25, 'USD', '2023-10-04', 4, '02233445566'),
       (5, 110.10, 'USD', '2023-10-05', 5, '03344556677'),
       (6, 95.75, 'USD', '2023-10-06', 6, '04455667788'),
       (7, 400.00, 'USD', '2023-10-07', 7, '05566778899');
SET IDENTITY_INSERT Wallet OFF;
SET IDENTITY_INSERT Plan_Usage ON;
INSERT INTO Plan_Usage (usageID, start_date, end_date, data_consumption, minutes_used, SMS_sent, mobileNo, planID)
VALUES (1, '2023-01-01', '2023-01-31', 1500, 400, 80, '01234567890', 101),
       (2, '2023-02-01', '2023-02-28', 3500, 800, 150, '09876543210', 102),
       (3, '2023-03-01', '2023-03-31', 800, 200, 40, '01122334455', 103),
       (4, '2023-04-01', '2023-04-30', 6000, 1300, 300, '02233445566', 104),
       (5, '2023-05-01', '2023-05-31', 2500, 900, 120, '03344556677', 105),
       (6, '2023-06-01', '2023-06-30', 12000, 2400, 500, '04455667788', 106),
       (7, '2023-07-01', '2023-07-31', 1200, 350, 60, '05566778899', 107);
SET IDENTITY_INSERT Plan_Usage OFF;
SET IDENTITY_INSERT Payment ON;
INSERT INTO Payment (paymentID, amount, date_of_payment, payment_method, status, mobileNo)
VALUES (1, 20.0, '2023-01-01', 'credit', 'successful', '01234567890'),
       (2, 50.0, '2023-02-01', 'credit', 'successful', '09876543210'),
       (3, 15.0, '2023-03-01', 'cash', 'pending', '01122334455'),
       (4, 70.0, '2023-04-01', 'credit', 'successful', '02233445566'),
       (5, 30.0, '2023-05-01', 'cash', 'successful', '03344556677'),
       (6, 100.0, '2023-06-01', 'credit', 'successful', '04455667788'),
       (7, 25.0, '2023-07-01', 'cash', 'successful', '05566778899');
SET IDENTITY_INSERT Payment OFF;
SET IDENTITY_INSERT Benefits ON;
INSERT INTO Benefits (benefitID, description, validity_date, status, mobileNo)
VALUES (1, 'Free extra data', '2024-01-01', 'active', '01234567890'),
       (2, 'Discounted SMS', '2024-02-01', 'active', '09876543210'),
       (3, 'Bonus minutes', '2024-03-01', 'expired', '01122334455'),
       (4, 'Promotional Offer', '2024-04-01', 'active', '02233445566'),
       (5, 'Limited Time cashback', '2024-05-01', 'expired', '03344556677'),
       (6, 'Holiday Special', '2024-06-01', 'active', '04455667788'),
       (7, 'Birthday Reward', '2024-07-01', 'active', '05566778899');
SET IDENTITY_INSERT Benefits OFF;
SET IDENTITY_INSERT Voucher ON;
INSERT INTO Voucher (voucherID, value, expiry_date, points, mobileNo, shopID, redeem_date)
VALUES (1, 10, '2024-01-01', 20, '01234567890', 1, '2023-12-01'),
       (2, 15, '2024-01-15', 30, '09876543210', 2, '2023-12-10'),
       (3, 20, '2024-02-01', 40, '01122334455', 3, '2023-12-20'),
       (4, 25, '2024-03-01', 50, '02233445566', 4, '2024-01-01'),
       (5, 30, '2024-04-01', 60, '03344556677', 5, '2024-01-10'),
       (6, 35, '2024-05-01', 70, '04455667788', 6, '2024-01-20'),
       (7, 40, '2024-06-01', 80, '05566778899', 7, '2024-02-01');
SET IDENTITY_INSERT Voucher OFF;
SET IDENTITY_INSERT Exclusive_Offer ON;
INSERT INTO Exclusive_Offer (offerID, benefitID, internet_offered, SMS_offered, minutes_offered)
VALUES (1, 1, 500, 50, 100),
       (2, 2, 1000, 100, 200),
       (3, 3, 250, 25, 50),
       (4, 4, 800, 75, 150),
       (5, 5, 1200, 150, 300),
       (6, 6, 400, 30, 60),
       (7, 7, 600, 45, 90);
SET IDENTITY_INSERT Exclusive_Offer OFF;
SET IDENTITY_INSERT cashback ON;
INSERT INTO cashback (cashbackID, benefitID, walletID, amount, credit_date)
VALUES (1, 1, 1, 5, '2023-12-01'),
       (2, 2, 2, 10, '2023-12-05'),
       (3, 3, 3, 15, '2023-12-10'),
       (4, 4, 4, 20, '2023-12-15'),
       (5, 5, 5, 25, '2023-12-20'),
       (6, 6, 6, 30, '2023-12-25'),
       (7, 7, 7, 35, '2023-12-30');
SET IDENTITY_INSERT cashback OFF;
INSERT INTO Plan_Provides_Benefits (benefitID, planID)
VALUES (1, 101),
       (2, 102),
       (3, 103),
       (4, 104),
       (5, 105),
       (6, 106),
       (7, 107);
INSERT INTO Process_Payment (paymentID, planID)
VALUES (1, 101),
       (2, 102),
       (3, 103),
       (4, 104),
       (5, 105),
       (6, 106),
       (7, 107);

SET IDENTITY_INSERT Transfer_Money ON;
INSERT INTO Transfer_Money (walletID1, walletID2, transfer_id, amount, transfer_date)
VALUES (1, 2, 1, 50.0, '2023-12-01'),
       (2, 3, 2, 75.0, '2023-12-05'),
       (3, 4, 3, 30.0, '2023-12-10'),
       (4, 5, 4, 100.0, '2023-12-15'),
       (5, 6, 5, 20.0, '2023-12-20'),
       (6, 7, 6, 45.0, '2023-12-25'),
       (7, 1, 7, 15.0, '2023-12-30');
SET IDENTITY_INSERT Transfer_Money OFF;
SET IDENTITY_INSERT Technical_Support_Ticket ON;
INSERT INTO Technical_Support_Ticket (ticketID, mobileNo, Issue_description, priority_level, status)
VALUES (1, '01234567890', 'Network issue', 1, 'Resolved'),
       (2, '09876543210', 'Billing query', 2, 'Open'),
       (3, '01122334455', 'Slow connection', 3, 'In progress'),
       (4, '02233445566', 'Account locked', 1, 'Resolved'),
       (5, '03344556677', 'Incorrect charges', 2, 'Open'),
       (6, '04455667788', 'Unable to recharge', 3, 'In progress'),
       (7, '05566778899', 'Service disruption', 1, 'Resolved');
SET IDENTITY_INSERT Technical_Support_Ticket OFF;