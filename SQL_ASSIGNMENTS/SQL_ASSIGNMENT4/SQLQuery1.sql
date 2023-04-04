CREATE FUNCTION SalesOrderDetailByCurrency
(
@SalesOrderID INT,
@CurrencyCode CHAR(5),
@Date DATE
)
RETURNS TABLE
AS RETURN
(
SELECT d.OrderQty,d.ProductID,d.UnitPrice,
d.UnitPrice*ISNULL(r.AverageRate,1) AS ConvertedUnitPrice
FROM Sales.SalesOrderDetail AS d
INNER JOIN Sales.SalesOrderHeader AS h 
ON d.SalesOrderID=h.SalesOrderID
LEFT JOIN Sales.CurrencyRate AS r
ON h.CurrencyRateID=r.CurrencyRateID
WHERE d.SalesOrderID=@SalesOrderID
AND h.OrderDate<=@Date
AND r.ToCurrencyCode=@CurrencyCode
AND r.CurrencyRateDate=@Date
)
SELECT * FROM SalesOrderDetailByCurrency(43661,'CAD','2005-07-01')

