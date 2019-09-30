using System.Windows.Input;

namespace Magentix.Presentation.Common
{
    public interface ICaptionCommand : ICommand
    {
        string Caption { get; set; }
    }
}
