using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadApiCSharp.Models
{
    public class Request
    {
        public string AppID { get; set; }
        public string ApiKey { get; set; }
        public string AccountId { get; set; }
    }
    public class PlaylistViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }
}
