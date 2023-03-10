﻿using crud_mvc.Data;
using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService() { }

        public List<Category> GetCategories()
        {
            using (var db = new ApplicationContext())
            {
                return db.Categories.Include(c => c.Articles).ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Categories.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public void InsertCategory(Category category)
        {
            using (var db = new ApplicationContext())
            {
                db.Categories.Add(new Category() { Name = category.Name });
                db.SaveChanges();
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var db = new ApplicationContext())
            {
                var category = this.GetCategory(id);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
