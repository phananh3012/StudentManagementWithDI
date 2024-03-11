using System;

namespace SMWithNHibernate
{
	public class Student
	{
		public virtual int StudentId { get; set; }
		public virtual string StudentName { get; set; }
		public virtual int Gender { get; set; }
		public virtual DateTime DOB { get; set; }
		public virtual string Class { get; set; }
		public virtual int Course { get; set; }
	}
}
