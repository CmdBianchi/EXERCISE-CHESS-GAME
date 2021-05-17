namespace tabuleiro {
    abstract class Peca {
        //------------------------------- START -------------------------------//
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int  qteMovimentos  { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        //------------------------------- CONST -------------------------------//
        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }
        //------------------------------- MET -------------------------------//
        public void incrementarQteMovimentos() {
            qteMovimentos++;
        }
        public abstract bool[,] movimentosPossiveis() { 

        }

        //-------------------------------- END -------------------------------//
    }
}
