using FinalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    internal class Program
    {

        static void DisplayMenu()
        {
            Console.WriteLine("--Project Manager Portal--");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display All Assignments (sorted by due date)");
            Console.WriteLine("2. Add an Assignment");
            Console.WriteLine("3. Remove an Assignment");
            Console.WriteLine("4. Display Assignments that are past due (due before today)");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
        }
        static AssignmentManager assignmentManager = new AssignmentManager();
        static void Main(string[] args)
        {

            assignmentManager.AddAssignment(new Assignment (1, "Complete Project", DateTime.Parse("2023-01-15")));
            assignmentManager.AddAssignment(new Assignment (2, "Review Code", DateTime.Parse("2023-01-10")));
            assignmentManager.AddAssignment(new Assignment (3, "Prepare Presentation", DateTime.Parse("2023-01-20")));

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        assignmentManager.SortAssignmentsByDueDate();
                        Console.WriteLine("Sorted Assignments by Due Date:");
                        foreach (var assignment in assignmentManager.GetAssignmentsDueBefore(DateTime.MaxValue))
                        {
                            Console.WriteLine($"ID: {assignment.AssignmentId}, Name: {assignment.AssignmentName}, Due Date: {assignment.DueDate.ToShortDateString()}");
                        }
                        break;

                    case "2":
                        AddAssignment();
                        break;

                    case "3":
                        RemoveAssignment();
                        break;

                    case "4":
                        DisplayPastDueAssignments();
                        break;

                    case "5":
                    // Add more cases as needed

                    case "0":   
                        Console.WriteLine("Exiting the Project Manager Portal. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void DisplayPastDueAssignments()
        {
            assignmentManager.GetAssignmentsDueBefore(DateTime.Today);
        }

        private static void RemoveAssignment()
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());

            assignmentManager.RemoveAssignment(id);
        }

        public static void AddAssignment()
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Date (yyyy-MM-dd): ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            assignmentManager.AddAssignment(new Assignment(id, name, dateTime));
        }
    }

    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment(int id, string name, DateTime due)
        {
            AssignmentId = id;
            AssignmentName = name;
            DueDate = due;
        }
    }
}
