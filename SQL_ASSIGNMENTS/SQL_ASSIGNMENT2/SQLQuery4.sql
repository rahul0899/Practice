SELECT * FROM Sales.Customer c
WHERE NOT EXISTS
(
SELECT * FROM Sales.SalesOrderHeader AS o
WHERE o.CustomerID=c.CustomerID
)