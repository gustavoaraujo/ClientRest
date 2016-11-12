using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WsReceita.Models
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public List<Receita> Receitas { get; set; }
    }
}