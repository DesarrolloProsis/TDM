using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDM.Models
{
    public class Articles
    {
        [Key]
        public int IdArticle { get; set; }
        public string URL { get; set; }
        public DateTime Fecha{ get; set; }
        public string Nombre{ get; set; }
        public string Body { get; set; }
        public string ImgURL { get; set; }
        public int IdUser { get; set; }
        public int IdSection{ get; set; }

        //FK
        public virtual Users Users{ get; set; }
        public virtual Sections Sections { get; set; }

    }
}