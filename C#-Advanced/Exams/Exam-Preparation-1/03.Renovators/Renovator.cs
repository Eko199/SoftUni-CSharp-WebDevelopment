using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
        }

        public string Name { get; }
        public string Type { get; }
        public double Rate { get; }
        public int Days { get; }
        public bool Hired { get; set; } = false;
        public bool Paid { get; set; } = false;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.Append($"--Rate per day: {Rate} BGN");
            return sb.ToString();
        }
    }
}
