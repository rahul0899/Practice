SELECT FirstName,LastName,
ROW_NUMBER() OVER (ORDER BY FirstName) As RowNumber
From Person.Person
WHERE FirstName LIKE '%ss%';