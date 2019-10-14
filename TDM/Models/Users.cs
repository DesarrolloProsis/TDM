using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDM.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName{ get; set; }
        public string Nombre{ get; set; }
        public string Apellido{ get; set; }
        public string URL { get; set;}

        //FK
        public virtual ICollection<Articles> Articles { get; set; }

    }
}