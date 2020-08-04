using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocStorage.Models
{
    public class DocDto
    {
        public int DocId { get; set; }
        [Required(ErrorMessage ="Название обязательно")]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string DocType { get; set; }
        [Required(ErrorMessage ="Ссылка на файл крайне необходима")]
        public string RefFile { get; set; }
    }
}