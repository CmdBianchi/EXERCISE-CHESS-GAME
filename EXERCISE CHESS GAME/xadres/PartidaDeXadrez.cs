﻿using System;
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
        private Posicao destino;

        public bool xeque { get; private set; }
        public PartidaDeXadrez () {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        public Peca executaMovimento(Posicao origem , Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if(pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }
        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce nao pode se por em xeque!");
            }
            if (estaEmXeque(adversaria(jogadorAtual))){
                xeque = true;
            }
            else {
                xeque = false;
            }
            if (testeXequemate(adversaria(jogadorAtual))) {
                terminada = true;
            }
            else {
                turno++;
                mudaJogador();
            }
        }
        private bool testeXequemate() {
            throw new NotImplementedException();
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
        public bool testeXequemate(Cor cor) { 
            if (!estaEmXeque(cor)) {
                return false;
            }
            foreach(Peca x in pecasEmjogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for(int i=0; i<tab.linhas; i++) { 
                    for(int j=0; j<tab.colunas; j++) { 
                        if(mat[i, j]) {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(x.posicao, new Posicao(i, j));
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(x.posicao, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        private Cor adversaria(Cor cor) { 
            if(cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor) { 
            foreach (Peca x in pecasEmjogo(cor)) { 
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }
        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor" + cor + "no tabuleiro!");
            }
            foreach(Peca x in pecasEmjogo(adversaria(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if(mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
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
