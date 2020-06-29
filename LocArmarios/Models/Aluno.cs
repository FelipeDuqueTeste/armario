using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocArmarios.Models
{
    public class Aluno
    {
        public Aluno()
        {
            ArmarioAlunos = new List<ArmarioAluno>();
        }
        public int Id { get; set; }
        public decimal Ra { get; set; }
        public string Nome { get; set; }

        public ICollection<ArmarioAluno> ArmarioAlunos { get; set; }
    }
}