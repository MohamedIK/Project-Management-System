using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectManagementSystem.Models
{
    public enum TaskPriority
    {
        None,
        Low,
        Medium,
        High,
    }
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool State { get; set; } = true;
        public TaskPriority Priority { get; set; } = TaskPriority.None;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
