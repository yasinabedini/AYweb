using AYweb.Domain.Models.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.Common
{
    public class UserResult
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Email { get; private set; }

        public bool PhoneNumberConfrimation { get; private set; }

        public bool EmailConfrimation { get; private set; }
        public required string VerificationCode { get; set; }
        public string? Password { get; set; }
    }
}
