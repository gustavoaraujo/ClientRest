using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WsReceita.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Crm { get; set; }
        public Medico Medico { get; set; }
    }
}