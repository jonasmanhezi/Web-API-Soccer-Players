using JogadoresApi.Context;
using JogadoresApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogadoresApi.Services
{
    public class JogadoresService : IJogadorService
    {
        private readonly AppDbContext _context;

        public JogadoresService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJogador(Jogador jogador)
        {
            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogador> GetJogador(int id)
        {
            var jogador = await _context.Jogadores.FindAsync(id);
            return jogador;
        }

        public async Task<IEnumerable<Jogador>> GetJogadores()
        {
            try
            {
                return await _context.Jogadores.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Jogador>> GetJogadoresByNome(string nome)
        {
            IEnumerable<Jogador> jogadores;
            if(!string.IsNullOrWhiteSpace(nome))
            {
                jogadores = await _context.Jogadores.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                jogadores = await GetJogadores();
            }
            return jogadores;
        }

        public async Task UpdateJogador(Jogador jogador)
        {
            _context.Entry(jogador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
