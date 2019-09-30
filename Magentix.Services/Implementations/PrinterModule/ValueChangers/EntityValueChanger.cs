using System.ComponentModel.Composition;
using Magentix.Domain.Models.Entities;

namespace Magentix.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class EntityValueChanger : AbstractValueChanger<Entity>
    {
        private readonly ICacheService _cacheService;

        [ImportingConstructor]
        public EntityValueChanger(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public override string GetTargetTag()
        {
            return "ENTITY";
        }

        protected override string GetModelName(Entity model)
        {
            var entityType = _cacheService.GetEntityTypeById(model.EntityTypeId);
            return entityType == null ? "" : entityType.EntityName;
        }
    }
}
