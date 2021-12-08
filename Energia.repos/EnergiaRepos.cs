using Energia1.domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Energia1.repos
{
    public class EnergiaRepos : IEnergiaRepos
    {
        private DataContext contexto_de_dados;

        public EnergiaRepos(DataContext contexto)
        {
            this.contexto_de_dados = contexto;
        }

        public void Create(Energia registro)
        {
            registro.cliente = contexto_de_dados.cliente.Find(registro.cliente.id);
            contexto_de_dados.Add(registro);
            contexto_de_dados.SaveChanges();
        }

        public void Delete(int id)
        {
            contexto_de_dados.consumo.Remove(GetById(id));
            contexto_de_dados.SaveChanges();
        }

        public List<Energia> GetAll()
        {
            // Retorna a lista em ordem de data:
            return contexto_de_dados.consumo.Include(x=>x.cliente).OrderBy(x=>x.cData).ToList();
        }

        public Energia GetById(int id)
        {
            return contexto_de_dados.consumo.Include(x=>x.cliente).SingleOrDefault(x=>x.id==id);
        }
        
        public void Update(Energia registro)
        {
            registro.cliente = contexto_de_dados.cliente.Find(registro.cliente.id);
            contexto_de_dados.Entry(registro).State = EntityState.Modified;
            contexto_de_dados.SaveChanges();
        }

        public string MaiorConsumo()
        {
            var maior = contexto_de_dados.consumo.Max(x=>x.nKVMes);
            return contexto_de_dados.consumo.SingleOrDefault(x=>x.nKVMes==maior).cData;
        }
        
        public string MenorConsumo()
        {
            var menor = contexto_de_dados.consumo.Min(x=>x.nKVMes);
            return contexto_de_dados.consumo.SingleOrDefault(x=>x.nKVMes==menor).cData;
        }

    }
}