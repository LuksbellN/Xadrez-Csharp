using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace tabuleiro {
    internal class Tabuleiro {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public Peca[,] Pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca PecaPeca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public Peca PecaPeca(Posicao pos) {
            if(PosicaoValida(pos)) {
                return Pecas[pos.Linha, pos.Coluna];
            }
            return null;
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return PecaPeca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoPosicao = pos;
        }
        public Peca? RetirarPeca(Posicao pos) {
            if (PecaPeca(pos) == null) {
                return null;
            }
            Peca aux = PecaPeca(pos);
            aux.PosicaoPosicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos) {
            return !(pos.Linha < 0 || pos.Coluna < 0 || pos.Linha >= Linhas || pos.Coluna >= Colunas);
        }
        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
