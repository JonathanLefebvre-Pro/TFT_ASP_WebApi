USE ASP_WebApi;

GO

CREATE TABLE Tasks (
    id INT IDENTITY PRIMARY KEY,
    title NVARCHAR(50) NOT NULL UNIQUE,
    creationDate DATETIME2(7) DEFAULT SYSDATETIME(),
    done bit DEFAULT 0
);

INSERT INTO Tasks (title)
VALUES
('Task 1'),('Task 2'), ('Task 3')

GO

SELECT * FROM Tasks