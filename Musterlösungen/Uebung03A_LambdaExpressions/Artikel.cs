namespace Uebung04_LambdaExpressions
{
    internal class Artikel
    {
        public int Nr { get; }
        public string? Name { get; }
        public decimal Preis { get; }
        public Artikel(int nr, string? name, decimal preis)
        {
            Nr = nr;
            Name = name;
            Preis = preis;
        }
        public override string ToString()
        {
            return Nr + "," + Name + "," + Preis;
        }
    }
}