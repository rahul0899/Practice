SELECT TOP 1 ProductID
From Production.Product
ORDER BY dbo.ufnGetStock(ProductID);
