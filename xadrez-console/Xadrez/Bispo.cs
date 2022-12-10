using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    internal class Bispo : Peca {
        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab) { }


        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

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

            return matriz;

        }
        public override string ToString() {
            return "B";
        }
    }
}
