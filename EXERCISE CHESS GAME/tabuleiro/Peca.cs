using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXERCISE_CHESS_GAME.Tabuleiro;
namespace EXERCISE_CHESS_GAME.tabuleiro {
    class Peca {
        //------------------------------- START -------------------------------//
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int  qteMovimentos  { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        //------------------------------- CONST -------------------------------//
        public Peca(Posicao posicao, Cor cor, int qteMovimentos, Tabuleiro tab) {
            this.posicao = posicao;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }
        //-------------------------------- END -------------------------------//
    }
}
