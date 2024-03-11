namespace SMWithNHibernate
{
	public class Classroom
	{
		public virtual int ClassroomId { get; set; }
		public virtual int StudentId { get; set; }
		public virtual int SubjectId { get; set; }
		public virtual double FirstGrade { get; set; }
		public virtual double SecondGrade { get; set; }
		public virtual double FinalGrade { get; set; }
		public virtual string Result { get; set; }
	}
}
