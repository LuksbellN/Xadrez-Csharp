using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    internal class Cavalo : Peca {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab) { }

        public override bool[,] MovimentosPossiveis() {

            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];
             
            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna + 2);
            if(Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna - 2);
            if(Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha - 2, PosicaoPosicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha - 2, PosicaoPosicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Abaixo
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha + 2, PosicaoPosicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoPosicao.Linha + 2, PosicaoPosicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            return matriz;
        }


        public override string ToString() {
            return "C";
        }
    }
}
