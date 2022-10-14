using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Exp_imp_xml_data_with_folders
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("1.Импорт с файла Input_folders.xml который находится в папке проекта\n2.Экспорт БД в XML\n\tВаша команда:");
            string choise =  Console.ReadLine();


            if(choise == "1") //import
            {
                List<Folder> folders = Import(); 
                using FolderContext context = new();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                foreach (var f in folders)
                {
                    context.Folders.Add(f);
                }
                context.SaveChanges();
            }

            if (choise == "2") //export
            {
                using FolderContext context = new();
                context.Database.EnsureCreated();
                Export(context.Folders.ToList());

            }

        }
        private static List<Folder> Import()
        {
            List<Folder> folders = new();
            XDocument document = XDocument.Load("Input_folders.xml");
            IEnumerable<XElement> FolderElements = document.Root.Elements("Folder");
            foreach(XElement folderelement in FolderElements)
            {
                Folder fold = new();
                fold.Name = folderelement.Attribute("Name").Value;
                fold.Id = Convert.ToInt32(folderelement.Element("Id").Value);
                fold.IdFather = Convert.ToInt32(folderelement.Element("IdFather").Value);
                folders.Add(fold);
            }
            return folders;
        }
        private static void Export(List<Folder> folders)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("Folders");
            document.Add(root);

            foreach(var fold in folders)
            {
                XElement element = new XElement("Folder", new XAttribute("Name",fold.Name));
                element.Add(new XElement("Id",fold.Id));
                element.Add(new XElement("IdFather", fold.IdFather));
                root.Add(element);
            }
            document.Save("Input_folders.xml");
        }
    }
}
