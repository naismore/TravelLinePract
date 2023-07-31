using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MySQL
{
    class Program
    {
        private static List<string> _commandsList = new List<string>()
        {
            "add-player [NickName] [ServerID]",
            "remove-player [NickName]",
            "add-character [CharName]",
            "remove-character [CharName]",
            "add-server [ServerName]",
            "remove-server [ServerName]",
            "player-edit-nickname [Old NickName] [New NickName]",
            "server-edit-name [Old Name] [New Name]",
            "character-edit-money [Money]",
            "character-edit-level [Level]",
            "character-edit-age [Age]",
            "character-edit-health [Health]",
            "character-edit-armor [Armor]",
        };

        static void Main(string[] args)
        {
            while (true)
            {
                ShowCommands();
                SelectCommand();
            }
        }

        public static void ShowCommands()
        {
            Console.WriteLine("Commands:");
            foreach (string command in _commandsList)
            {
                Console.WriteLine($"  {command}");
            }
        }
        
        public static void SelectCommand()
        {
            Console.Write("EnterCommand: ");
            string[] commandString = Console.ReadLine().Split(' ');
            string command = commandString[0];
            List<string> parameterList = commandString.Skip(1).ToList();
            switch (command)
            {
                case "add-player":
                    AddPlayer(parameterList);
                    break;
                case "remove-player": 
                    RemovePlayer(parameterList); 
                    break;
                case "add-character":
                    AddCharacter(parameterList);
                    break;
                case "remove-character":
                    RemoveCharacter(parameterList);
                    break;
                case "add-server":
                    AddServer(parameterList);
                    break;
                case "remove-server":
                    RemoveServer(parameterList);
                    break;
                case "player-edit-nickname":
                    PlayerEditNickname(parameterList);
                    break;
                case "server-edit-name":
                    ServerEditName(parameterList);
                    break;
                case "character-edit-money":
                    CharacterEditMoney(parameterList);
                    break;
                case "character-edit-level":
                    CharacterEditLevel(parameterList);
                    break;
                case "character-edit-age":
                    CharacterEditAge(parameterList);
                    break;
                case "character-edit-health":
                    CharacterEditHealth(parameterList);
                    break;
                case "character-edit-armor":
                    CharacterEditArmor(parameterList);
                    break;
                default:
                    Console.WriteLine("Error: Command not found!");
                    break;
            }

        }
        

        //PLAYERS

        public static void AddPlayer(List<string> parameterList) // Добавление игрока в БД
        {
            if(int.TryParse(parameterList[1], out int serverID)) 
            {
                using (var db = new MyDbContext())
                {
                    string gettedplayerName = parameterList[0];
                    if (!db.Players.Any(pl => pl.Nickname == gettedplayerName)) // Проверка на существование игрока с таким ником
                    {
                        var player = new Player()
                        {
                            Nickname = parameterList[0],
                            ServerID = serverID
                        };
                        db.Players.Add(player);
                        Console.WriteLine("\nInfo: Adding a player to the database...");
                        try
                        {
                            db.SaveChanges();
                            Console.WriteLine("Info: Changes saved successfully!\n");
                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException)
                        {
                            Console.WriteLine("Error: There is no server with this ID!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: A player with this nickname already exists\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nError: ServerID must be integer!\n");
            }
        }

        public static void RemovePlayer(List<string> parameterList) // Удаление игрока из БД
        {
            using ( var db = new MyDbContext())
            {
                string gettedplayerName = parameterList[0];
                if (db.Players.Any(pl => pl.Nickname == gettedplayerName))
                {
                    var player = db.Players.Where(pl => pl.Nickname == gettedplayerName).FirstOrDefault();
                    db.Players.Remove(player);
                    Console.WriteLine("\nInfo: Removing player from database...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no player with this nickname!\n");
                }
            }
        }

        public static void PlayerEditNickname(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedplayerName = parameterList[0];
                if (db.Players.Any(pl => pl.Nickname == gettedplayerName))
                {
                    var player = db.Players.Where(pl => pl.Nickname == gettedplayerName).FirstOrDefault();
                    player.Nickname = parameterList[1];
                    Console.WriteLine("\nInfo: Changing player nickname...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no player with this nickname!\n");
                }
            }
        }

        

        //CHARACTERS

        public static void AddCharacter(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (!db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = new Character();
                    while (true)
                    {
                        character.CharName = gettedcharacterName;
                        Console.WriteLine("\nInfo: The character must be attached to some player. Enter the ID of the player you want to link the character to.");
                        Console.Write("Enter player ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int playerID))
                        {
                            Console.WriteLine("Error: Player ID must be a integer!\n");
                        }
                        else
                        {
                            character.PlayerID = playerID;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Enter character age: ");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("Error: Character age must be a integer!\n");
                        }
                        else
                        {
                            character.Age = age;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Enter a character sex! (0 - woman, 1 - man): ");
                        if (!int.TryParse(Console.ReadLine(), out int sex))
                        {
                            Console.WriteLine("Error: Character sex must be a integer!\n");
                        }
                        else
                        {
                            character.Sex = sex;
                            break;
                        }
                    }
                    Console.Write("Enter a character level! (default - 1): ");
                    if (int.TryParse(Console.ReadLine(), out int level))
                    {
                        character.CharLevel = level;
                    }
                    else
                    {
                        character.CharLevel = 1;
                    }
                    Console.Write("Enter a character money! (default - 500$): ");
                    if (int.TryParse(Console.ReadLine(), out int money))
                    {
                        character.Money = money;
                    }
                    else
                    {
                        character.Money = 500;
                    }
                    character.Health = 100;
                    character.Armor = 100;

                    db.Characters.Add(character);
                    Console.WriteLine("Info: Adding a character to the database...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        Console.WriteLine("Error: There is no player with this ID!\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nError: A character with this nickname already exists\n");
                }
            }
        }

        public static void RemoveCharacter(List<string> parameterList) // Удаление игрока из БД
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    db.Characters.Remove(character);
                    Console.WriteLine("\nInfo: Removing character from database...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        public static void CharacterEditMoney(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    if(!int.TryParse(parameterList[1], out int money))
                    {
                        Console.WriteLine("\nError: The character's money must be a integer!");
                    }
                    else
                    {
                        character.Money = money;
                    }
                    Console.WriteLine("\nInfo: Changing character money...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        public static void CharacterEditLevel(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    if (!int.TryParse(parameterList[1], out int level))
                    {
                        Console.WriteLine("\nError: The character's level must be a integer!");
                    }
                    else
                    {
                        character.CharLevel = level;
                    }
                    Console.WriteLine("\nInfo: Changing character level from database...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        public static void CharacterEditAge(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    if (!int.TryParse(parameterList[1], out int age))
                    {
                        Console.WriteLine("\nError: The character's age must be a integer!");
                    }
                    else
                    {
                        character.Age = age;
                    }
                    Console.WriteLine("\nInfo: Changing character age...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        public static void CharacterEditHealth(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    if (!int.TryParse(parameterList[1], out int health))
                    {
                        Console.WriteLine("\nError: The character's health must be a integer!");
                    }
                    else
                    {
                        character.Health = health;
                    }
                    Console.WriteLine("\nInfo: Changing character health...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        public static void CharacterEditArmor(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedcharacterName = parameterList[0];
                if (db.Characters.Any(ch => ch.CharName == gettedcharacterName))
                {
                    var character = db.Characters.Where(ch => ch.CharName == gettedcharacterName).FirstOrDefault();
                    if (!int.TryParse(parameterList[1], out int armor))
                    {
                        Console.WriteLine("\nError: The character's armor must be a integer!");
                    }
                    else
                    {
                        character.Armor = armor;
                    }
                    Console.WriteLine("\nInfo: Changing character armor...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no character with this nickname!\n");
                }
            }
        }

        //SERVERS

        public static void AddServer(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                var server = new Server()
                {
                    ServerName = parameterList[0]
                };
                db.Servers.Add(server);
                Console.WriteLine("Info: Adding a server to the database...");
                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Info: Changes saved successfully!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void RemoveServer(List<string> parameterList) // Удаление игрока из БД
        {
            using (var db = new MyDbContext())
            {
                string gettedserverName = parameterList[0];
                if (db.Servers.Any(sr => sr.ServerName == gettedserverName))
                {
                    var server = db.Servers.Where(sr => sr.ServerName == gettedserverName).FirstOrDefault();
                    db.Servers.Remove(server);
                    Console.WriteLine("\nInfo: Removing server from database...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no server with this nickname!\n");
                }
            }
        }

        public static void ServerEditName(List<string> parameterList)
        {
            using (var db = new MyDbContext())
            {
                string gettedserverName = parameterList[0];
                if (db.Servers.Any(sr => sr.ServerName == gettedserverName))
                {
                    var server = db.Servers.Where(sr => sr.ServerName == gettedserverName).FirstOrDefault();
                    server.ServerName = parameterList[1];
                    Console.WriteLine("\nInfo: Changing server name...");
                    try
                    {
                        db.SaveChanges();
                        Console.WriteLine("Info: Changes saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\n Error: There is no server with this nickname!\n");
                }
            }
        }

    }
}
