using System.Collections.Generic;
using Magentix.Domain.Models.Entities;

namespace Magentix.Presentation.Services
{
    public interface IEntityServiceClient
    {
        void UpdateEntityState(int entityId, int entityType, string stateName, string state, string quantityExp);
        void UpdateEntityData(int entityId, string fieldName, string value);
        void UpdateEntityData(EntityType entityType, string entityName, string fieldName, string value);
        void UpdateEntityState(string entityName, int entityTypeId, string stateName, string state, string quantityExp);
    }
}
