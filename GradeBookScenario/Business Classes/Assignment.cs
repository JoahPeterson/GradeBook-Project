using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookScenario
{
    /// <summary>
    /// The class which is used to represent an assignment.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Assignment
    {
        /// <summary>
        /// The assignment's difficulty rating on a scale of 1-100.
        /// </summary>
        private double difficulty;

        /// <summary>
        /// The name of the assignment.
        /// </summary>
        private string name;

        /// <summary>
        /// The total points possible on the assignment.
        /// </summary>
        private double points;

        /// <summary>
        /// The type of assignment; e.g. Midterm or Final.
        /// </summary>
        private string type;

        /// <summary>
        /// The submission of the assignment.
        /// </summary>
        private Attempt submission;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assignment"/> class.
        /// </summary>
        /// <param name="name">The name of the assignment.</param>
        /// <param name="type">The type of the assignment.</param>
        /// <param name="possiblePoints">The possible points of the asssignment.</param>
        /// <param name="difficulty">The difficulty of the assignment.</param>
        public Assignment(string name, string type, double possiblePoints, double difficulty)
        {
            this.name = name;
            this.type = type;
            this.points = possiblePoints;
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Gets the name of the assignment.
        /// </summary>
        /// <value>
        /// The name of the assignment.
        /// </value>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the points of the assignment.
        /// </summary>
        /// <value>
        /// The points of the assignment.
        /// </value>
        public double Points
        {
            get { return this.points; }
        }

        /// <summary>
        /// Gets the type of the assignment.
        /// </summary>
        /// <value>
        /// The type of the assignment.
        /// </value>
        public string Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Completes the attempt for the assignment.
        /// </summary>
        /// <param name="date">The completion date.</param>
        /// <param name="student">The student.</param>
        /// <returns>The info of the attempt.</returns>
        public Attempt Complete(string date, Student student)
        {
            double difficultyFactor = 100 - (this.difficulty / 2);
            double accuracy = (difficultyFactor + student.KnowledgeLevel) / 2;
            Attempt submission = new Attempt(student.Name, date, accuracy);

            return submission;
        }

        /// <summary>
        /// Submits the assignment.
        /// </summary>
        /// <param name="submission">The submission.</param>
        public void Submit(Attempt submission)
        {
            this.submission = submission;
        }

        /// <summary>
        /// Grades the specified attempt of the assignment.
        /// </summary>
        /// <param name="attempt">The attempt of the assignment.</param>
        public void Grade(Attempt attempt)
        {
            attempt.Grade(this.Points);
        }
    }
}