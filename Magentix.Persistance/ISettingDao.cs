using System.Collections.Generic;
using Magentix.Domain.Models.Settings;

namespace Magentix.Persistance
{
    public interface ISettingDao
    {
        string GetNextString(int numeratorId);
        int GetNextNumber(int numeratorId);
        IEnumerable<Terminal> GetTerminals();
    }
}
