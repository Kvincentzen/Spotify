using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Artists Artists { get; set; }
        public virtual Albums Albums { get; set; }


    }
}
