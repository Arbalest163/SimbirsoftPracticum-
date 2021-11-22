SELECT
CONCAT(a.FirstName, ' ', a.LastName, ' ', a.MiddleName) as AuthorName,
b.Title,
dbo.GET_GENRES_BY_BOOK_ID(b.Id) as Genres
FROM author as a
JOIN book as b ON b.AuthorId = a.Id
WHERE a.Id = '58E28745-CD58-4530-BE80-08D9AD8FBEBC'