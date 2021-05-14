using tabuleiro;
using xadrez_console;
namespace xadres
{
    //------------------------------- START -------------------------------//
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "T";
        }
    }
    //-------------------------------- END -------------------------------//
}
