using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    internal class Peao : Peca {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab) { }

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
                if (Tab.PosicaoValida(pos) && PodeMoverDiagonal(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && PodeMoverDiagonal(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
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
                if (Tab.PosicaoValida(pos) && PodeMoverDiagonal(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && PodeMoverDiagonal(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
            }

            return matriz;
        }

        private bool PodeMoverDiagonal(Posicao pos) {
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
