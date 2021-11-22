SELECT b.Title as BookTitle,
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
[dbo].[GET_GENRES_BY_BOOK_ID](b.Id) as Genres
FROM library_card as lc
JOIN [dbo].book as b ON lc.BookId = b.Id
JOIN [dbo].author as a ON b.AuthorId = a.Id
WHERE PersonId = '7315A12D-7CFA-4DED-AA20-23C4178DA001'