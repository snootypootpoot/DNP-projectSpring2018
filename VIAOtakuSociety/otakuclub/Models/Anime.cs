using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OtakuClub.Models
{
    public class Anime
    {
        public int animeID { get; set; }
        public String title { get; set; }
        public String imageLink { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}