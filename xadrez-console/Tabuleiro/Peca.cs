using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace tabuleiro {
    abstract class Peca {
        public Posicao PosicaoPosicao { get; set; }
        public Cor CorCor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            PosicaoPosicao = null;
            CorCor = cor;
            Tab = tabuleiro;
            QtdMovimentos = 0;
        }
        public void IncrementarQuantMovimento() {
            QtdMovimentos++;
        }

        public void DecrementarQuantMovimento() {
            QtdMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++) {
                for (int j = 0; j < Tab.Colunas; j++) {
                    if (matriz[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao destino) {
            return MovimentosPossiveis()[destino.Linha, destino.Coluna];
        }


        public abstract bool[,] MovimentosPossiveis();
    }
}
