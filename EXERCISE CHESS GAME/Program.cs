using System;
using EXERCISE_CHESS_GAME.Tabuleiro;
namespace EXERCISE_CHESS_GAME {
    class Program {
        static void Main(string[] args) {
            Posicao P;
            P = new Posicao(3, 4);
            Console.WriteLine("Posição: "+P);

            Console.ReadLine();
        }
    }
}
