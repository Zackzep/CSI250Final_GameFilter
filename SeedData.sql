INSERT INTO Genres (Name)
VALUES
    ('Strategy'),
    ('Party'),
    ('Cooperative'),
    ('Deck Building'),
    ('Worker Placement'),
    ('Role-playing'),
    ('Puzzle'),
    ('Adventure'),
    ('Card Game'),
    ('Trivia'),
    ('Sports'),
    ('Educational'),
    ('Hidden Role'),
    ('Science Fiction'),
    ('Fantasy'),
    ('Abstract'),
    ('Dexterity'),
    ('Negotiation'),
    ('Civilization'),
    ('Horror');

	INSERT INTO Publishers (Name, City, Country)
VALUES
    ('Asmodee', 'Paris', 'France'),
    ('Fantasy Flight Games', 'Roseville', 'United States'),
    ('Ravensburger', 'Ravensburg', 'Germany'),
    ('Z-Man Games', 'Newton', 'United States'),
    ('GMT Games', 'Hanford', 'United States'),
    ('Stonemaier Games', 'St. Louis', 'United States'),
    ('Cephalofair Games', 'Lafayette', 'United States'),
    ('IELLO', 'Nantes', 'France'),
    ('Days of Wonder', 'Issy-les-Moulineaux', 'France'),
    ('WizKids', 'Hillside', 'United States');

	INSERT INTO BoardGames (Title, PlayerCount, ReleaseYear, Complexity, Cost, PublisherId, GenreId)
VALUES
    ('Ticket to Ride', 2, 2004, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Catan', 3, 1995, 4, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Pandemic', 2, 2008, 4, 44.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Splendor', 2, 2014, 2, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Codenames', 4, 2015, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('7 Wonders', 3, 2010, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Azul', 4, 2017, 2, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Scythe', 5, 2016, 5, 79.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Terraforming Mars', 1, 2016, 4, 59.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Kingdomino', 4, 2016, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Ticket to Ride: Europe', 2, 2005, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Carcassonne', 2, 2000, 2, 34.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Dominion', 2, 2008, 3, 44.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Catan: Cities & Knights', 3, 1998, 4, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Codenames: Pictures', 4, 2016, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Ticket to Ride: Nordic Countries', 2, 2007, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Catan: Seafarers', 3, 1997, 4, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Splendor: Cities of Splendor', 2, 2017, 2, 24.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Pandemic Legacy: Season 1', 2, 2015, 4, 69.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('7 Wonders Duel', 2, 2015, 2, 29.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Azul: Stained Glass of Sintra', 4, 2018, 2, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Scythe: The Rise of Fenris', 5, 2018, 5, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Terraforming Mars: Prelude', 1, 2018, 4, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Kingdomino: Age of Giants', 4, 2018, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Sushi Go!', 2, 2013, 1, 14.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Agricola', 2, 2007, 4, 59.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Tapestry', 4, 2019, 4, 89.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Root', 4, 2018, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Gloomhaven', 4, 2017, 5, 139.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Everdell', 4, 2018, 3, 49.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Wingspan', 2, 2019, 2, 59.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Dead of Winter', 4, 2014, 4, 54.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Betrayal at House on the Hill', 3, 2004, 3, 44.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Arkham Horror: The Card Game', 1, 2016, 4, 39.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Scrabble', 2, 1938, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Chess', 2, 600, 3, 9.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Risk', 2, 1957, 4, 29.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Monopoly', 2, 1935, 3, 24.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Clue', 3, 1949, 2, 19.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1),
    ('Battleship', 2, 1967, 2, 14.99, FLOOR(RAND() * 10) + 1, FLOOR(RAND() * 20) + 1);
