
namespace Database
{
    public interface ICommandHandler
    {
        object Execute(Command.ICommand command);
    }
}
