using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectManagementSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
