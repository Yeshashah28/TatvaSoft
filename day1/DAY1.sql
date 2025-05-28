CREATE TABLE customer (
    customer_id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100),
    city VARCHAR(50)
);

CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INT REFERENCES customer(customer_id),
    order_date DATE,
    amount NUMERIC(10, 2)
);

INSERT INTO customer (name, email, city) VALUES
('Alice', 'alice@example.com', 'New York'),
('Bob', 'bob@example.com', 'Los Angeles'),
('Charlie', 'charlie@example.com', 'Chicago');

INSERT INTO orders (customer_id, order_date, amount) VALUES
(1, '2024-01-01', 100.00),
(1, '2024-02-15', 150.00),
(2, '2024-03-10', 200.00);

SELECT * FROM customer;

SELECT * FROM orders;

UPDATE customer
SET email = 'newalice@example.com'
WHERE name = 'Alice';

UPDATE orders
SET amount = 175.00
WHERE order_id = 2;

DELETE FROM customer
WHERE name = 'David';

SELECT name from customer ORDER BY name ASC;

SELECT name from customer ORDER BY name DESC;

SELECT c.name,c.email, o.amount FROM customer c LEFT JOIN orders o ON c.customer_id=o.customer_id;

SELECT c.name, SUM(o.amount) as totalbill, COUNT(o.order_id) as totalorders FROM customer c JOIN orders o ON c.customer_id=o.customer_id GROUP BY c.name;

SELECT c.name, SUM(o.amount) as totalbill, COUNT(o.order_id) as totalorders FROM customer c JOIN orders o ON c.customer_id=o.customer_id GROUP BY c.name HAVING COUNT(o.order_id)>1;


