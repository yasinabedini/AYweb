using AIPFramework.Commands;

namespace AYweb.Application.Models.User.Commands.CreateUser
{
    public class CreateUserCommand : ICommand<bool>
    {
        public required string FirstName { get; set; }
        public  required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }      
    }
}
