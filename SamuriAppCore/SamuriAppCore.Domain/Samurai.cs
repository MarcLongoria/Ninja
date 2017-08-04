using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuriAppCore.Domain
{
    public class Samurai
    {
        public Samurai()
        {
            Qoutes = new List<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Qoutes { get; set; }
        public int Battlefield { get; set; }
    }
}
