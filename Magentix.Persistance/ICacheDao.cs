using System.Collections.Generic;
using Magentix.Domain.Models.Accounts;
using Magentix.Domain.Models.Automation;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Inventory;
using Magentix.Domain.Models.Menus;
using Magentix.Domain.Models.Settings;
using Magentix.Domain.Models.Tasks;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Persistance
{
    public interface ICacheDao
    {
        void ResetCache();
        IEnumerable<Entity> GetEntities(int entitiyTypeId);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<ProductTimer> GetProductTimers();
        IEnumerable<OrderTagGroup> GetOrderTagGroups();
        IEnumerable<AccountTransactionType> GetAccountTransactionTypes();
        IEnumerable<EntityType> GetEntityTypes();
        IEnumerable<AccountType> GetAccountTypes();
        IEnumerable<AccountTransactionDocumentType> GetAccountTransactionDocumentTypes();
        IEnumerable<State> GetStates();
        IEnumerable<PrintJob> GetPrintJobs();
        IEnumerable<PaymentType> GetPaymentTypes();
        IEnumerable<ChangePaymentType> GetChangePaymentTypes();
        IEnumerable<TicketTagGroup> GetTicketTagGroups();
        IEnumerable<AutomationCommand> GetAutomationCommands();
        IEnumerable<CalculationSelector> GetCalculationSelectors();
        IEnumerable<CalculationType> GetCalculationTypes();
        IEnumerable<AccountScreen> GetAccountScreens();
        IEnumerable<ScreenMenu> GetScreenMenus();
        IEnumerable<EntityScreen> GetEntityScreens();
        IEnumerable<TicketType> GetTicketTypes();
        IEnumerable<TaskType> GetTaskTypes();
        IEnumerable<ForeignCurrency> GetForeignCurrencies();
        IEnumerable<Department> GetDepartments();
        Entity GetEntityByName(int entityTypeId, string entityName);
        IEnumerable<TaxTemplate> GetTaxTemplates();
        IEnumerable<Warehouse> GetWarehouses();
        IEnumerable<InventoryTransactionType> GetInventoryTransactionTypes();
        IEnumerable<AppRule> GetRules();
        IEnumerable<AppAction> GetActions();
    }
}
