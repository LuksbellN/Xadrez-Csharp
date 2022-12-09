using tabuleiro;

namespace Xadrez {
    internal class Rei : Peca {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab) {

        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);

            // Acima
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Nordeste
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna + 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Direita
            pos.DefinirValores(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Sudeste
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna + 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            // Abaixo
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Sudoeste
            pos.DefinirValores(PosicaoPosicao.Linha + 1, PosicaoPosicao.Coluna - 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Esquerda
            pos.DefinirValores(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // Noroeste
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna - 1);
            if (PodeMover(pos) && Tab.PosicaoValida(pos)) {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            return matriz;

        }

        private bool PodeMover(Posicao pos) {
            Peca? p = Tab.PecaPeca(pos);
            return p == null || p.CorCor != CorCor;
        }

        public override string ToString() {
            return "R";
        }
    }
}
