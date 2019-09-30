using System.Collections.Generic;
using Magentix.Domain.Models.Tasks;

namespace Magentix.Presentation.Services.Implementations.TaskModule
{
    class TaskCache
    {
        public IEnumerable<Task> Tasks { get; set; }
        public TaskCache()
        {
            Tasks = new List<Task>();
        }
    }
}