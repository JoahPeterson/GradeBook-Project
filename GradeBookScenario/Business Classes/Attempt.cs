using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookScenario
{
    public class Attempt
    {
        /// <summary>
        /// The attempt's Acuracy.
        /// </summary>
        private double accuracy;

        /// <summary>
        /// The date the attempt was completed.
        /// </summary>
        private string completionDate;

        /// <summary>
        /// The score of the attempt.
        /// </summary>
        private double score;

        /// <summary>
        /// The Submission's student name
        /// </summary>
        private string studentName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attempt"/> class.
        /// </summary>
        /// <param name="studentName">Name of the student.</param>
        /// <param name="completionDate">The completion date of the attempt.</param>
        /// <param name="accuracy">The accuracy of the attempt.</param>
        public Attempt(string studentName, string completionDate, double accuracy)
        {
            this.accuracy = accuracy;
            this.completionDate = completionDate;
            this.score = score;
            this.studentName = studentName;
        }

        /// <summary>
        /// Gets the score of the attempt.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public double Score
        {
            get
            {
                return this.score;
            }
        }

        /// <summary>
        /// Grades the the attempt.
        /// </summary>
        /// <param name="possiblePoints">The possible points of an attempt.</param>
        public void Grade(double possiblePoints)
        {
            double accuracyPercentage = this.accuracy / 100;

            this.score = Math.Round(accuracyPercentage * possiblePoints);
        }
    }
}
