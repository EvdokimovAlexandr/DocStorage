using DocStorage.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocStorage
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurePath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\nhibernate.cfg.xml");
            configuration.Configure(configurePath);
            configuration.AddAssembly(typeof(UserDoc).Assembly);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            new SchemaUpdate(configuration).Execute(true, true);
            return sessionFactory.OpenSession();
        }
    }
}