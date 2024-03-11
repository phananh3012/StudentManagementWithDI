using System.Linq;

namespace SMWithNHibernate.Service
{
	public class SubjectService : ISubjectService
	{
		public Subject GetSubject(int id)
		{
			using (var session = NHibernateSession.OpenSession())
			{
				return session.Query<Subject>().Where(s => s.SubjectId == id).FirstOrDefault();
			}
		}

	}
}
