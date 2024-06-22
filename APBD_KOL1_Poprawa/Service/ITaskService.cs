using System.Globalization;
using APBD_KOL1_Poprawa.Context;
using APBD_KOL1_Poprawa.DTO;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL1_Poprawa.Service;

public interface ITaskService
{
    Task<List<TaskDetailsDTO>> getProjectTask(int projectId);
    Task<bool> addNewTask(TaskDTO dto);
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
            var tasks = await _context.Tasks.Where(t => t.IdProject==projectId).ToListAsync();
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
            var tasks = await _context.Tasks.ToListAsync();
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

    public async Task<bool> addNewTask(TaskDTO dto)
    {
        Models.Task newTask = new Models.Task
        {
            IdTask = await _context.Tasks.MaxAsync(t => t.IdTask) + 1,
            Name = dto.name,
            Description = dto.description,
            createdAt = DateTime.Now,
            IdProject = dto.idProject,
            IdReporter = dto.idReporter,
        };
        if (dto.idAssigne is null)
        {
            var project = await _context.Projects.Where(p => p.IdProject == dto.idProject).FirstOrDefaultAsync();
            newTask.IdAssignee = project.IdDefaultAssignee;
        }
        else
        {
            newTask.IdAssignee = dto.idAssigne;
        }

        return true;
}
}