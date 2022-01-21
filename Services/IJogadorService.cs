using JogadoresApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogadoresApi.Services
{
    public interface IJogadorService
    {
        Task<IEnumerable<Jogador>> GetJogadores();
        Task<Jogador> GetJogador(int id);

        Task<IEnumerable<Jogador>> GetJogadoresByNome(string nome);

        Task CreateJogador(Jogador jogador);

        Task UpdateJogador(Jogador jogador);

        Task DeleteJogador(Jogador jogador);

    }
}
