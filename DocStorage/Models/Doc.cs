using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStorage.Models
{
    public class Doc
    {
        public virtual int DocId { get; set; }
        public virtual string Author { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime DateOfCreation { get; set; }
        public virtual string DocType { get; set; }
        public virtual string RefFile { get; set; }
    }
}