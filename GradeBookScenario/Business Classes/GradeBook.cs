using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBookScenario
{
    /// <summary>
    /// The class which is used to represent a grade book.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class GradeBook
    {
        /// <summary>
        /// The grade book's current student.
        /// </summary>
        private Student currentStudent;

        /// <summary>
        /// The grade book's uniform resource locator (URL).
        /// </summary>
        private string url;

        /// <summary>
        /// The current version of the GradeBook.
        /// </summary>
        private string version;

        /// <summary>
        /// The grade book's Primary Instructor.
        /// </summary>
        private Instructor primaryInstructor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeBook"/> class.
        /// </summary>
        /// <param name="url">The URL of the GradeBook.</param>
        /// <param name="version">The version of the GradeBook.</param>
        /// <param name="currentStudent">The current student.</param>
        /// <param name="primaryInstructor">The primary instructor of the GradeBook.</param>
        public GradeBook(string url, string version, Student currentStudent, Instructor primaryInstructor)
        {
            this.url = url;
            this.version = version;
            this.primaryInstructor = primaryInstructor;
            this.currentStudent = currentStudent;

        }

        /// <summary>
        /// Gets the current student.
        /// </summary>
        /// <value>
        /// The current student.
        /// </value>
        public Student CurrentStudent
        {
            get { return this.currentStudent; }
        }
    }
}