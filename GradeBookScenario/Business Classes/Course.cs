using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookScenario
{
    /// <summary>
    /// The class which is used to represent a course.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Course
    {
        /// <summary>
        /// The fee for the course.
        /// </summary>
        private decimal fee;

        /// <summary>
        /// The list of course assignments.
        /// </summary>
        private List<Assignment> assignments;

        /// <summary>
        /// The name of the course.
        /// </summary>
        private string name;

        /// <summary>
        /// The catalog number of the course.
        /// </summary>
        private string number;

        /// <summary>
        /// The instructor of the course.
        /// </summary>
        private Instructor teacher;

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="number">The number of the course.</param>
        /// <param name="name">the name of the course.</param>
        /// <param name="fee">The fee of the course.</param>
        /// <param name="teacher">The teacher of the course.</param>
        public Course(string number, string name, decimal fee, Instructor teacher)
        {
            assignments = new List<Assignment>();
            this.number = number;
            this.name = name;
            this.fee = fee;
            this.teacher = teacher;
        }

        /// <summary>
        /// Gets the teacher of the course.
        /// </summary>
        /// <value>
        /// The teacher.
        /// </value>
        public Instructor Teacher
        {
            get
            {
                return this.teacher;
            }
        }

        /// <summary>
        /// Adds the assignment to the assignments list.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        public void AddAssignment(Assignment assignment)
        {
            assignments.Add(assignment);
        }

        /// <summary>
        /// The student completes the assignment.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        /// <param name="date">The completion date.</param>
        /// <param name="student">The student.</param>
        /// <returns>the return from the Complete() method.</returns>
        public Attempt CompleteAssignment(Assignment assignment, string date, Student student)
        {
            return assignment.Complete(date, student);
        }

        /// <summary>
        /// Finds the student help.
        /// </summary>
        /// <param name="student">The student.</param>
        public void FindHelp(Student student)
        {
            Instructor tutor = this.GetTutor(student.KnowledgeLevel);

            tutor.TutorStudent(student);

        }

        /// <summary>
        /// Gets the type of the assignment.
        /// </summary>
        /// <param name="type">The type of assignment.</param>
        /// <returns>The type of asignment.</returns>
        public Assignment GetAssignmentByType(string type)
        {
            Assignment assignment = null;

            foreach (Assignment a in this.assignments)
            {
                if (a.Type == type)
                {
                    assignment = a;
                    break;
                }
            }

            return assignment;
        }

        /// <summary>
        /// Gets the student a tutor.
        /// </summary>
        /// <returns>Which instructor will tutor.</returns>
        private Instructor GetTutor(double knowledgeLevel)
        {
            Instructor result = this.Teacher.GetAssistantByKnowledgeLevel(knowledgeLevel);

            if (result == null)
            {
                result = this.Teacher;
            }

            return result;
        }
    }
}