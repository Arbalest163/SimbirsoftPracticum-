SELECT 
CONCAT(p.FirstName, ' ', p.LastName, ' ', p.MiddleName) as PersonName,
b.Title,
DATEDIFF(day, lc.TakenDate, SYSDATETIMEOFFSET()) as DaysGone
FROM library_card as lc
JOIN person as p ON p.Id = lc.PersonId
JOIN book as b ON b.Id = lc.BookId
WHERE DATEDIFF(day, lc.TakenDate, SYSDATETIMEOFFSET()) > 14