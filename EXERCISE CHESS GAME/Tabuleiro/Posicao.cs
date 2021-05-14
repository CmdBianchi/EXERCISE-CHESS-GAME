using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EXERCISE_CHESS_GAME.Tabuleiro{
    //------------------------------- START -------------------------------//
    class Posicao {
        public int linha { get; set; }
        public int coluna { get; set; }
        //------------------------------- CONST -------------------------------//  
        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }
        //------------------------------- MET --------------------------------//
        public override string ToString() {
            return linha + ", " + coluna;
        }
    }
    //-------------------------------- END -------------------------------//
}
