CREATE TABLE Cows (
	"id" UUID PRIMARY KEY,
	"collarId" integer UNIQUE NOT NULL,
	"cowNumber" integer NOT NULL
);