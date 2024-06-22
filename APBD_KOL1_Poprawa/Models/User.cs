namespace APBD_KOL1_Poprawa.Models;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual ICollection<Access> accessNavigation { get; set; }
    public virtual ICollection<Project> projectNavigation { get; set; }
    public virtual ICollection<Task> taskReporterNavigation { get; set; }
    public virtual ICollection<Task> taskAssigneNavigation { get; set; }
}