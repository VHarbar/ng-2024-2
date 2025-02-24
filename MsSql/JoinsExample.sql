USE Store;

/* Pagination example
SELECT * FROM Category
ORDER BY Id DESC
OFFSET 2 ROWS -- skip 2
FETCH NEXT 3 ROWS ONLY -- take 3
*/

-- inner join - returns only combinations, where both entities are not null
SELECT P.*, T.* FROM Product AS P
INNER JOIN Traider AS T
ON P.TraiderId = T.Id

-- left join - returns all combinations, with traider null entities
SELECT P.*, T.* FROM Product AS P
LEFT JOIN Traider AS T
ON P.TraiderId = T.Id

-- right join - returns all combinations, with product null entities
SELECT P.*, T.* FROM Product AS P
RIGHT JOIN Traider AS T
ON P.TraiderId = T.Id

-- full join - returns all possible combinations
SELECT P.*, T.* FROM Product AS P
FULL JOIN Traider AS T
ON P.TraiderId = T.Id

-- cross join
SELECT P.*, T.* FROM Product AS P
CROSS JOIN Traider AS T

-- many to many join
SELECT P.Name, C.Description FROM ProductCategory AS PC
INNER JOIN Product AS P
ON P.Id = PC.ProductId
INNER JOIN Category AS C
ON C.Id = PC.CategoryId

