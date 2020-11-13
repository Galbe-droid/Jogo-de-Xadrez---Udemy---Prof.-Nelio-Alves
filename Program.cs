using System;
using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 7));
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(3, 2));
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
