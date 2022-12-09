using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {

            try {
                PartidaXadrez partida = new PartidaXadrez();

                while(!partida.Terminada) {

                    try {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.PecaPeca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    } catch(TabuleiroException e) {
                        Console.WriteLine("Erro na jogada: " + e.Message);
                        Console.ReadLine();
                    }
                }

            } catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}