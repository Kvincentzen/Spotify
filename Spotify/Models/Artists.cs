using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Artists
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Songs> Songs { get; set;  }
        public virtual ICollection<Albums> Albums { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
