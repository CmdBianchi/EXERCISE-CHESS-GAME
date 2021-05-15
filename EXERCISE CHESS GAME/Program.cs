using System;
using tabuleiro;
using xadrez_console;
using xadres;
namespace EXERCISE_CHESS_GAME {
    //-----> START
    ////////////////////////////////////////////////////////////////////////////////////////////
    class Program {
        static void Main(string[] args) {
            try {
                Tabuleiro tab = new Tabuleiro(8, 8);
    
                    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 2));
                    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
                    tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 1));

                    Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e){
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////
    //-----> END
}
