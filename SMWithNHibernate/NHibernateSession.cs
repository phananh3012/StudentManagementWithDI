using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace SMWithNHibernate
{
	public class NHibernateSession
	{
		public static ISession OpenSession()
		{
			var cfg = new Configuration();

			cfg.DataBaseIntegration(x =>
			{
				x.ConnectionString = "Server= NAMNP-2020\\SQLEXPRESS; Database= StudentManagement; Trusted_Connection= True; TrustServerCertificate= True";
				x.Driver<SqlClientDriver>();
				x.Dialect<MsSql2012Dialect>();
			});

			cfg.AddAssembly(Assembly.GetExecutingAssembly());

			ISessionFactory sessionFactory = cfg.BuildSessionFactory();
			return sessionFactory.OpenSession();
		}
	}
}
