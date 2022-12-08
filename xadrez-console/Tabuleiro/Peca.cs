using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace tabuleiro {
    internal class Peca {
        public Posicao? PosicaoPosicao { get; private set; }
        public Cor CorCor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            PosicaoPosicao = null;
            CorCor = cor;
            Tab = tabuleiro;
        }
        public void AlterarPosicao(Posicao pos) {
            PosicaoPosicao = pos;
        }
    }
}
