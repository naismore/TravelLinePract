SELECT * FROM characters INNER JOIN players ON players.id = characters.player_id;
SELECT * FROM characters LEFT JOIN players ON players.id = characters.player_id;
SELECT * FROM characters RIGHT JOIN players ON players.id = characters.player_id;