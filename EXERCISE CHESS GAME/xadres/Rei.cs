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
        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            // ACIMA
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // NE
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // DIREITA
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // SE
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // ABAIXO
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if(tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // SO
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // ESQUERDA
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // NO
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

        }
    }
    //-------------------------------- END -------------------------------//
}
