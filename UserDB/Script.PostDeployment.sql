-- This file contains SQL statements that will be executed after the build script.

IF NOT EXISTS (SELECT 1 FROM dbo.[User])
BEGIN
    INSERT INTO dbo.[User] (FirstName, LastName)
    VALUES ('Rudz', 'Mofokeng'),
    ('Prince', 'Banda'),
    ('Neyo', 'Kaktie'),
    ('Sbosh', 'Dawgen');
END
