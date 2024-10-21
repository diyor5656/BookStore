using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using BookStore.Models;

namespace BookStore.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class CategoryController : ControllerBase
        {
            private readonly BookStoreContext _context;

            public CategoryController(BookStoreContext context)
            {
                _context = context;
            }

            
            [HttpPost]
            public int PostCategory(Category category)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return category.Id;
            }

            
            [HttpGet]
            public List<Category> GetCategory()
            {
                return _context.Category.ToList();
            }

        

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Category.FirstOrDefault(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;

                _context.SaveChanges(); 
            }
        }


        [HttpDelete]
        public void DeleteCategory([FromBody] Category category)
        {
            var updCategory = _context.Category.FirstOrDefault(c => c.Name == category.Name);

            if (updCategory != null)
            {
                _context.Category.Remove(updCategory);
                _context.SaveChanges();
            }
        }

    }


}
