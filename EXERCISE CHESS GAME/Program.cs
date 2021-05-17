using System;
using tabuleiro;
using xadrez_console;
using xadres;
namespace EXERCISE_CHESS_GAME {
    //-----> START
    ////////////////////////////////////////////////////////////////////////////////////////////
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosicao());

            Console.ReadLine();


        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////
    //-----> END
}
