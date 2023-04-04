SELECT c.*
FROM Sales.Customer AS c
LEFT JOIN Sales.SalesOrderHeader AS o
ON c.CustomerID=o.CustomerID
WHERE o.CustomerID IS NULL;

