using tabuleiro;
using xadrez_console;
namespace xadres {
    //------------------------------- START -------------------------------//
    class Rei : Peca {
        public Rei(Tabuleiro tab, Cor cor): base(tab, cor) {    
        }

        public override string ToString() {
            return "R"; 
        }
    }
    //-------------------------------- END -------------------------------//
}
