using tabuleiro;

namespace Xadrez {
    internal class Torre : Peca {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab) {

        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValores(PosicaoPosicao.Linha - 1, PosicaoPosicao.Coluna);
            while(Tab.PosicaoValida(pos) && PodeMover(pos)) {
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

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.PecaPeca(pos);
            return p == null || p.CorCor != CorCor;
        }
        public override string ToString() {
            return "T";
        }
    }
}
