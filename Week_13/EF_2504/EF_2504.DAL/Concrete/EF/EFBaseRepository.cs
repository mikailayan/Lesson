﻿using System;
using System.Collections.Generic;
using System.Linq;
using EF_2504.DAL.Abstract;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF_2504.DAL.Concrete.EF
{
    public class EFBaseRepository<T> : IEntityRepository<T> where T:class
    {
        public void Add(T entity)
        {
            using (var _context = new BookAppDbContext())
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var _context = new BookAppDbContext())
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var _context = new BookAppDbContext())
            {
                return _context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var _context = new BookAppDbContext())
            {
                return filter == null ?
                    _context.Set<T>().ToList() :
                    _context.Set<T>().Where(filter).ToList(); 
            }
        }

        public void Update(T entity)
        {
            using (var _context = new BookAppDbContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
