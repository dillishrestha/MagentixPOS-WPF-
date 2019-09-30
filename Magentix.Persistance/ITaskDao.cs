using System;
using System.Collections.Generic;
using Magentix.Domain.Models.Tasks;

namespace Magentix.Persistance
{
    public interface ITaskDao
    {
        void SaveTask(Task task);
        IEnumerable<Task> GetTasks(int taskTypeId, DateTime endDate);
    }
}
