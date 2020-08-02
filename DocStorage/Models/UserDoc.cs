using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStorage.Models
{
    public class UserDoc
    {
        public virtual int UserDocId { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}