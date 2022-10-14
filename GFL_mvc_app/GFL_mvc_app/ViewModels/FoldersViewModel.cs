using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFL_mvc_app.ViewModels
{
    public class FoldersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdFather { get; set; }
        public List<Folders_under> under { get; set; }
    }

    public class Folders_under
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdFather { get; set; }
    }
}
