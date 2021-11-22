
SELECT 
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
g.Name,
COUNT(*) AS count
FROM author as a
JOIN book as b ON b.AuthorId = a.Id
JOIN book_genre as bg ON bg.BookId = b.Id
JOIN genre as g ON bg.GenreId = g.Id
GROUP BY CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName), g.Name
ORDER BY AuthorName