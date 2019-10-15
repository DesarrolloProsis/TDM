using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDM.Models
{
    public class ArticuloTag
    {
        public int IdTag { get; set; }
        public int IdArticle { get; set; }


        public virtual Tags  Tags{ get; set; }
        public virtual Articles Articles{ get; set; }
    }
}