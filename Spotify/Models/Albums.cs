using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Albums
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual Artists Artists { get; set; }
        public virtual Songs Songs { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
