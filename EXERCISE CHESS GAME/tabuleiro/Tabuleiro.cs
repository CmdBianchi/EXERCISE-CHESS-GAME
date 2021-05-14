using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EXERCISE_CHESS_GAME.tabuleiro {
    class Tabuleiro {
        //------------------------------- START -------------------------------//
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;
        //------------------------------- CONST -------------------------------//  
        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        //------------------------------- MET --------------------------------//

    }
}
