namespace APBD_KOL1_Poprawa.Models;

public class Access
{
    public int IdAccess { get; set; }
    public int IdUser { get; set; }
    public int IdProject { get; set; }
    
    public virtual Project projectNavigation { get; set; }
    public virtual User userNavigation { get; set; }
}