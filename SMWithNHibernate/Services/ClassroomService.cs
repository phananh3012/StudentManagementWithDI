using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SMWithNHibernate.Service
{
	public class ClassroomService : IClassroomService
	{
		public List<Classroom> GetAll()
		{
			using (var session = NHibernateSession.OpenSession())
			{
				return session.Query<Classroom>().ToList();
			}
		}

		public Classroom GetClassroom(int id)
		{
			using (var session = NHibernateSession.OpenSession())
			{
				return session.Query<Classroom>().Where(c => c.ClassroomId == id).FirstOrDefault();
			}
		}

		public void InsertGrade(double firstGrade, double secondGrade, int id)
		{
			using (var session = NHibernateSession.OpenSession())
			{
				session.Query<Classroom>().Where(c => c.ClassroomId == id).Update(c => new Classroom { FirstGrade = firstGrade, SecondGrade = secondGrade });
			}
		}
		public void UpdateFinalGrade(double firstGrade, double firstGradeRatio, double secondGrade, double secondGradeRatio, int id)
		{
			using (var session = NHibernateSession.OpenSession())
			{
				session.Query<Classroom>().Where(c => c.ClassroomId == id).Update(c => new Classroom { FinalGrade = ((firstGrade * firstGradeRatio) + (secondGrade * secondGradeRatio)) });
			}
		}

		public void UpdateResult()
		{
			using (var session = NHibernateSession.OpenSession())
			{
				session.Query<Classroom>().Where(c => c.FinalGrade >= 4).Update(c => new Classroom { Result = "Do" });
				session.Query<Classroom>().Where(c => c.FinalGrade < 4).Update(c => new Classroom { Result = "Truot" });
			}

		}
	}
}
