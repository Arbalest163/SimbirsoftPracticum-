
SELECT 
CONCAT(p.FirstName, ' ', p.LastName, ' ', p.MiddleName) as HumanName,
COUNT(*) as BookCount,
SUM(DATEDIFF(day, lc.TakenDate, SYSDATETIMEOFFSET())) as DelayCount
FROM library_card as lc
JOIN person as p ON p.Id = lc.PersonId
GROUP BY CONCAT(p.FirstName, ' ', p.LastName, ' ', p.MiddleName)