using tabuleiro;
namespace xadres {
    //------------------------------- START -------------------------------//
    class PosicaoXadrez {
        public char coluna { get; set; }
        public int linha { get; set; }
        //------------------------------- CONST -------------------------------//
        public PosicaoXadrez(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }
        //------------------------------- MET -------------------------------//
        public Posicao toPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }
        
        public override string ToString() {
            return "" + coluna + linha;
        }
    }
    //-------------------------------- END -------------------------------//
}
