using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Folder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdFather { get; set; }
    }
}
