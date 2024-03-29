using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AlunosApi.Contracts;
using AlunosApi.Data;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly DataContext _context;
        public AlunoService(DataContext context)
        {
            _context = context;
        }
        public async Task CriarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Aluno>> ObterListaAlunos()
        {
            var alunos = await _context.Alunos.AsNoTracking().ToListAsync();
            return alunos;
        }
        public async Task<Aluno> ObterAlunoPeloId(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            if (aluno is null) throw new Exception("Não foi possível encontrar o aluno");
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> ObterListaAlunosPeloNome(string Nome)
        {
            IEnumerable<Aluno> alunos;
            if (!string.IsNullOrEmpty(Nome))
            {
                alunos = await _context.Alunos.Where(a => a.Nome.Contains(Nome)).ToListAsync();
            }
            else
            {
                alunos = await ObterListaAlunos();
            }

            return alunos;
        }

        public async Task EditarAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<dynamic> RemoverAluno(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            if (aluno is null)
                throw new Exception("Não foi possível encontrar o aluno");
            
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return "Aluno removido com sucesso";
        }
    }
}