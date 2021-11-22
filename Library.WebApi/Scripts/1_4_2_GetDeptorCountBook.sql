
SELECT 
CONCAT(p.FirstName, ' ', p.LastName, ' ', p.MiddleName) as PersonName,
COUNT(*) as BookCount
FROM library_card as lc
JOIN person as p ON p.Id = lc.PersonId
GROUP BY CONCAT(p.FirstName, ' ', p.LastName, ' ', p.MiddleName)
HAVING COUNT(*) > 3