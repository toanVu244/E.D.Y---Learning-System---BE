using BusinessObject.Entities;
using E.D.Y_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class CategoryRepository: GenericRepository<Category>,ICategoryRepository
    {
        private static CategoryRepository _instance;

        public static CategoryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryRepository();
                }
                return _instance;
            }
        }
    }
}
