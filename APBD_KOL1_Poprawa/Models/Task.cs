namespace APBD_KOL1_Poprawa.Models;

public class Task
{
    public int IdTask { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime createdAt { get; set; }
    public int IdProject { get; set; }
    public int IdReporter { get; set; }
    public int IdAssignee { get; set; }
    
    
    public virtual Project projectNavigation { get; set; }
    public virtual User reporterNavigation { get; set; }
    public virtual User assigneeNavigation { get; set; }
}