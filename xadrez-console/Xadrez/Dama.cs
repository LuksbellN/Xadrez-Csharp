using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    internal class Dama : Peca {
        public Dama(Cor cor, Tabuleiro tab) : base(cor, tab) { }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Diagonal
            // NO
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha--;
                pos.Coluna--;
            }

            // NE
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha--;
                pos.Coluna++;
            }

            // SE
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha++;
                pos.Coluna++;
            }

            // SO
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha++;
                pos.Coluna--;
            }


            // Reta
            // Acima
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }
            // Abaixo 
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Linha = pos.Linha + 1;
            }
            // Direita 
            pos.DefinirValores(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Coluna = pos.Coluna + 1;
            }

            // Esquerda
            pos.DefinirValores(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaPeca(pos) != null && PodeMover(pos)) {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            return matriz;
        }

        public override string ToString() {
            return "D";
        }
    }
}
