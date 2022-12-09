using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez_console;
using System.Collections.Generic;

namespace Xadrez {
    class PartidaXadrez {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaXadrez() {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();

            ColocarPecas();
            Terminada = false;
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQuantMovimento();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }

        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void MudarJogador() {
            if(JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            } else {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if(Tab.PecaPeca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if(JogadorAtual != Tab.PecaPeca(pos).CorCor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if(!Tab.PecaPeca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!Tab.PecaPeca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas) {
                if(x.CorCor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas) {
                if (x.CorCor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Tab));

        }
    }
}
