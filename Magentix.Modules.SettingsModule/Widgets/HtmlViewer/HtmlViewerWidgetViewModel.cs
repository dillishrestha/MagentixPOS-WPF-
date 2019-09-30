using System.ComponentModel;
using Magentix.Domain.Models.Entities;
using Magentix.Infrastructure.Helpers;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Widgets;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.SettingsModule.Widgets.HtmlViewer
{
    public class HtmlViewerWidgetViewModel : WidgetViewModel
    {
        [Browsable(false)]
        public HtmlViewerWidgetSettings Settings { get { return SettingsObject as HtmlViewerWidgetSettings; } }

        private string _url;
        [Browsable(false)]
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                if (!string.IsNullOrEmpty(_url)) _url = _url.Replace("\r\n", " ");
                RaisePropertyChanged(() => Url);
            }
        }

        public HtmlViewerWidgetViewModel(Widget model, IApplicationState applicationState)
            : base(model, applicationState)
        {
            EventServiceFactory.EventService.GetEvent<GenericEvent<WidgetEventData>>().Subscribe(
                x =>
                {
                    if (x.Value.WidgetName == Name)
                    {
                        Url = x.Value.Value;
                    }
                });
        }

        protected override object CreateSettingsObject()
        {
            return JsonHelper.Deserialize<HtmlViewerWidgetSettings>(_model.Properties);
        }

        public override void Refresh()
        {
            Url = "about:blank";
            Url = Settings.Url;
        }
    }
}