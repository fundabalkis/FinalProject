using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip
    //IEntity : IEntity olabilir, veya IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalı. IEntity Interface olduğu için new'lenemez.
    public interface IEntityRepository<T> where T: class, IEntity  // category ve product için tekrarladığından buraya taşıdık
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //tüm datayı getirir

        T Get(Expression<Func<T, bool>> filter); // filtre istemesem hepsini getirir
        void add(T entity);


        void delete(T entity);


        void update(T entity);

        List<T> GetAllByCategory(int categoryId); //kategoriye göre filtrele BUNA ARTIK İHTİYAÇ KALMADI expression'dan sonra
    }
}
