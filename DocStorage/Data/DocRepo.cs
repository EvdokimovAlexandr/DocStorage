using DocStorage.Models;
using Microsoft.AspNetCore.Http;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStorage.Data
{
    public class DocRepo
    {
        public void AddDoc(Doc doc)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(doc);
            }
        }

        public List<Doc> GetDocs()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<Doc>();
                return criteria.List<Doc>().ToList();
            }
        }
    }
}