WITH CTE_CustomersWithoutOrders AS
(
SELECT CustomerID FROM Sales.Customer
EXCEPT
SELECT CustomerID FROM Sales.SalesOrderHeader
)
SELECT * FROM Sales.Customer
WHERE CustomerID IN
(
SELECT CustomerID FROM CTE_CustomersWithoutOrders
);