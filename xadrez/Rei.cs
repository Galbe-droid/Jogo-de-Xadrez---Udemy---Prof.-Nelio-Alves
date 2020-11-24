using tabuleiro;

namespace xadrez_console.xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez _Partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this._Partida = partida;
        }

        private bool _PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        public bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.Movimentos == 0;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Norte
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            if(Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //NE
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            

            //E
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //SE
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Sul
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //SO
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //O
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //NO
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#Jogada espacial Roque
            if(Movimentos == 0 && !_Partida.Xeque)
            {
                //Roque Pequeno
                Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if(testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);

                    if(Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[pos.Linha, pos.Coluna + 2] = true;
                    }
                }

                //Roque Grande
                Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[pos.Linha, pos.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
