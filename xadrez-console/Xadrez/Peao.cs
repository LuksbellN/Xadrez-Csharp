using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    internal class Peao : Peca {
        private PartidaXadrez Partida { get; set; }
        public Peao(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab) {
            Partida = partida;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (CorCor == Cor.Branca) {
                pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna);
                if(Tab.PosicaoValida(pos) && PodeMoverFrente(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                    pos.DefinirValores(PosicaoPosicao.Linha - 2, PosicaoPosicao.Coluna);
                    if (QtdMovimentos == 0 && Tab.PosicaoValida(pos) && PodeMoverFrente(pos)) {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }

                pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }


                // #jogadaespecial en passant
                if (PosicaoPosicao.Linha == 3) {
                    Posicao esquerda = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 1);
                    Console.WriteLine(Partida.VulneravelEnPassant);
                    if(Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PecaPeca(esquerda) == Partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PecaPeca(direita) == Partida.VulneravelEnPassant) {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
                }

            } else {
                pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna);
                if (Tab.PosicaoValida(pos) && PodeMoverFrente(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                    pos.DefinirValores(PosicaoPosicao.Linha + 2, PosicaoPosicao.Coluna);
                    if (QtdMovimentos == 0 && Tab.PosicaoValida(pos) && PodeMoverFrente(pos)) {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }

                pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (PosicaoPosicao.Linha == 4) {
                    Posicao esquerda = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PecaPeca(esquerda) == Partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PecaPeca(direita) == Partida.VulneravelEnPassant) {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }

            }

            return matriz;
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = Tab.PecaPeca(pos);
            return p != null && p.CorCor != CorCor;
        }

        private bool PodeMoverFrente(Posicao pos) {
            Peca p = Tab.PecaPeca(pos);
            return p == null;
        } 

        public override string ToString() {
            return "P";
        }
    }
}
