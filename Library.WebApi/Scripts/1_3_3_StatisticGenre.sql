SELECT g.Name, Count(*)
FROM genre as g
JOIN book_genre as bg ON bg.GenreId = g.Id
GROUP BY g.Name