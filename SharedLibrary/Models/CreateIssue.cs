using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Models
{
    public class CreateIssue
    {
        [Required(ErrorMessage = "Handler Id is required")]
        public int HandlerId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public string Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }

        [Required(ErrorMessage = "Issue Status is required")]
        public string IssueStatus { get; set; }
        public string IssueDescription { get; set; }

        public virtual GetUser GetUser { get; set; }
    }
}
