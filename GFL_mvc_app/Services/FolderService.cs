using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    public class FolderService
    {
        private readonly IRepository<Folder> _folder;
        public FolderService()
        {

        }
        public FolderService(IRepository<Folder> folder)
        {
            _folder = folder;
        }
        public virtual List<Folder> GetFolders()
        {
            return _folder.GetAll();
        }
        public virtual Folder GetById(int id)
        {
            return _folder.GetById(id);
        }
    }
}
