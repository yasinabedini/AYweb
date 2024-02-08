using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Application.Models.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly ISender _sender;

        public PagedData<UserResult> Users { get; set; }

        public IndexModel(ISender sender)
        {
            _sender = sender;
        }

        public void OnGet(string search = "", int page = 1,string notif = "")
        {
            Users = _sender.Send(new GetUsersQuery() { Search = search, PageNumber = page, PageSize = 50 }).Result;
        }
    }
}
