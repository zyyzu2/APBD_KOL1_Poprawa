using APBD_KOL1_Poprawa.DTO;
using APBD_KOL1_Poprawa.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD_KOL1_Poprawa.Controler;

public class TaskControler : ControllerBase
{

    private readonly ITaskService _service;

    public TaskControler(TaskService service)
    {
        _service = service;
    }
    
    
    [Route("/api/task")]
    [HttpGet]
    public async Task<IActionResult> getTaskDetails([FromQuery] int projectId = -1)
    {
        var list = await _service.getProjectTask(projectId);
        return Ok(list);
    }
    
}