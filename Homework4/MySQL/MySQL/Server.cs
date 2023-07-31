using System;
using System.Collections.Generic;

namespace MySQL
{
    public class Server
    {
        public int ID { get; set; }
        public string ServerName { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
