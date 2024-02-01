using AIPFramework.Commands;
using AYweb.Application.Generators;
using AYweb.Application.Models.Order.Commands.CreateForward;
using AYweb.Application.Models.Transaction.Commands.AddTransactionLine;
using AYweb.Application.Models.Transaction.Commands.ApproveTransaction;
using AYweb.Application.Models.Transaction.Commands.CreateTransaction;
using AYweb.Application.Models.Transaction.Commands.RequestForPayTransaction;
using AYweb.Application.Models.User.Queries.GetAuthenticatedUser;
using AYweb.Application.Senders;
using AYweb.Application.Tools;
using AYweb.Domain.Models.Order.Enums;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Transaction.Entities;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Transaction.Repositories;
using MediatR;

namespace AYweb.Application.Models.Order.Commands.PayOrder
{
    public class PayOrderCommandHandler : ICommandHandler<PayOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly ITransactionLineRepository _transactionLineRepository;
        private readonly ISender _sender;

        public PayOrderCommandHandler(IOrderRepository repository, ISender sender, ITransactionLineRepository transactionLineRepository)
        {
            _repository = repository;
            _sender = sender;
            _transactionLineRepository = transactionLineRepository;
        }

        public Task Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var user = _sender.Send(new GetAuthenticatedUserQuery()).Result;
            var mainOrder = _repository.GetByIdWithRelations(request.Id);

            mainOrder.SetNotes(request.Notes ?? "");

            //If We Should Post a order
            if (request.InPersonDelivery == false)
            {
                long forwardId = _sender.Send(new CreateForwardCommand() { OrderId = request.Id, Province = request.province, City = request.City, PostalCode = request.PostalCode, Address = request.Address, TransfereeName = request.CustomerName }).Result;
                mainOrder.AddFroward(forwardId);

            }

            //If InPersonDelivery == true
            else
            {
                mainOrder.EnableInPersonDelivery();
            }


            if (request.PaymentMethod == (int)_PaymentMethod.PaymentGateway)
            {
                mainOrder.OrderStatus = _OrderStatus.Packing.ToString();
                var transaction = _sender.Send(new CreateTransactionCommand { PaymentMethod = _PaymentMethod.PaymentGateway, Description = $"Payment Order By Id : ({mainOrder.Id})", TransactionScreenShot = "PaymentGetWay.jpg", Type = _TransactionType.PaymentOrder, UserId = user.Id, Price = request.SumPrice }).Result;
                mainOrder.PaymentRequest(transaction, request.PaymentMethod);
                _sender.Send(new ApproveTransactionCommand() { Id = transaction });
                _repository.ApproveOrder(request.Id);
                mainOrder.OrderLines.ForEach(t => _transactionLineRepository.Add(TransactionLine.Create(transaction, t.Product.Name, t.Count, t.UnitPrice)));
                _repository.Save();
            }

            if (request.PaymentMethod == (int)_PaymentMethod.CardByCard)
            {
                mainOrder.OrderStatus = _OrderStatus.AwaitingPaymentConfirmation.ToString();
                FileTools file = new FileTools();

                if (request.TransactionScreenShot != null)
                {
                    string fileName = Generator.CreateUniqueText(15) + Path.GetExtension(request.TransactionScreenShot.FileName);
                    file.SaveImage(request.TransactionScreenShot, fileName, "Transaction-ScreenShots", false);

                    var transaction = _sender.Send(new CreateTransactionCommand() { Description = $"Payment Order By Id : ({mainOrder.Id})", PaymentMethod = _PaymentMethod.CardByCard, TransactionScreenShot = fileName, Type = _TransactionType.PaymentOrder, UserId = user.Id, Price = request.SumPrice }).Result;
                    mainOrder.PaymentRequest(transaction, request.PaymentMethod);
                    mainOrder.OrderLines.ForEach(t => _transactionLineRepository.Add(TransactionLine.Create(transaction,t.Product.Name,t.Count,t.UnitPrice)));
                    _repository.Save();
                    _sender.Send(new RequestForPayTransactionCommand { Id = transaction });
                }
            }

            Sms.PayCart(user.PhoneNumber, user.FirstName + " " + user.LastName);

            _repository.Update(mainOrder);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
