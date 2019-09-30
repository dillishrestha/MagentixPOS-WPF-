using System;
using System.ComponentModel.Composition;
using ICSharpCode.AvalonEdit.Document;
using Magentix.Domain.Models.Automation;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.AutomationModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScriptViewModel : EntityViewModelBase<Script>
    {
        public string HandlerName { get { return Model.HandlerName; } set { Model.HandlerName = value; } }
        public string Code { get { return Model.Code; } set { Model.Code = value; } }
        public TextDocument ScriptText { get; set; }

        protected override void Initialize()
        {
            base.Initialize();
            ScriptText = new TextDocument(Code ?? "");
        }

        protected override void OnSave(string value)
        {
            Code = ScriptText.Text;
            base.OnSave(value);
        }

        public override Type GetViewType()
        {
            return typeof(ScriptView);
        }

        public override string GetModelTypeString()
        {
            return Resources.Script;
        }
    }
}
