//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTaskManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public int PriorityId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string FullDescription { get; set; }
        public System.DateTime SetDate { get; set; }
        public Nullable<int> IsPerformance { get; set; }
        public Nullable<System.TimeSpan> SpentTime { get; set; }
    
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual Priority Priority { get; set; }
    }
}
