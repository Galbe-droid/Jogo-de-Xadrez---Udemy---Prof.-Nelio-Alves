using tabuleiro;

namespace xadrez_console.xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        private bool _PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.cor != this.cor;
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

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
