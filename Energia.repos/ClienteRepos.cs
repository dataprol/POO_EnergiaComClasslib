using System.Collections.Generic;
using System.Linq;
using Energia1.domain;
using Microsoft.EntityFrameworkCore;

namespace Energia1.repos
{
    public class ClienteRepository : IClienteRepository
    {
        private DataContext contexto_de_dados;

        public ClienteRepository(DataContext contexto)
        {
            this.contexto_de_dados = contexto;
        }

        public List<Cliente> GetAll()
        {
            var Lista = contexto_de_dados.cliente.Include(x=>x.contas).ToList();
            return Lista;
        }

        public Cliente GetById(int id)
        {
            var resultado = contexto_de_dados.cliente.Include(x=>x.contas).SingleOrDefault(x=>x.id==id);
            return resultado;
        }

        public void Create(Cliente objeto)
        {
            contexto_de_dados.Add(objeto);
            contexto_de_dados.SaveChanges();
        }

        public void Delete(int id)
        {
            contexto_de_dados.cliente.Remove(GetById(id));
            contexto_de_dados.SaveChanges();
        }

        public void Update(Cliente objeto)
        {
            contexto_de_dados.Entry(objeto).State = EntityState.Modified;
            contexto_de_dados.SaveChanges();
        }

        public string MaiorConsumoCliente(int id)
        {
            var maior = contexto_de_dados.consumo.Where(x=>x.cliente.id==id).Max(x=>x.nKVMes);
            return contexto_de_dados.consumo.SingleOrDefault(x=>x.nKVMes==maior).cData;
        }
        
        public string MenorConsumoCliente(int id)
        {
            var menor = contexto_de_dados.consumo.Where(x=>x.cliente.id==id).Min(x=>x.nKVMes);
            return contexto_de_dados.consumo.SingleOrDefault(x=>x.nKVMes==menor).cData;
        }

    }
}