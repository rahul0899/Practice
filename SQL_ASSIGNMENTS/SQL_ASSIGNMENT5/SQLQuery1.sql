CREATE PROCEDURE GetPersonNames  @firstName VARCHAR(50)=NULL
AS
BEGIN
SElECT FirstName,LastName FROM Person.Person
WHERE (@firstName IS NULL OR FirstName LIKE'%'+@firstName+'%')
END
EXECUTE GetPersonNames @firstName='Jodi'
