using System.Globalization;
using APBD_KOL1_Poprawa.Context;
using APBD_KOL1_Poprawa.DTO;

namespace APBD_KOL1_Poprawa.Service;

public interface ITaskService
{
    Task<List<TaskDetailsDTO>> getProjectTask(int projectId);
}

public class TaskService : ITaskService
{

    private readonly AppDBContext _context;

    public TaskService(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<TaskDetailsDTO>> getProjectTask(int projectId)
    {
        if (projectId != -1)
        {
            List<TaskDetailsDTO> result = new List<TaskDetailsDTO>();
            var tasks = _context.Tasks.Where(t => t.IdProject==projectId).ToList();
            foreach (var task in tasks)
            {
                var dto = new TaskDetailsDTO
                {
                    idTask = task.IdTask,
                    name = task.Name,
                    description = task.Description,
                    createdAt = task.createdAt,
                    idProject = task.IdProject,
                    idReporter = task.IdReporter,
                    reporter = new UserDTO
                    {
                        firstName = task.reporterNavigation.FirstName,
                        lastName = task.reporterNavigation.LastName
                    },
                    idAssignee = task.IdAssignee,
                    assignee = new UserDTO()
                    {
                        firstName = task.assigneeNavigation.FirstName,
                        lastName = task.assigneeNavigation.LastName
                    }
                };
                result.Add(dto);
            }

            return result;
        }
        else
        {
            List<TaskDetailsDTO> result = new List<TaskDetailsDTO>();
            var tasks = _context.Tasks.ToList();
            foreach (var task in tasks)
            {
                var dto = new TaskDetailsDTO
                {
                    idTask = task.IdTask,
                    name = task.Name,
                    description = task.Description,
                    createdAt = task.createdAt,
                    idProject = task.IdProject,
                    idReporter = task.IdReporter,
                    reporter = new UserDTO
                    {
                        firstName = task.reporterNavigation.FirstName,
                        lastName = task.reporterNavigation.LastName
                    },
                    idAssignee = task.IdAssignee,
                    assignee = new UserDTO()
                    {
                        firstName = task.assigneeNavigation.FirstName,
                        lastName = task.assigneeNavigation.LastName
                    }
                };
                result.Add(dto);
            }

            return result;
        }
    }
    
}