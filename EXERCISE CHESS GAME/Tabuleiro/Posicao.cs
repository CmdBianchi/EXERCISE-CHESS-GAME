namespace tabuleiro{
    //------------------------------- START -------------------------------//
    class Posicao {
        public int linha { get; set; }
        public int coluna { get; set; }
        //------------------------------- CONST -------------------------------//  
        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }
        public void definirValores(int linha, int coluna) {
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
