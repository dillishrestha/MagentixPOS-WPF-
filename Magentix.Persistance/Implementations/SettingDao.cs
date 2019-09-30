using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Infrastructure;
using Magentix.Domain.Models.Settings;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Data;
using Magentix.Infrastructure.Data.Validation;
using Magentix.Localization.Properties;
using Magentix.Persistance.Data;

namespace Magentix.Persistance.Implementations
{
    [Export(typeof(ISettingDao))]
    class SettingDao : ISettingDao
    {
        [ImportingConstructor]
        public SettingDao()
        {
            ValidatorRegistry.RegisterDeleteValidator(new NumeratorDeleteValidator());
        }

        public string GetNextString(int numeratorId)
        {
            using (var workspace = WorkspaceFactory.Create())
            {
                var numerator = workspace.Single<Numerator>(x => x.Id == numeratorId);
                numerator.Number++;
                try
                {
                    workspace.CommitChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return GetNextString(numeratorId);
                }
                return numerator.GetNumber();
            }
        }

        public int GetNextNumber(int numeratorId)
        {
            using (var workspace = WorkspaceFactory.Create())
            {
                var numerator = workspace.Single<Numerator>(x => x.Id == numeratorId);
                numerator.Number++;
                try
                {
                    workspace.CommitChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return GetNextNumber(numeratorId);
                }
                return numerator.Number;
            }
        }

        public IEnumerable<Terminal> GetTerminals()
        {
            return Dao.Query<Terminal>();
        }
    }

    internal class NumeratorDeleteValidator : SpecificationValidator<Numerator>
    {
        public override string GetErrorMessage(Numerator model)
        {
            if (Dao.Exists<TicketType>(x => x.OrderNumerator.Id == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Numerator, Resources.TicketType);
            if (Dao.Exists<TicketType>(x => x.TicketNumerator.Id == model.Id))
                return string.Format(Resources.DeleteErrorUsedBy_f, Resources.Numerator, Resources.TicketType);
            return "";
        }
    }
}
