using System;
using Magentix.Domain.Models.Settings;

namespace Magentix.Services.Implementations.PrinterModule
{
    public interface IDocumentFormatter
    {
        Type ObjectType { get; }
        string[] GetFormattedDocument(object item, PrinterTemplate printerTemplate);
    }
}