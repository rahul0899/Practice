SELECT P.Name,P.Color,P.Weight
FROM Production.Product P
WHERE P.Weight=
(
SELECT MAX(Weight)
FROM Production.Product
);
