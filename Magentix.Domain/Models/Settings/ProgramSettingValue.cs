using System.ComponentModel.DataAnnotations;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Settings
{
    public class ProgramSettingValue : EntityClass
    {
        [StringLength(250)]
        public string Value { get; set; }
    }
}
