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
    
    public partial class CreateProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CreateProject()
        {
            this.DeveloperWorkProgresses = new HashSet<DeveloperWorkProgress>();
            this.ProjectFeedbacks = new HashSet<ProjectFeedback>();
            this.NewModules = new HashSet<NewModule>();
        }
    
        public int Project_Id { get; set; }
        public string ProjectTitle { get; set; }
        public string Budget { get; set; }
        public System.DateTime AwardDate { get; set; }
        public System.DateTime Startdate { get; set; }
        public System.DateTime Enddate { get; set; }
        public System.DateTime ActualCompletedate { get; set; }
        public string Status { get; set; }
        public string Statusfeedback { get; set; }
        public string Fileuploads { get; set; }
        public string Discription { get; set; }
        public Nullable<int> Developer_Id { get; set; }
        public string ProjectType { get; set; }
        public Nullable<int> Assign { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeveloperWorkProgress> DeveloperWorkProgresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectFeedback> ProjectFeedbacks { get; set; }
        public virtual CreateDeveloper CreateDeveloper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewModule> NewModules { get; set; }
    }
}
