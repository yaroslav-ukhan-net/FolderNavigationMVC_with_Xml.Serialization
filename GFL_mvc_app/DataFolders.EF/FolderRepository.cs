using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFolders.EF
{
    public class FolderRepository<T> : IRepository<T> where T : class
    {
        private readonly FolderContext _context;
        protected DbSet<T> Dbset;

        public FolderRepository(FolderContext folderContext)
        {
            _context = folderContext;
            folderContext.Database.EnsureCreated();
            Dbset = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return Dbset.ToList();
        }
        public T GetById(int id)
        {
            return Dbset.Find(id);
        }
    }
}
