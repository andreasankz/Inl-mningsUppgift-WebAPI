using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class Issues
    {
        public int Id { get; set; }
        public int HandlerId { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string IssueStatus { get; set; }
        public string IssueDescription { get; set; }
    }
}
