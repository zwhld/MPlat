using Xamarin.Forms.Internals;

namespace Camc.MES53.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}