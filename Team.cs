using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USFootball
{
    public class Team
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cidade { get; set; }
        public int SuperBowlsGanhos { get; set; }
        public int JogosForaDoPais { get; set; }
    }
}