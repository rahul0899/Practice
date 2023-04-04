SELECT BusinessEntityID,
CASE
WHEN CommissionPct=0 THEN 'Band 0'
WHEN CommissionPct<=0.01 THEN 'Band 1'
WHEN CommissionPct<=0.015 THEN 'Band 2'
ELSE 'Band 3'
END AS[Commission Band]
FROM Sales.SalesPerson
