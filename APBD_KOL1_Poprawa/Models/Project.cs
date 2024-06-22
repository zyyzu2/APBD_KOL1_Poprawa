namespace APBD_KOL1_Poprawa.Models;

public class Project
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    public int IdDefaultAssignee { get; set; }
    
    public virtual User defaultAssigneeNavigation { get; set; }
    public virtual ICollection<Access> accessNavigation { get; set; }
    public virtual ICollection<Task> TaskNavigation { get; set; }
}