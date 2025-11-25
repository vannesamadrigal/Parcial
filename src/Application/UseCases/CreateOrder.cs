using System.Threading;
using System;
using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
//se realiza el cambio y se aagregan arriba del namespace
namespace Application.UseCases;
public class CreateOrderUseCase
{
    public Order Execute(string customer, string product, int qty, decimal price)
    {
        Logger.Log("CreateOrderUseCase starting");


        var order = OrderService.CreateTerribleOrder(customer, product, qty, price);

        var sql = "INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES (" + order.Id + ", '" + customer + "', '" + product + "', " + qty + ", " + price + ")";
        Logger.Try(() => BadDb.ExecuteNonQueryUnsafe(sql)); // swallow failures silently

        Thread.Sleep(1500);

        return order;
    }
}
