using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.DepartmentModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartmentListViewModel : EntityCollectionViewModelBase<DepartmentViewModel, Department>
    {

    }
}
