using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WsReceita.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int NumReceita { get; set; }
        public Receita Receita { get; set; }
        public int RegAnvisa { get; set; }
        public string Instrucao { get; set; }
        public string Nome { get; set; }
        public string Uso { get; set; }
        public string ContraIndicacao { get; set; }
    }
}