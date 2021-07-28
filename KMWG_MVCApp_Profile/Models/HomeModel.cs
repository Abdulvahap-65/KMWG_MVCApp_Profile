using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMWG_MVCApp_Profile.Models
{
    public class HomeModel
    {
        public string Title { get; set; }
        public List<string> Items { get; set; }
        public DateTime Date { get; set; }
    }
}