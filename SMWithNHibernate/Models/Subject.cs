namespace SMWithNHibernate
{
	public class Subject
	{
		public virtual int SubjectId { get; set; }
		public virtual string SubjectName { get; set; }
		public virtual int NumberOfPeriod { get; set; }
		public virtual double FirstGradeRate { get; set; }
		public virtual double SecondGradeRate { get; set; }

	}
}
