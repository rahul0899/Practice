WITH TotalSpent AS
(
SELECT  c.CustomerID, SUM(LineTotal) AS TotalSpent
FROM  Sales.SalesOrderDetail d
JOIN Sales.SalesOrderHeader h ON d.SalesOrderID = h.SalesOrderID
JOIN Sales.Customer c ON h.CustomerID = c.CustomerID
GROUP BY c.CustomerID
HAVING SUM(LineTotal)>70000
)
SELECT TOP 5 o.SalesOrderID as OrderID, o.OrderDate, c.AccountNumber, c.CustomerID, s.TotalSpent
FROM Sales.SalesOrderHeader o
JOIN Sales.Customer c ON o.CustomerID = c.CustomerID
JOIN TotalSpent s ON c.CustomerID = s.CustomerID
ORDER BY o.OrderDate DESC;