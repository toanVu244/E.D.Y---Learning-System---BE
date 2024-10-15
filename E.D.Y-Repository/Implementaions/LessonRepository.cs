using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class LessonRepository : GenericRepository<Lesson>
    {
        private static LessonRepository _instance;

        public static LessonRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LessonRepository();
                }
                return _instance;
            }
        }

        public async Task<Lesson> GetLessonByID(int id)
        {
            return await _context.Lessons.SingleOrDefaultAsync(l => l.LessonId == id);
        }
    }
}
