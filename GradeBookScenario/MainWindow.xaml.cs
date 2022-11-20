using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GradeBookScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Blackboard grade book.
        /// </summary>
        private GradeBook blackboard;

        /// <summary>
        /// The Canvas grade book.
        /// </summary>
        private GradeBook canvas;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates Blackboard and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newBlackboardButton_Click(object sender, RoutedEventArgs e)
        {
            Instructor instructor = new Instructor("Alan", 41000.00m, 90.5);

            Course studentCourse = new Course("211", "Web Design", 500.00m, instructor);

            Student student = new Student("Arthur", 210083, 65.5, studentCourse);

            student.RequiredSessions = 3;

            Assignment startHere = new Assignment("Plan", "Start Here", 5.0, 2.1);

            studentCourse.AddAssignment(startHere);

            Assignment midterm = new Assignment("HTML Exercises", "Midterm", 100.0, 12.7);

            studentCourse.AddAssignment(midterm);

            Assignment final = new Assignment("Website 1", "Final", 100.0, 64.8);

            studentCourse.AddAssignment(final);

            instructor.CertificationExam = new Attempt("Alan", "08/23/2018", 99.0);

            Instructor assistantTwo = new Instructor("Donald", 39000.00m, 65.3);

            instructor.AddAssistant(assistantTwo);

            Instructor assistant = new Instructor("Sheldon", 40000.00m, 75.3);

            instructor.AddAssistant(assistant);

            this.blackboard = new GradeBook("mygradebook.com", "4.1.0", student, instructor);
        }

        private void newCanvasButton_Click(object sender, RoutedEventArgs e)
        {
            Instructor instructor = new Instructor("Jeff", 50000.00m, 95.0);

            Course studentCourse = new Course("101", "English Comp", 400.00m, instructor);

            Student student = new Student("Samantha", 240237, 87.8, studentCourse);

            student.RequiredSessions = 4;

            Assignment startHere = new Assignment("Plan", "Start Here", 5.0, 2.1);

            studentCourse.AddAssignment(startHere);

            Assignment midterm = new Assignment("Short Essay", "Midterm", 100.0, 31.3);

            studentCourse.AddAssignment(midterm);

            Assignment final = new Assignment("Term Paper", "Final", 100.0, 66.2);

            studentCourse.AddAssignment(final);

            instructor.CertificationExam = new Attempt("Jeff", "11/18/2016",98.0);

            Instructor assistantTwo = new Instructor("Linus", 40000.00m, 75.3);

            instructor.AddAssistant(assistantTwo);

            Instructor assistant = new Instructor("Samuel", 35000.00m, 85.3);

            instructor.AddAssistant(assistant);

            this.canvas = new GradeBook("instructure.com", "1.1.3", student, instructor);
        }

        private void takeFinalButton_Click(object sender, RoutedEventArgs e)
        {
            this.blackboard.CurrentStudent.TakeAssignment("Final", "12/18/2018");
        }

        private void writeFinalPaperButton_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.CurrentStudent.TakeAssignment("Final", "12/18/2018");
        }

        private void tutorArthurButton_Click(object sender, RoutedEventArgs e)
        {
            this.blackboard.CurrentStudent.GetHelp();
        }

        private void tutorSamanthaButton_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.CurrentStudent.GetHelp();
        }

        private void takeMidtermButton_Click(object sender, RoutedEventArgs e)
        {
            this.blackboard.CurrentStudent.TakeAssignment("Midterm", "10/07/2018");
        }

        private void writeEssayButton_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.CurrentStudent.TakeAssignment("Midterm", "10/07/2018");
        }
    }
}