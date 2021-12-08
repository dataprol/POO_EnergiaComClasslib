using System.Collections.Generic;

namespace Energia1.domain
{
    public class Cliente
    {
        public int id{ get; set; }
        public string nome{ get; set; } // obrigatório
        public string email{ get; set; } // obrigatório
        public string telefone{ get; set; }
        public string dataNascimento{ get; set; } // pode ser nulo
        public List<Energia> contas{ get; set; }
        public Cliente(){ }
        public Cliente(int id, string nome, string email, string telefone, string dataNascimento)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.dataNascimento = dataNascimento;
        }
    }
}