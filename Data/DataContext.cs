using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Marcos",
                    Email = "marcos@teste.com",
                    Idade = 30
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "Jess",
                    Email = "jess@teste.com",
                    Idade = 21
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}