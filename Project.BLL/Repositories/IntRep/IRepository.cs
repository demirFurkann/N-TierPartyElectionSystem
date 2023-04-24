using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories.IntRep
{
    public interface IRepository<T> where T :class
    {
        //List Commands 

        List<T> GetAll();
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();


        //Modify Commands

        void Add(T item);
        void AddRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq

        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        //Find Commands
        T Find(int id);
        //LastDatas
        List<T> GetLastDatas(int number);
        //FirstDatas
        List<T> GetFirstDatas(int number);
    }
}
