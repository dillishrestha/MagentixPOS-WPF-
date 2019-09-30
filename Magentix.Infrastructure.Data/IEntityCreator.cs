using System.Collections.Generic;

namespace Magentix.Infrastructure.Data
{
    public interface IEntityCreator<out TModel>
    {
        IEnumerable<TModel> CreateItems(IEnumerable<string> data);
    }
}