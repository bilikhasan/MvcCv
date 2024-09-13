using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        DbCvEntities db =new DbCvEntities();

        public List<T> List()             //Listeleme işlemi
        {
            return db.Set<T>().ToList();
        }

        public void TAdd (T p)          //Ekleme işlemi
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete (T p)      //Silme işlemi
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet (int id)          //id ye göre getirme işlemi
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate (T p)              //güncelleme işlemi
        {
            db.SaveChanges();
        }

        public T Find (Expression<Func<T,bool>> where)      //id ye göre silme
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}