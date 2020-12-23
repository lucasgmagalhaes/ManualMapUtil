using System;
using System.Collections.Generic;

namespace Benchmark.Entities
{
    public class HeroDTO
    {
        public int Id { get; set; }
        public PlayerDTO Player { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HpActual { get; set; }
        public int Xp { get; set; }
        public int LevelMaxXp { get; set; }
        public double Gold { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ItemDTO> Itens { get; set; }
    }
}
