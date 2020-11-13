using tabuleiro;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int Movimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cores)
        {
            this.posicao = null;
            this. Tab = tab;
            this.cor = cores;
            this.Movimentos = 0;
        }
    }
}
