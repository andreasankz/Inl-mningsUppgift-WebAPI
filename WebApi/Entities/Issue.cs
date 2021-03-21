using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int HandlerId { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string IssueStatus { get; set; }
        public string IssueDescription { get; set; }

        public virtual User Handler { get; set; }
    }
}
