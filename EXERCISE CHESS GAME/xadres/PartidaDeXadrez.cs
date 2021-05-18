using System;
using tabuleiro;
using System.Collections.Generic;
namespace xadres {
    //------------------------------- START -------------------------------//
    class PartidaDeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez () {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem , Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }

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
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (tab.peca(origem).podeMoverPara(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
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
        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) { 
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmjogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in pecas) { 
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
        }

        private void colocarPecas() {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 5).toPosicao());
        }
    }
    //-------------------------------- END -------------------------------//
}
