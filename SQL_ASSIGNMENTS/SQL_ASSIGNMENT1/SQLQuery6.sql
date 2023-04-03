SELECT AVG(AverageRate) As AverageExchangeRateForTheDay 
FROM Sales.CurrencyRate
WHERE FromCurrencyCode='USD'
AND ToCurrencyCode='GBP'
AND YEAR(CurrencyRateDate)=2005;