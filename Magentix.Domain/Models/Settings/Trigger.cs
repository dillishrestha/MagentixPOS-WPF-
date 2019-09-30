using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Settings
{
    public class Trigger : EntityClass
    {
        public string Expression { get; set; }
        public DateTime LastTrigger { get; set; }
    }
}
