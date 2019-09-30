using System.Windows;
using System.Windows.Controls;
using Magentix.Domain.Models.Entities;
using Magentix.Presentation.Services;

namespace Magentix.Presentation.Common.Widgets
{
    public interface IWidgetCreator
    {
        string GetCreatorName();
        string GetCreatorDescription();
        FrameworkElement CreateWidgetControl(IDiagram widget, ContextMenu contextMenu);
        Widget CreateNewWidget();
        IDiagram CreateWidgetViewModel(Widget widget, IApplicationState applicationState);
    }
}