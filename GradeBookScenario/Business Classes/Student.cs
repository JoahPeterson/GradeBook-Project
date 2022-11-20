using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GradeBookScenario
{
    /// <summary>
    /// The class which is used to represent a student.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Student
    {
        /// <summary>
        /// The student's enrolled course.
        /// </summary>
        private Course course;

        /// <summary>
        /// The student's ID number.
        /// </summary>
        private int id;

        /// <summary>
        /// The student's knowledge level.
        /// </summary>
        private double knowledgeLevel;

        /// <summary>
        /// The student's name.
        /// </summary>
        private string name;

        /// <summary>
        /// The number of sessions required for the student to be removed from probation.
        /// </summary>
        private int requiredSessions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="id">The identifier of the student.</param>
        /// <param name="knowledgeLevel">The knowledge level of the student.</param>
        /// <param name="course">The course.</param>
        public Student(string name, int id, double knowledgeLevel, Course course)
        {
            this.name = name;
            this.id = id;
            this.knowledgeLevel = knowledgeLevel;
            this.course = course;

        }

        /// <summary>
        /// Gets a value indicating whether the student is on probation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the student is on probation; otherwise, <c>false</c>.
        /// </value>
        public bool IsOnProbation
        {
            get
            {
                if (this.requiredSessions > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the knowledge level of the student.
        /// </summary>
        /// <value>
        /// The knowledge level of the student.
        /// </value>
        public double KnowledgeLevel
        {
            get
            {
                return this.knowledgeLevel;
            }
        }

        /// <summary>
        /// Gets the name of the student.
        /// </summary>
        /// <value>
        /// The name of the student.
        /// </value>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets the required sessions of the student.
        /// </summary>
        /// <value>
        /// The required sessions of the student.
        /// </value>
        public int RequiredSessions
        {
            get
            {
                return this.requiredSessions;
            }

            set
            {
                if (value >= 0 && value <= 10)
                {
                    this.requiredSessions = value;
                }
            }
        }

        /// <summary>
        /// Take the Assignment.
        /// </summary>
        /// <returns>The attempt of the assignment.</returns>
        public Attempt TakeAssignment(string type, string date)
        {
            Assignment assignment = this.course.GetAssignmentByType(type);

            Attempt attempt = this.course.CompleteAssignment(assignment, date, this);

            if (this.course.Teacher.Grade(assignment, attempt))
            {
                assignment.Submit(attempt);
            }

            return attempt;
        }

        /// <summary>
        /// Gets the student help.
        /// </summary>
        public void GetHelp()
        {
            this.course.FindHelp(this);
        }
    }
}