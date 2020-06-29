using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LocArmarios.Models
{
    public class ArmarioAluno
    {
        public int Id { get; set; }

        [DisplayName("Aluno")]
        public int AlunoId { get; set; }

        [DisplayName("Armario")]
        public int ArmarioId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataFimLocacao { get; set; }

        public Armario Armario { get; set; }
        public Aluno Aluno { get; set; }
    }
}