using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ColocarPeca(Peca p, Posicao pos) {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.AlterarPosicao(pos);
        }
    }
}
