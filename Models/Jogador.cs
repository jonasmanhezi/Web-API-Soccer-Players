using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JogadoresApi.Models
{
    [Table("Jogadores")]
    public class Jogador
    {
        [Key]
        public int Id { get; set; }
 

        public string Nome { get; set; }


        public string Posição { get; set; }


        public int Idade { get; set; }

        public string TimeAtual { get; set; }
  
        public int Valor { get; set; }
    }
}
