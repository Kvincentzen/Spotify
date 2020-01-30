using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Songs
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int TrackId { get; set; }
        public virtual Artists Artists { get; set; }

    }
}
