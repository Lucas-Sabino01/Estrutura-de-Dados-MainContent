using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_EstruturasHomogeneas
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }

        public override string ToString()
        {
            return $"Pessoa [Nome={Nome}, Idade={Idade}, Cidade={Cidade}]";
        }
    }
}
