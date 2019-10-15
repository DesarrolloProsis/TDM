using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDM.Models
{
    public class Tags
    {

        public int IdTag { get; set; }
        public string NombreTag { get; set; }

        public virtual ICollection<ArticuloTag> ArticuloTags { get; set; }

    }
}