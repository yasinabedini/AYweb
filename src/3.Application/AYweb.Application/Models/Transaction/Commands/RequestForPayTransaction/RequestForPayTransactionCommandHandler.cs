using AIPFramework.Commands;
using AYweb.Application.Tools;
using AYweb.Domain.Models.Transaction.Repositories;

namespace AYweb.Application.Models.Transaction.Commands.RequestForPayTransaction
{
    public class RequestForPayTransactionCommandHandler : ICommandHandler<RequestForPayTransactionCommand>
    {
        private readonly ITransactionRepository _repository;

        public RequestForPayTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(RequestForPayTransactionCommand request, CancellationToken cancellationToken)
        {
            string fileName = "No Image";
            if (request.Image is not null)
            {
                fileName = Generators.Generator.CreateUniqueText(10) + Path.GetExtension(request.Image.FileName);
                FileTools file = new FileTools();
                file.SaveImage(request.Image, fileName, "Transaction-ScreenShots", false);
            }
            _repository.RequestForPayTransaction(request.Id,request.PaymentMethod, fileName);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
