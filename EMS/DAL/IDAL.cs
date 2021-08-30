using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDAL<TEntity>
    {
        bool Save(TEntity entity);
        bool Delete(object objDel);
        bool Update(object objUpdate);
        TEntity GetById(object objGet);
        List<TEntity> GetAll();
    }
}
