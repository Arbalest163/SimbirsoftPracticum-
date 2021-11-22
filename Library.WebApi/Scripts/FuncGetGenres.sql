USE [MyLibrary21]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION GET_GENRES_BY_BOOK_ID
(
	@book_id [uniqueidentifier]
)
RETURNS varchar(8000)
AS
BEGIN
	DECLARE @Genres varchar(8000)
	SELECT @Genres = COALESCE(@Genres + ', ', '') + Name
	FROM dbo.genre
	JOIN dbo.book_genre as bg ON bg.GenreId = GenreId
	WHERE @book_id = bg.BookId

	RETURN COALESCE(@Genres, 'No genres')

END
GO