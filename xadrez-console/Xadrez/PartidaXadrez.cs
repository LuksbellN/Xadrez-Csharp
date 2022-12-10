using System;
using tabuleiro;
using xadrez_console;
using System.Collections.Generic;

namespace Xadrez {
    class PartidaXadrez {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            Xeque = false;

            ColocarPecas();
            Terminada = false;
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQuantMovimento();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if(p is Rei && destino.Coluna - 2 == origem.Coluna) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQuantMovimento();
                Tab.ColocarPeca(T, destinoT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.Coluna + 2 == origem.Coluna) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQuantMovimento();
                Tab.ColocarPeca(T, destinoT);
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQuantMovimento();
            if (pecaCapturada != null) {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
            // #jogadaespecial roque pequeno
            if (p is Rei && destino.Coluna - 2 == origem.Coluna) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.DecrementarQuantMovimento();
                Tab.ColocarPeca(T, origemT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.Coluna + 2 == origem.Coluna) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.IncrementarQuantMovimento();
                Tab.ColocarPeca(T, origemT);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }

            Xeque = EstaEmXeque(Adversaria(JogadorAtual));

            if(TesteXequeMate(Adversaria(JogadorAtual))) {
                Terminada = true;
            } else {
                Turno++;
                MudarJogador();
            }
        }

        public void MudarJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            } else {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if (Tab.PecaPeca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (JogadorAtual != Tab.PecaPeca(pos).CorCor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.PecaPeca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!Tab.PecaPeca(origem).MovimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas) {
                if (x.CorCor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas) {
                if (x.CorCor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            } else {
                return Cor.Branca;
            }
        }
        private Peca DevolverRei(Cor cor) {
            foreach (Peca x in PecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool TesteXequeMate(Cor cor) {
            if (!EstaEmXeque(cor)) {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor)) {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++) {
                    for (int j = 0; j < Tab.Colunas; j++) {
                        if (mat[i, j]) {
                            Posicao destino = new Posicao(i, j);
                            Posicao origem = x.PosicaoPosicao;
                            Peca pecaCapturada = ExecutarMovimento(x.PosicaoPosicao, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if(!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool EstaEmXeque(Cor cor) {
            Peca rei = DevolverRei(cor);
            if (rei == null) {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro");
            }


            foreach (Peca x in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[rei.PosicaoPosicao.Linha, rei.PosicaoPosicao.Coluna]) {
                    return true;
                }
            }
            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas() {

            // Brancas
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tab));
            
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Tab));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tab, this));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tab));

            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tab));

            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Tab));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Tab));

            // Pretas
            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tab));

            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Tab));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tab, this));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tab));

            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tab));

            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Tab));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Tab));
        }
    }
}

