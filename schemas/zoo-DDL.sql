USE Zoo;

CREATE TABLE Stanowisko
(
	IdStanowiska INT IDENTITY(1, 1) PRIMARY KEY,
	Opis NVARCHAR(50) NOT NULL
)

CREATE TABLE Gatunek
(
	IdGatunku INT IDENTITY(1, 1) PRIMARY KEY,
	Opis NVARCHAR(50) NOT NULL
)

CREATE TABLE Zwierze
(
	IdZwierzecia INT IDENTITY(1, 1) PRIMARY KEY,
	Opis NVARCHAR(50) NOT NULL,
	IdGatunku INT FOREIGN KEY REFERENCES Gatunek(IdGatunku) NOT NULL,
	DataZgonu DATE
)

CREATE TABLE TypZdarzenia
(
	IdTypuZdarzenia INT IDENTITY(1, 1) PRIMARY KEY,
	Opis NVARCHAR(50) NOT NULL
)

CREATE TABLE Weterynarz
(
	IdWeterynarza INT IDENTITY(1, 1) PRIMARY KEY,
	Imie NVARCHAR(50) NOT NULL,
	Nazwisko NVARCHAR(50) NOT NULL,
	NumerTelefonu CHAR(11) NOT NULL
)

CREATE TABLE Pracownik
(
	IdPracownika INT IDENTITY(1, 1) PRIMARY KEY,
	Imie NVARCHAR(50) NOT NULL,
	Nazwisko NVARCHAR(50) NOT NULL,
	IdStanowiska INT FOREIGN KEY REFERENCES Stanowisko(IdStanowiska) NOT NULL,
	DataZatrudnienia DATE NOT NULL
);

CREATE TABLE Wizyta
(
	IdWizyty INT IDENTITY(1, 1) PRIMARY KEY,
	IdWeterynarza INT NOT NULL FOREIGN KEY REFERENCES Weterynarz(IdWeterynarza),
	IdZwierzecia INT NOT NULL FOREIGN KEY REFERENCES Zwierze(IdZwierzecia),
	Koszt FLOAT NOT NULL,
	Opis NVARCHAR(2000) NOT NULL,
	Czas DATETIME NOT NULL

)

CREATE TABLE Zdarzenie
(
	IdZdarzenia INT IDENTITY(1, 1) PRIMARY KEY,
	IdTypuZdarzenia INT NOT NULL FOREIGN KEY REFERENCES TypZdarzenia(IdTypuZdarzenia),
	IdZwierzecia INT NOT NULL FOREIGN KEY REFERENCES Zwierze(IdZwierzecia),
	Czas DATETIME NOT NULL
)

CREATE TABLE ZdarzeniePracownik
(
	IdPracownika INT NOT NULL FOREIGN KEY REFERENCES Pracownik(IdPracownika),
	IdZdarzenia INT NOT NULL FOREIGN KEY REFERENCES Zdarzenie(IdZdarzenia),
	PRIMARY KEY(IdPracownika, IdZdarzenia)
)
