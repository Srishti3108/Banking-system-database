--create banking system
create database Bankingsystem
alter database Bankingsystem modify name= HMBank
create table customers(
customer_id int not null primary key,
first_name varchar (30) not null,
last_name varchar(30)not null,
DOB date not null,
email varchar(30) not null,
phone_number varchar(30) not null, 
)
alter table customers
add Address varchar(30);
 
create table Accounts(
account_id int not null primary key,
customer_id int not null,foreign key(customer_id) references customers(customer_id),
account_type varchar(30) not null,
balance varchar (30),
)
alter table Accounts
alter column balance decimal;

create table Transactions(
transaction_id int not null primary key,
account_id int not  null, foreign key(account_id) references Accounts(account_id),
transaction_type varchar(50)not null,
amount varchar(50) not null,
transaction_date date not null,
)
insert into customers (customer_id,first_name,last_name,DOB,email,phone_number,Address) values
(1,'Srishti','seth','2001-01-31','a@gmail.com',11111,'Banaras'),
(2,'Arya','dev','2001-01-22','b@gmail.com',2222,'Lucknow'),
(3,'Divya','sen','2002-02-8','c@gmail.com',3333,'Delhi'),
(4,'Ram','sinha','1999-03-15','d@gmail.com',4444,'delhi'),
(5,'Arijit','singh','2003-04-10','e@gmail.com',5555,'Banaras'),
(6,'Diljit','verma','2001-05-01','f@gmail.com',6666,'Kanpur'),
(7,'Moulik','saxena','1998-06-28','g@gmail.com',7777,'Azamgarh'),
(8,'Sakalp','saxena','2002-03-13','h@gmail.com',8888,'Noida'),
(9,'Riya','kumar','2003-04-7','i@gmail.com',9999,'Azmgarh'),
(10,'Pooja','singh','2001-05-04','j@gmail.com',0000,'Kanpur');
select * from customers;

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES
(1, 1, 'savings', 3000.00),
(2, 2, 'current', 1500.00),
(3, 3, 'zero_balance', 0.00),
(4, 4, 'savings', 4500.0),
(5, 5, 'current', 1200.00),
(6, 6, 'zero_balance', 0.00),
(7, 7, 'savings', 2500.00),
(8, 8, 'current', 600.00),
(9, 9, 'savings', 5100.00),
(10, 10, 'zero_balance', 0.00);
select * from Accounts

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES
(1, 1, 'deposit', 1000.00, '2023-02-01'),
(2, 2, 'withdrawal', 200.00, '2023-02-10'),
(3, 3, 'deposit', 500.00, '2023-03-15'),
(4, 4, 'deposit', 50.00, '2023-01-20'),
(5, 5, 'withdrawal', 300.00, '2023-03-03'),
(6, 6, 'deposit', 250.00, '2023-04-21'),
(7, 7, 'withdrawal', 75.00, '2023-05-09'),
(8, 8, 'transfer', 400.00, '2023-06-13'),
(9, 9, 'deposit', 150.00, '2023-07-27'),
(10, 10, 'withdrawal', 100.00, '2023-08-08');
select * from Transactions

--1-Write a SQL query to retrieve the name, account type and email of all customers
select concat(first_name,' ',last_name) as Fullname, email , accounts.account_type 
from customers 
left join Accounts 
on customers.customer_id =accounts.account_id ;

--2- Write a SQL query to list all transaction corresponding customer
select transaction_id,customers.first_name, amount 
from Transactions
left join customers 
on transactions.transaction_id = customers.customer_id;

--3 Write a SQL query to increase the balance of a specific account by a certain amount
update accounts
set balance=balance+500
where account_type = 'savings';
select balance from accounts

--4-Write a SQL query to Combine first and last names of customers as a full_name
select concat(first_name,' ',last_name) as Full_name
from customers 

--5 Write a SQL query to remove accounts with a balance of zero where the account type is savings. 
DELETE FROM Accounts
WHERE balance = 0                
AND account_type = 'savings';

-- 6 write a SQL query to Find customers living in a specific city
select concat(first_name,' ',last_name)as fullname 
from customers 
where address ='Banaras';

--7 Write a SQL query to Get the account balance for a specific account. 
select balance 
from accounts 
where account_type ='savings';

--8 Write a SQL query to List all current accounts with a balance greater than $1,000
select *
from accounts 
where balance > 1000;

--9 Write a SQL query to Retrieve all transactions for a specific account.
select *
from transactions 
where transaction_type = 'deposit';

--10 Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate. 
SELECT account_id, balance, 
       (balance * 5 / 100) AS interest
FROM Accounts
WHERE account_type = 'savings';

-- 11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit. 
SELECT *
FROM Accounts
WHERE balance < 500;



--12 Write a SQL query to Find customers not living in a specific city.
select first_name, last_name, address 
from customers 
where address!='banaras';

-- Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins:
--1. Write a SQL query to Find the average account balance for all customers. 
SELECT customers.first_name,customers.last_name,AVG(accounts.balance) AS average_balance
FROM accounts
JOIN customers ON accounts.customer_id = customers.customer_id
GROUP BY customers.first_name, customers.last_name;

--2. Write a SQL query to Retrieve the top 10 highest account balances.  
select balance from accounts order by balance desc;

--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date. 

SELECT c.first_name,c.last_name, SUM(CAST(amount AS DECIMAL(10, 2))) AS total_deposits
FROM Transactions t
right join customers c
on t.account_id=c.customer_id                 
WHERE transaction_type = 'deposit'
AND transaction_date = '2023-07-27'
group by c.first_name,c.last_name;

