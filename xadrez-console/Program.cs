﻿using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console {
    internal class Program {
        static void Main(string[] args) {

            Tabuleiro tab = new Tabuleiro(8,8);

            tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
            tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
            tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(2, 4));


            Tela.ImprimirTabuleiro(tab);

        }
    }
}