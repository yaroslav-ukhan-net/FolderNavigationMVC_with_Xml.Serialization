using GFL_mvc_app.Models;
using GFL_mvc_app.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GFL_mvc_app.Controllers
{
    public class FolderController : Controller
    {
        private readonly FolderService _folderService;

        public FolderController(FolderService folderService)
        {
            _folderService = folderService;
        }
        //get
        [HttpGet]
        public IActionResult Folders(int id)
        {
            var MainFolder = _folderService.GetById(id);
            var AllFolders = _folderService.GetFolders();

            if(MainFolder == null)
            {
                return BadRequest();
            }

            FoldersViewModel model = new FoldersViewModel();
            model.Id = id;
            model.Name = MainFolder.Name;
            model.IdFather = MainFolder.IdFather;
            model.under = new List<Folders_under>();


            List<Folders_under> folders_Unders = new List<Folders_under>();
            foreach(var folder in AllFolders)
            {
                if(folder.IdFather == MainFolder.Id)
                {
                    folders_Unders.Add(new Folders_under()
                    {
                        Id = folder.Id,
                        Name = folder.Name,
                        IdFather = folder.IdFather
                    });
                }
            }
            foreach(var folder in folders_Unders)
            {
                model.under.Add(folder);
            }

            return View(model);
        }
    }
}
