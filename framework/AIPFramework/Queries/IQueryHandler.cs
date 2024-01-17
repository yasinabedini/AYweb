using AIPFramework.Commands;
using MediatR;

namespace AIPFramework.Queries;
/// <summary>
/// تعریف ساختار مورد نیاز جهت پردازش یک کورئری
/// </summary>
/// <typeparam name="TRequest">نوع کوئری و پارامتر‌های ورودی را تعیین می‌کند</typeparam>
/// <typeparam name="TResponse">نوع داده‌های بازگشتی را تعیین می‌کند</typeparam>
public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
{

}

