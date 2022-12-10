using tabuleiro;

namespace Xadrez {
    internal class Rei : Peca {
        private PartidaXadrez Partida { get; set; }

        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab) {
            Partida = partida;
        }

        private bool TesteTorreRoque(Posicao pos) {
            Peca p = Tab.PecaPeca(pos);
            if (p != null && p is Torre && p.CorCor == CorCor && p.QtdMovimentos == 0) {
                return true;
            }
            return false;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

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

            // #jogadaespecial roque
            if (QtdMovimentos == 0 && !Partida.Xeque) {
                // #jogadaespecial roque pequeno
                Posicao posicaoT1 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 3);
                if(TesteTorreRoque(posicaoT1)) {
                    Posicao p1 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 2);
                    if(Tab.PecaPeca(p1) == null && Tab.PecaPeca(p2) == null) {
                        matriz[PosicaoPosicao.Linha, PosicaoPosicao.Coluna + 2] = true; 
                    }
                }
                // #jogadaespecial roque grande
                Posicao posicaoT2 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 4);
                if (TesteTorreRoque(posicaoT2)) {
                    Posicao p1 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 3);
                    if (Tab.PecaPeca(p1) == null && Tab.PecaPeca(p2) == null && Tab.PecaPeca(p3) == null) {
                        matriz[PosicaoPosicao.Linha, PosicaoPosicao.Coluna - 2] = true;
                    }
                }

            }


            return matriz;

        }

        public override string ToString() {
            return "R";
        }
    }
}
