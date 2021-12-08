using System.Collections.Generic;

namespace Energia1.repos
{
    public interface IBaseRepos<Entity> where Entity: class
    {
        Entity GetById(int id);
        List<Entity> GetAll();
        void Create(Entity objeto);
        void Delete(int id);
        void Update(Entity objeto);        
    }
}