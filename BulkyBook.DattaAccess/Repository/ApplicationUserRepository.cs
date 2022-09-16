using BulkyBook.DattaAccess.Data;
using BulkyBook.DattaAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DattaAccess.Repository
{
    public class ApplicationUserRepository : Repository<AplicationUser>, IApplicationUserRepository
    {

        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}
