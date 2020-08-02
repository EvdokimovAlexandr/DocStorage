using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStorage.Models
{
    public class DocDto
    {
        public int DocId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string DocType { get; set; }
        public string RefFile { get; set; }
    }
}