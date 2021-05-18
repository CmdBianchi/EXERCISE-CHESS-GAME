using System;
using tabuleiro;
namespace xadres {
    //------------------------------- START -------------------------------//
    class PartidaDeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }


        public PartidaDeXadrez () {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem , Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            tab.retirarPeca(destino);
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

        }
        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeorgem(Posicao pos) { 
            if(tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem");
            }
            if(jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        private void mudaJogador() { 
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }
        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
        }
    }
    //-------------------------------- END -------------------------------//
}
