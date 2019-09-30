using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magentix.Infrastructure.Data
{
    public interface ICacheable : IEntityClass
    {
        DateTime LastUpdateTime { get; set; }
    }
}
