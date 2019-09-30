using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.EntityModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UpdateEntityState : ActionType
    {
        private readonly IEntityServiceClient _entityServiceClient;
        private readonly ICacheService _cacheService;

        [ImportingConstructor]
        public UpdateEntityState(IEntityServiceClient entityServiceClient, ICacheService cacheService)
        {
            _entityServiceClient = entityServiceClient;
            _cacheService = cacheService;
        }

        protected override object GetDefaultData()
        {
            return new { EntityTypeName = "", EntityName = "", EntityStateName = "", CurrentState = "", EntityState = "", QuantityExp = "" };
        }

        protected override string GetActionName()
        {
            return Resources.UpdateEntityState;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UpdateEntityState;
        }

        public override void Process(ActionData actionData)
        {
            var entityId = actionData.GetDataValueAsInt("EntityId");
            var entityTypeId = actionData.GetDataValueAsInt("EntityTypeId");
            var stateName = actionData.GetAsString("EntityStateName");
            var state = actionData.GetAsString("EntityState");
            var quantityExp = actionData.GetAsString("QuantityExp");
            var entityName = actionData.GetAsString("EntityName");
            if (state != null)
            {
                if (!string.IsNullOrWhiteSpace(entityName))
                {
                    if (entityTypeId == 0)
                    {
                        var entityTypeName = actionData.GetAsString("EntityTypeName");
                        var entityType = _cacheService.GetEntityTypeByName(entityTypeName);
                        if (entityType != null)
                            entityTypeId = entityType.Id;
                    }
                    _entityServiceClient.UpdateEntityState(entityName, entityTypeId, stateName, state, quantityExp);
                }
                else if (entityId > 0 && entityTypeId > 0)
                {
                    _entityServiceClient.UpdateEntityState(entityId, entityTypeId, stateName, state, quantityExp);
                }
                else
                {
                    var ticket = actionData.GetDataValue<Ticket>("Ticket");
                    if (ticket != null)
                    {
                        var entityTypeName = actionData.GetAsString("EntityTypeName");
                        foreach (var ticketEntity in ticket.TicketEntities)
                        {
                            var entityType = _cacheService.GetEntityTypeById(ticketEntity.EntityTypeId);
                            if (string.IsNullOrEmpty(entityTypeName.Trim()) || entityType.Name == entityTypeName)
                                _entityServiceClient.UpdateEntityState(ticketEntity.EntityId, ticketEntity.EntityTypeId, stateName, state, quantityExp);
                        }
                    }
                }
            }
        }
    }
}
