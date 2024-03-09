namespace StudentManagementWithDI.Service
{
	public interface ISubjectService
	{
		string GetSubjectName(int subjectId);
		ISubject GetSubjectType(string subjectName);

	}
}
