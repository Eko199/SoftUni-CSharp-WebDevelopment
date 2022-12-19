namespace UniversityCompetition.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<ISubject> subjects;
        private readonly IRepository<IStudent> students;
        private readonly IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = BuildSubject(subjects.Models.Count + 1, subjectName, subjectType);

            if (subject == null)
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);

            if (subjects.FindByName(subjectName) != null)
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);

            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName,
                subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);

            universities.AddModel(new University(universities.Models.Count + 1, universityName, category, capacity,
                requiredSubjects.Select(s => subjects.FindByName(s).Id).ToArray()));

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName,
                universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);

            students.AddModel(new Student(students.Models.Count + 1, firstName, lastName));
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
                return OutputMessages.InvalidStudentId;

            if (subject == null)
                return OutputMessages.InvalidSubjectId;

            if (student.CoveredExams.Contains(subjectId))
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName,
                    subject.Name);

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName,
                subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                string[] names = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return string.Format(OutputMessages.StudentNotRegitered, names[0], names[1]);
            }

            if (university == null)
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);

            if (!university.RequiredSubjects.All(s => student.CoveredExams.Contains(s)))
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);

            if (student.University == university)
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName,
                    universityName);

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName,
                universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            int studentsCount = students.Models.Count(s => s.University == university);
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().Trim();
        }

        private ISubject BuildSubject(int id, string name, string type)
            => type switch
            {
                "TechnicalSubject" => new TechnicalSubject(id, name),
                "EconomicalSubject" => new EconomicalSubject(id, name),
                "HumanitySubject" => new HumanitySubject(id, name),
                _ => null
            };
    }
}