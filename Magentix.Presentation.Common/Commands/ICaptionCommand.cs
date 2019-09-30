using System.Windows.Input;

namespace Magentix.Presentation.Common.Commands
{
    public interface ICaptionCommand : ICommand
    {
        string Caption { get; set; }
    }
}
