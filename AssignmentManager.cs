using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    internal class AssignmentManager
    {
        List<Assignment> assignments;

        public AssignmentManager()
        {
            assignments = new List<Assignment>();
        }

        public void AddAssignment(Assignment item)
        {
            assignments.Add(item);
        }

        public void RemoveAssignment(int assignmentId)
        {
            assignments.RemoveAll(a => a.AssignmentId == assignmentId);
        }

        public List<Assignment> GetAssignmentsDueBefore(DateTime due)
        {
            return assignments.Where(a=>a.DueDate < due).ToList();
        }

        public void SortAssignmentsByDueDate()
        {
            assignments.Sort((a1,a2) => a1.DueDate.CompareTo(a2.DueDate));
        }
    }
}
