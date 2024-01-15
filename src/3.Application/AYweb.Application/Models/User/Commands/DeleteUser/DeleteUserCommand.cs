using AIPFramework.Commands;

namespace AYweb.Application.Models.User.Commands.DeleteUser
{
    public class DeleteUserCommand : ICommand
    {
        public long Id { get; set; }
    }
}
