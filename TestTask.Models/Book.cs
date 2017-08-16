using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models.Base;

namespace TestTask.Models
{
    public class Book : Entity
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EditionDate { get; set; }
    }
}
