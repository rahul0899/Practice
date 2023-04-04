CREATE TRIGGER ProductListPrice
ON Production.Product
AFTER UPDATE
AS
BEGIN
IF UPDATE(ListPrice)
BEGIN
DECLARE @MaxPercentChange decimal(5,2) = 0.15;
DECLARE @OldListPrice money, @NewListPrice money;
SELECT @OldListPrice = ListPrice FROM inserted;
SELECT @NewListPrice = ListPrice FROM deleted;       
IF (@NewListPrice > (@OldListPrice * (1 + @MaxPercentChange)))
BEGIN
RAISERROR('List price cannot be raised more than 15 percent in a single change.', 16, 1);
ROLLBACK TRANSACTION;
END
END
END;
SELECT * FROM sys.triggers WHERE name='ProductListPrice';