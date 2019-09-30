using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Magentix.Domain.Models.Entities;
using Magentix.Infrastructure.Helpers;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Widgets;
using Magentix.Presentation.Services;
using Magentix.Services;

namespace Magentix.Modules.TaskModule.Widgets.TaskEditor
{
    [Export(typeof(IWidgetCreator))]
    class TaskEditorWidgetCreator : IWidgetCreator
    {
        private readonly ITaskService _taskService;
        private readonly ICacheService _cacheService;
        private readonly IMessagingService _messagingService;

        [ImportingConstructor]
        public TaskEditorWidgetCreator(ITaskService taskService, ICacheService cacheService, IMessagingService messagingService)
        {
            _taskService = taskService;
            _cacheService = cacheService;
            _messagingService = messagingService;
        }

        public string GetCreatorName()
        {
            return "TaskEditorCreator";
        }

        public string GetCreatorDescription()
        {
            return "Task Editor";
        }

        public Widget CreateNewWidget()
        {
            var parameters = JsonHelper.Serialize(new TaskEditorWidgetSettings());
            var result = new Widget { Properties = parameters, CreatorName = GetCreatorName() };
            return result;
        }

        public IDiagram CreateWidgetViewModel(Widget widget, IApplicationState applicationState)
        {
            return new TaskEditorViewModel(widget, applicationState, _taskService, _cacheService, _messagingService);
        }

        public FrameworkElement CreateWidgetControl(IDiagram widgetViewModel, ContextMenu contextMenu)
        {
            var viewModel = widgetViewModel as TaskEditorViewModel;

            var result = new TaskEditorView { DataContext = viewModel, ContextMenu = contextMenu };
            var heightBinding = new Binding("Height") { Source = viewModel, Mode = BindingMode.TwoWay };
            var widthBinding = new Binding("Width") { Source = viewModel, Mode = BindingMode.TwoWay };
            var xBinding = new Binding("X") { Source = viewModel, Mode = BindingMode.TwoWay };
            var yBinding = new Binding("Y") { Source = viewModel, Mode = BindingMode.TwoWay };
            var transformBinding = new Binding("ScaleTransform") { Source = viewModel, Mode = BindingMode.OneWay };

            result.SetBinding(InkCanvas.LeftProperty, xBinding);
            result.SetBinding(InkCanvas.TopProperty, yBinding);
            result.SetBinding(FrameworkElement.HeightProperty, heightBinding);
            result.SetBinding(FrameworkElement.WidthProperty, widthBinding);
            result.Border.SetBinding(FrameworkElement.LayoutTransformProperty, transformBinding);

            viewModel.TaskAdded += result.ViewModel_TaskAdded;

            return result;
        }

        
    }
}
