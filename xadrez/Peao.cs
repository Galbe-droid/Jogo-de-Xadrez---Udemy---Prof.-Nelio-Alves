using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez_console.xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez _Partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab,cor)
        {
            this._Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool _ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool _Livre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if(Tab.PosicaoValida(pos) && _Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                if (Tab.PosicaoValida(pos) && _Livre(pos) && Movimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna -1);
                if (Tab.PosicaoValida(pos) && _ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && _ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //jogada en Passant
                if (posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && _ExisteInimigo(esquerda) && Tab.peca(esquerda) == _Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao diretia = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (Tab.PosicaoValida(diretia) && _ExisteInimigo(diretia) && Tab.peca(diretia) == _Partida.VulneravelEnPassant)
                    {
                        mat[diretia.Linha - 1, diretia.Coluna] = true;
                    }

                }
            }
            else
            {
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (Tab.PosicaoValida(pos) && _Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                if (Tab.PosicaoValida(pos) && _Livre(pos) && Movimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && _ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && _ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //jogada en Passant
                if (posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && _ExisteInimigo(esquerda) && Tab.peca(esquerda) == _Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao diretia = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    if (Tab.PosicaoValida(diretia) && _ExisteInimigo(diretia) && Tab.peca(diretia) == _Partida.VulneravelEnPassant)
                    {
                        mat[diretia.Linha + 1, diretia.Coluna] = true;
                    }

                }
            }
            return mat;
        }
    }
}
