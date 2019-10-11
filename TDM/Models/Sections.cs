using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDM.Models
{
    public class Sections
    {
        public int IdSection { get; set; }
        public string Nombre { get; set; }

        //FK
        public virtual ICollection<Articles> Articles { get; set; }

    }
}