using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Models;

namespace AlunosApi.Contracts
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ObterListaAlunos();
        Task<IEnumerable<Aluno>> ObterListaAlunosPeloNome(string Nome);
        Task<Aluno> ObterAlunoPeloId(int Id);
        Task CriarAluno(Aluno aluno);
        Task EditarAluno(Aluno aluno);
        Task<dynamic> RemoverAluno(int Id);
    }
}