using LocArmarios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LocArmarios.Context
{
    public class Context :  DbContext
    {
        public Context():base("ArmarioDB")
        {
            Database.SetInitializer<Context>(null);

          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Armario> Armario { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<ArmarioAluno> ArmarioAlunos { get; set; }
    }
}