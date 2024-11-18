using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    /*
     * Eğer bir class bir interface'i implemente ediyor ise istisnasız tüm fonksiyonlarını geliştirmek zorundadır.
     * Başka bir deyişle bir fonksiyon illaki bir interface'de olmaya zorlanmamalıdır.
     */
    public interface IRepository<T> where T : class,new()
    {
        T Get(int id);
        IList<T> GetAll();

    
    }

    public interface ISearchable<T>
    {
        IList<T> Search(string name);
    }


    public class OrderDetail
    {

    }
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        public OrderDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }

    public class Product
    {

    }

    public class ProductsRepository : IRepository<Product>, ISearchable<Product>
    {
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
