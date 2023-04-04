ALTER PROCEDURE GetPersonNames
    @firstName NVARCHAR(50) = NULL,
    @lastName NVARCHAR(50) = NULL
AS
BEGIN
IF @firstName IS NULL SET @firstName = '%'
IF @lastName IS NULL SET @lastName = '%'
SELECT FirstName, MiddleName, LastName
FROM Person.Person
WHERE FirstName LIKE @firstName
AND LastName LIKE @lastName
END