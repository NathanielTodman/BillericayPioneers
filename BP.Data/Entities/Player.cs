﻿using System.Collections.Generic;

namespace BP.Data
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string NickName { get; set; }
        public int Number { get; set; }
        public Position DefaultPosition { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Performance> Performances { get; set; }
    }
}
