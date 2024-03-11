using System;
using System.Collections.Generic;

namespace SMWithNHibernate.Service
{
	public class DisplayService : IDisplayService
	{
		public IStudentService _studentService;
		public IClassroomService _classroomService;
		public ISubjectService _subjectService;


		public DisplayService(IStudentService studentService, IClassroomService classroomService, ISubjectService subjectService)
		{
			_studentService = studentService;
			_classroomService = classroomService;
			_subjectService = subjectService;
		}
		public void DisplayMenu()
		{
			bool flag = true;
			while (flag)
			{
				Console.WriteLine("Menu quan ly sinh vien");
				Console.WriteLine("1 - Xem danh sach sinh vien");
				Console.WriteLine("2 - Xem mon hoc sinh vien dang ky");
				Console.WriteLine("3 - Nhap diem sinh vien");
				Console.WriteLine("4 - Xem diem sinh vien");
				Console.WriteLine("5 - Thoat");

				string str = Console.ReadLine();
				switch (str)
				{
					case "1":
						DisplayStudents();
						Console.ReadKey();
						Console.Clear();
						break;
					case "2":
						DisplaySubjects();
						Console.ReadKey();
						Console.Clear();
						break;
					case "3":
						DisplayGrading();
						Console.Clear();
						break;
					case "4":
						DisplayGrade();
						Console.ReadKey();
						Console.Clear();
						break;
					case "5":
						flag = false;
						break;
					default:
						break;
				}
			}
		}

		public void DisplayStudents()
		{
			List<Student> students = _studentService.GetStudents();
			Console.WriteLine("Danh sach sinh vien");
			Console.WriteLine("MSV\tHo ten\t\t\tGioi tinh\tNgay sinh\tLop\tKhoa");
			foreach (Student student in students)
			{
				Console.WriteLine($"{student.StudentId}\t{student.StudentName}\t\t{(student.Gender == 1 ? "Nam" : "Nu")}\t\t{student.DOB.ToString("dd/mm/yyyy")}\t{student.Class}\t{student.Course}");
			}
		}

		public void DisplaySubjects()
		{
			List<Classroom> classList = _classroomService.GetAll();
			Console.WriteLine("Danh sach mon hoc hi");
			Console.WriteLine("STT\tHo ten\t\t\tMon hoc");
			foreach (var classMember in classList)
			{
				Console.WriteLine($"{classMember.ClassroomId}\t{_studentService.GetStudent(classMember.StudentId).StudentName}\t\t{_subjectService.GetSubject(classMember.SubjectId).SubjectName}");
			}

		}

		public void DisplayGrading()
		{
			DisplaySubjects();
			Console.Write("Nhap STT ban ghi can nhap diem: ");
			int classroomId = int.Parse(Console.ReadLine());
			Console.Write("Nhap diem qua trinh: ");
			double firstGrade = Convert.ToDouble(Console.ReadLine());
			Console.Write("Nhap diem thanh phan: ");
			double secondGrade = Convert.ToDouble(Console.ReadLine());
			_classroomService.InsertGrade(firstGrade, secondGrade, classroomId);


			Console.Write("Ban co muon tiep tuc khong? (Y/N): ");

			Classroom classroom = _classroomService.GetClassroom(classroomId);
			Subject subject = _subjectService.GetSubject(classroom.SubjectId);
			_classroomService.UpdateFinalGrade(classroom.FirstGrade, subject.FirstGradeRate, classroom.SecondGrade, subject.SecondGradeRate, classroomId);
			_classroomService.UpdateResult();

			if (Console.ReadLine().ToUpper() == "Y")
			{
				Console.Clear();
				DisplayGrading();
			}
		}

		public void DisplayGrade()
		{
			List<Classroom> classList = _classroomService.GetAll();
			Console.WriteLine("Bang diem");
			Console.WriteLine("STT\tHo ten\t\t\tMon hoc\tDiem QT\tDiem TP\tDiem tong ket\tKet qua");
			foreach (var classMember in classList)
			{
				Console.WriteLine($"{classMember.ClassroomId}\t{_studentService.GetStudent(classMember.StudentId).StudentName}\t\t{_subjectService.GetSubject(classMember.SubjectId).SubjectName}\t{classMember.FirstGrade}\t{classMember.SecondGrade}\t{classMember.FinalGrade}\t\t{classMember.Result}");
			}
		}
	}
}
