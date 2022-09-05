using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DattaAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType{ get; }
        IArticuloRepository Articulo { get; }
        ICompanyRepository Company { get; }
        void Save();
    }
}
