SELECT nickname FROM players WHERE id = 4;
SELECT TOP 3 * FROM characters;
SELECT * FROM characters ORDER BY name;
SELECT * FROM characters WHERE money > 1000 AND level > 2;
SELECT * FROM characters WHERE heath > 100 AND armor = 0;
SELECT * FROM characters WHERE money > 1000 ORDER BY money;
SELECT * FROM characters WHERE level BETWEEN 5 AND 10;
SELECT * FROM characters WHERE level NOT BETWEEN 5 AND 10;