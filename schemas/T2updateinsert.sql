USE Zoo;
UPDATE dbo.Pracownik SET Nazwisko = 'Kowalska' WHERE IdPracownika = 2;

UPDATE dbo.Zwierze SET DataZgonu = '05-Nov-18' WHERE IdZwierzecia = 1;
UPDATE dbo.Zwierze SET DataZgonu = '06-Nov-18' WHERE IdZwierzecia = 5;
UPDATE dbo.Zwierze SET DataZgonu = '07-Nov-18' WHERE IdZwierzecia = 10;

UPDATE dbo.Zwierze SET Opis = 'Uwaga! Agresywne!' WHERE IdZwierzecia = 7;

INSERT INTO Pracownik VALUES
('Krzysztof', 'Krawczyk', 1, '07-Nov-2018'),
('Marcin', 'Najman', 2, '07-Nov-2018')

INSERT INTO Wizyta VALUES
(2, 5, 230.50, 'Podano super lek, proszê dbaæ o zwierzê!', '07-Nov-2018 12:00:00'),
(2, 3, 550.25, 'Podano antybiotyk, zwierzê powinno mieæ ogrzewan¹ klatkê.', '07-Nov-2018 12:30:00')

INSERT INTO Zdarzenie VALUES
(1, 10, '07-Nov-2018 13:00:00'),
(1, 10, '07-Nov-2018 13:00:00')

INSERT INTO ZdarzeniePracownik VALUES
(1, 1),
(2, 1)