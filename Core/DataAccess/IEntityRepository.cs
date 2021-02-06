
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //tüm entity  sınıfları için ortak olan methodları bir interface içinde Generic olarak oluşturuyoruz
        //Refactoring Çalışması - GetAll gibi bir tane de sadece bir obje döndüren bir Get operasyonu yazacağız
        //Expression get aldaki uygulama - ayrı ayrı methodlar yazmamızı engelliyor
        /*
        <T> yi sınırlandırmamız lazım. sadece kullanacağımız entityleri kullanmalı bu <T> 
        Buna Geceric Constraint - Generic Ksıt
        T:class - Referans Tip olabilir
        T:class,IEntity - Sadece bir referans tip ve IEntity olmalıdır
        T:class,IEntity,new() lenebilir olmalı


         */
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//null filtre vermeyebilirsin de demek.
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
