//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAssigned.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectFeedback
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectFeedback()
        {
            this.DeveloperWorkProgresses = new HashSet<DeveloperWorkProgress>();
        }
    
        public int FeedId { get; set; }
        public System.DateTime Startdate { get; set; }
        public System.TimeSpan time { get; set; }
        public System.DateTime Enddate { get; set; }
        public string Discription { get; set; }
        public Nullable<int> Project_Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public string ProjectType { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CreateProject CreateProject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeveloperWorkProgress> DeveloperWorkProgresses { get; set; }
        public virtual NewModule NewModule { get; set; }
    }
}
