using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Magentix.Domain.Models.Tasks;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.TaskModule
{
    [ModuleExport(typeof(TaskModule))]
    public class TaskModule : ModuleBase
    {
        [ImportingConstructor]
        public TaskModule()
        {
            AddDashboardCommand<EntityCollectionViewModelBase<TaskTypeViewModel, TaskType>>(Resources.TaskType.ToPlural(), Resources.Settings, 20);
        }
    }
}
