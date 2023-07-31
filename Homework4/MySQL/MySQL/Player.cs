using System;
using System.Collections;
using System.Collections.Generic;

namespace MySQL
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int ServerID { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual Server Server { get; set; }

        public string ToString()
        {
            return $"Player:\n  ID: {Id}\n  Nickname: {Nickname}\n  ServerID: {ServerID}";
        }
    }
}
