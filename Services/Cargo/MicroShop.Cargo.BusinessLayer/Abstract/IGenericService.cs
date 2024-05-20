using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // The T prefix in method names indicates that they belong to the BusinessLayer
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
