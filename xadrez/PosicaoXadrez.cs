﻿using System;
using tabuleiro;

namespace xadrez_console.xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; private set; }
        public int Linha { get; private set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