--4. Write a SQL query to Find the Oldest and Newest Customers.
Select top 1 concat(first_name,' ',last_name) as fullname, dob
from customers 
order by dob desc -- newest customers
Select top 1 concat(first_name,' ',last_name) as fullname, dob
from customers order by dob asc -- oldest customers


--5. Write a SQL query to Retrieve transaction details along with the account type. 
select transaction_id,transaction_type, amount, a.account_type 
from transactions t
join accounts a
on t.transaction_id=a.account_id;

--6. Write a SQL query to Get a list of customers along with their account details. 
select concat(first_name,' ', last_name) as fullname ,a.account_type,a.balance
from customers c 
join accounts a 
on 
c.customer_id=a.account_id
order by a.balance desc;

--7. Write a SQL query to Retrieve transaction details along with customer information for a specific account. 
select concat(first_name,' ', last_name) as fullname, c.DOB,c.email,c.phone_number, t.transaction_type,t.amount,a.balance,a.account_type
from customers c
join transactions t
on c.customer_id=t.transaction_id
join accounts a
on t.transaction_id=a.account_id
where account_type='current';

--8. Write a SQL query to Identify customers who have more than one account.
select c.customer_id,concat(first_name,' ',last_name) as fullname, count(a.account_type) 
from customers c
join accounts a
on c.customer_id=a.account_id
group by                                
c.customer_id,
c.first_name,
c.last_name
having 
count(a.account_id)>1;

--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
 SELECT 
    (SELECT SUM(CAST(amount AS DECIMAL(10, 2))) FROM Transactions WHERE transaction_type = 'deposit') - 
    (SELECT SUM(CAST(amount AS DECIMAL(10, 2))) FROM Transactions WHERE transaction_type = 'withdrawal') AS difference;

--10. Write a SQL query to Calculate the average daily balance for each account over a specified period.
SELECT account_id, AVG(CAST(amount AS DECIMAL(10, 2))) AS average_daily_balance
FROM Transactions
WHERE transaction_date BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY account_id;

--11. Calculate the total balance for each account type. 
select account_type,sum(balance) as total_balance
from accounts
group by account_type

--12. Identify accounts with the highest number of transactions order by descending order. 
SELECT 
a.account_id, 
COUNT(t.transaction_id) AS transaction_count
FROM  Transactions t
JOIN Accounts a 
ON a.account_id = t.account_id  
GROUP BY 
a.account_id
ORDER BY 
transaction_count DESC;  

--13. List customers with high aggregate account balances, along with their account types. 

select c.first_name,c.last_name,a.account_type,sum(a.balance) as total_sum
from customers c
join accounts a
on c.customer_id=a.account_id
group by c.customer_id, c.first_name, c.last_name, a.account_type
HAVING 
SUM(a.balance) > 3000
order by total_sum desc;



--14. Identify and list duplicate transactions based on transaction amount, date, and account. 
SELECT 
 account_id,
 amount,
 transaction_date,
 COUNT(*) AS duplicate_count
FROM Transactions t
GROUP BY 
 account_id, amount, transaction_date     
HAVING 
COUNT(*) > 1  
ORDER BY 
duplicate_count DESC;

--*Tasks 4: Subquery and its type: -----------------------

--1. Retrieve the customer(s) with the highest account balance. 
SELECT *
FROM customers
WHERE customer_id = (
    SELECT TOP 1 customer_id 
    FROM Accounts 
    ORDER BY balance DESC
);


--2. Calculate the average account balance for customers who have more than one account. 

SELECT 
 c.customer_id, 
 c.first_name, 
 c.last_name, 
 c.email, 
  AVG(a.balance) AS average_balance
FROM  customers c
JOIN Accounts a ON c.customer_id = a.customer_id
WHERE c.customer_id IN (
        SELECT customer_id FROM Accounts GROUP BY customer_id  HAVING COUNT(account_id) > 1
    )
GROUP BY 
 c.customer_id, 
 c.first_name, 
 c.last_name, 
 c.email;

--3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
SELECT *
FROM Transactions
WHERE CAST(amount AS DECIMAL(10, 2)) > (
SELECT AVG(CAST(amount AS DECIMAL(10, 2)))FROM Transactions);


--4. Identify customers who have no recorded transactions. 
SELECT *
FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM Accounts JOIN Transactions ON Accounts.account_id = Transactions.account_id);

--5. Calculate the total balance of accounts with no recorded transactions. 
SELECT SUM(balance) AS total_balance
FROM Accounts
WHERE account_id NOT IN (SELECT account_id FROM Transactions);

--6. Retrieve transactions for accounts with the lowest balance. 
SELECT *
FROM Transactions
WHERE account_id = (SELECT TOP 1 account_id FROM Accounts ORDER BY balance ASC);


--7. Identify customers who have accounts of multiple types. 
SELECT customer_id, COUNT(*) AS total_accounts
FROM Accounts
GROUP BY customer_id;


--8. Calculate the percentage of each account type out of the total number of accounts. 
SELECT account_type, (COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Accounts)) AS percentage
FROM Accounts
GROUP BY account_type;

--9. Retrieve all transactions for a customer with a given customer_id.
SELECT Transactions.*
FROM Transactions
JOIN Accounts ON Transactions.account_id = Accounts.account_id
WHERE Accounts.customer_id = 1;


--10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
SELECT account_type, (SELECT SUM(balance) FROM Accounts AS A WHERE A.account_type = Accounts.account_type) AS total_balance
FROM Accounts
GROUP BY account_type;
