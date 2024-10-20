    using BusinessObject.Entities;
    using E.D.Y_Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace E.D.Y_Repository.Implementaions
    {
        public class AchivementRepository : GenericRepository<Achivement>, IAchivementRepository
        {
            private static AchivementRepository _instance;

            public static AchivementRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new AchivementRepository();
                    }
                    return _instance;
                }
            }

            public async Task<Achivement> GetAchivementByID(int id)
            {
                return await _context.Achivements.SingleOrDefaultAsync(a => a.AchiveId == id);
            }
        }
    }
