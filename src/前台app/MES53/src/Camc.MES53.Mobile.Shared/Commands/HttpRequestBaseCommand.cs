using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Abp.Extensions;
using Camc.MES53.Core.Threading;

namespace Camc.MES53.Commands
{
    public class HttpRequestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ICommand _command;

        protected HttpRequestCommand(ICommand command)
        {
            _command = command;
            command.CanExecuteChanged += (sender, args) => CanExecuteChanged.InvokeSafely(sender, args);
        }

        public bool CanExecute(object parameter)
        {
            return _command.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _command.Execute(parameter);
        }

        public static HttpRequestCommand Create(Func<Task> func)
        {
            return new HttpRequestCommand(AsyncCommand.Create(() => WebRequestExecuter.Execute(func)));
        }
    }
}