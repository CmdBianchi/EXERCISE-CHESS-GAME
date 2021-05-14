using System;
using tabuleiro;
using xadrez_console;

namespace EXERCISE_CHESS_GAME {
    //-----> START
    ////////////////////////////////////////////////////////////////////////////////////////////
    class Program {
        static void Main(string[] args) {

            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.imprimirTabuleiro(tab);

            
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////
    //-----> END
}
