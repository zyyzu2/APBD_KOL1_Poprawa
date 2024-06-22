namespace APBD_KOL1_Poprawa.DTO;

public class TaskDTO
{
    public string name { get; set; }
    public string description { get; set; }
    public int idProject { get; set; }
    public int idReporter { get; set; }
    public int? idAssigne { get; set; }
}