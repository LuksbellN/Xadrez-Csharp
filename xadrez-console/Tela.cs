using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console {
    internal class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.Linhas; i++) {
                for (int j = 0; j< tab.Colunas; j++) {
                    if (tab.Pecas[i,j] == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(tab.Pecas[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
