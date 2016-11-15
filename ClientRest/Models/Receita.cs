using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WsReceita.Models
{
    public class Receita
    {
        public Receita()
        {
            Medico = new Medico();
            Paciente = new Paciente();
            ItensReceita = new List<Item>();
        }

        public int NumReceita { get; set; }

        public DateTime Data { get; set; }

        public string Cpf { get; set; }
        public string Crm { get; set; }

        public Medico Medico { get; set; }
        
        public Paciente Paciente { get; set; }

        public List<Item> ItensReceita { get; set; }

        public bool Utilizada { get; set; }

        public bool Cancelada { get; set; }

    }
}