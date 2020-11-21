using tabuleiro;

namespace xadrez_console.xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
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
            while (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.peca(pos) != null && Tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Leste
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Sul
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Oeste
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && _PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
