﻿using APBD_KOL1_Poprawa.Models;

namespace APBD_KOL1_Poprawa.DTO;

public class TaskDetailsDTO
{
    public int idTask { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime createdAt { get; set; }
    public int idProject { get; set; }
    public int idReporter { get; set; }
    public UserDTO reporter { get; set; }
    public int idAssignee { get; set; }
    public UserDTO assignee { get; set; }
}