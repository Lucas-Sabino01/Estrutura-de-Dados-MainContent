using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Lista
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        // Sobrescrevendo o método ToString() para uma exibição mais elegante.
        public override string ToString()
        {
            return $"Pessoa [Nome: {Nome}, Idade: {Idade}]";
        }
    }
}
