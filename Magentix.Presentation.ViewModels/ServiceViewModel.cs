using Magentix.Domain.Models.Accounts;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Settings;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;

namespace Magentix.Presentation.ViewModels
{
    public class ServiceViewModel : ObservableObject
    {
        public Calculation Model { get; set; }

        public ServiceViewModel(Calculation model)
        {
            Model = model;
        }

        public string Name { get { return Model.Name + " " + Description; } }

        public string Description
        {
            get
            {
                if (Model.CalculationType == 0 || Model.CalculationType == 1)
                    return (Model.Amount / 100).ToString("#,#0.##%");
                return "";
            }
        }

        public string Amount
        {
            get
            {
                return (Model.CalculationAmount).ToString(LocalSettings.ReportCurrencyFormat);
            }
        }

        public decimal CalculationAmount { get { return Model.CalculationAmount; } }

        public void Refresh()
        {
            RaisePropertyChanged(() => Amount);
            RaisePropertyChanged(() => Description);
        }
    }
}
