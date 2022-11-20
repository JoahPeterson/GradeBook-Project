using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookScenario
{
    public class Instructor
    {
        /// <summary>
        /// The instructors knowledge level.
        /// </summary>
        private double knowledgeLevel;

        /// <summary>
        /// The instructor's name.
        /// </summary>
        private string name;

        /// <summary>
        /// The number of students that the instructor is tutoring.
        /// </summary>
        private int numberOfStudentsTutored;

        /// <summary>
        /// The instructor's Salary.
        /// </summary>
        private decimal salary;

        /// <summary>
        /// The instructor's Certification Exam.
        /// </summary>
        private Attempt certificationExam;

        /// <summary>
        /// The Instructor's list of assistants.
        /// </summary>
        private List<Instructor> assistants;

        /// <summary>
        /// Initializes a new instance of the <see cref="Instructor"/> class.
        /// </summary>
        public Instructor(string name, decimal salary, double knowledgeLevel)
        {
            assistants = new List<Instructor>();

            this.name = name;
            this.salary = salary;
            this.knowledgeLevel = knowledgeLevel;
        }

        /// <summary>
        /// Gets or sets the certification exam.
        /// </summary>
        /// <value>
        /// The certification exam.
        /// </value>
        public Attempt CertificationExam
        {
            get
            {
                return this.certificationExam;
            }

            set
            {
                this.certificationExam = value;
            }
        }

        /// <summary>
        /// Adds the assistant to the assistants list.
        /// </summary>
        /// <param name="assistant">The assistant.</param>
        public void AddAssistant(Instructor assistant)
        {
            assistants.Add(assistant);
        }

        /// <summary>
        /// Tutors the student.
        /// </summary>
        public void TutorStudent(Student student)
        {
            if (this.knowledgeLevel > student.KnowledgeLevel)
            {
                student.RequiredSessions -= 1;
                this.numberOfStudentsTutored += 1;
            }
        }

        /// <summary>
        /// Grades the specified assignment.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        /// <param name="attempt">The attempt.</param>
        /// <returns>true or false depending on the attempt score. </returns>
        public bool Grade(Assignment assignment, Attempt attempt)
        {
            assignment.Grade(attempt);

            if (attempt.Score > 70)
            {
                return true;
            }

            return false;
        }

        public Instructor GetAssistantByKnowledgeLevel(double knowledgeLevel)
        {
            Instructor assistant = null;

            foreach (Instructor a in assistants)
            {
                if (a.knowledgeLevel >= knowledgeLevel)
                {
                    assistant = a;
                    break;
                }
            }

            return assistant;
        }
    }
}
