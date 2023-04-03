SELECT * FROM Sales.Customer
WHERE CustomerID NOT IN
(
SELECT CustomerID FROM Sales.SalesOrderHeader
)