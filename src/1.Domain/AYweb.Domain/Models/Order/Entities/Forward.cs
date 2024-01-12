using AIPFramework.Entities;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Order.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Order.Entities;

[EntityTypeConfiguration(typeof(ForwardConfig))]
public class Forward : Entity
{
    #region Properties
    public int OrderId { get;private set; }

    public string Province { get; private set; }

    public string City { get; private set; }

    public string PostalCode { get; private set; }

    public string Address { get; private set; }

    public bool IsForward { get; private set; }

    public string? TrackingCode { get; private set; }

    public string TransfereeName { get; private set; }

    public Order Order { get; set; }

    #endregion

    #region Constructor And Factories
    private Forward() { }
    public Forward(int orderId, string province, string city, string postalCode, string address, string trasnfereeName)
    {
        OrderId = orderId;
        Province = province;
        City = city;
        PostalCode = postalCode;
        Address = address;
        TransfereeName = trasnfereeName;
        IsForward = false;
        CreateAt = DateTime.Now;
    }

    public static Forward Create(int orderId, string province, string city, string postalCode, string address, string trasnfereeName)
    {
        return new Forward(orderId, province, city, postalCode, address, trasnfereeName);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void SetTrackingCode(string trackingCode)
    {
        TrackingCode = trackingCode;
        IsForward = true;
        Modified();
    }

    public void SetOrderId(int orderId)
    {
        OrderId = orderId;
        Modified();
    }
    #endregion
}
