namespace AYweb.Application.Models.Product.Queries.Common
{
    public class CommentResult
    {
        public required string Title { get;  set; }

        public required string Text { get;  set; }

        public required string UserName { get;  set; }

        public required string UserPhoneNumber { get;  set; }

        public required int ProductId { get;  set; }
    }
}
