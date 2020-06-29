using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocArmarios.Models
{
    public class Armario
    {
        public Armario()
        {
            ArmarioAlunos = new List<ArmarioAluno>();
        }
        public int Id { get; set; }
        public int Bloco { get; set; }
        public int Numero { get; set; }

        public ICollection<ArmarioAluno> ArmarioAlunos {get;set;}
    }
}