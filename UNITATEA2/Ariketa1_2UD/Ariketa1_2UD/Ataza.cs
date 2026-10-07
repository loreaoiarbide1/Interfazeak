using System;

namespace Ariketa1_2UD
{
    public enum Lehentasuna
    {
        Baxua,
        Ertaina,
        Altua
    }

    public class Ataza
    {
        public int Id { get; set; }
        public string Izenburua { get; set; } = string.Empty;
        public Lehentasuna Lehentasuna { get; set; } = Lehentasuna.Ertaina;
        public DateTime MugaEguna { get; set; } = DateTime.Today;
        public bool Eginda { get; set; }
    }
}