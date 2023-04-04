SELECT p.FirstName, p.LastName, e.JobTitle
FROM HumanResources.Employee e JOIN Person.Person p
ON p.BusinessEntityID=e.BusinessEntityID
WHERE e.JobTitle IN('Design Engineer', 'Tool Designer', 'Marketing Assistant');