using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Order.Entities;
using System.ComponentModel;

namespace AYweb.Domain.Models.Product.Entities;

public class Product : AggregateRoot
{
    #region Properties
    public string Name { get; private set; }

    public Description ShortDescription { get; private set; }

    public Description MainDescription { get; private set; }

    public Description SeoDescription { get; private set; }

    public int Price { get; private set; }

    public string ImageName { get; private set; }

    public int DiscountedPercent { get; private set; }

    public int Inventory { get; private set; }

    public bool IsSpecial { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsDelete { get; private set; }

    public IReadOnlyList<OrderLine> OrderLines { get; set; }
    public IReadOnlyList<Comment> Comments { get; set; }
    public List<Feature> Features { get; set; }    
    #endregion

    #region Constructor and factories
    private Product() { }
    public Product(string name, string shortDescription, string mainDescription, string seoDescription, string imageName, int price, int discountedPercent, int inventory, bool isSpecial)
    {
        Name = name;
        ShortDescription = new Description(shortDescription);
        MainDescription = new Description(mainDescription);
        SeoDescription = new Description(seoDescription);
        ImageName = imageName;
        Price = price;
        DiscountedPercent = discountedPercent;
        Inventory = inventory;
        IsSpecial = isSpecial;
        IsDelete = false;
        IsActive = true;
        CreateAt = DateTime.Now;
    }
    public static Product Create(string name, string shortDescription, string mainDescription, string seoDescription, string imageName, int price, int discountedPercent, int inventory, bool isSpecial)
    {
        return new Product(name, shortDescription, mainDescription, seoDescription, imageName, price, discountedPercent, inventory, isSpecial);
    }
    #endregion

    #region Command
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeName(string name)
    {
        Name = name;
        Modified();
    }

    public void ChangeShortDescription(string description)
    {
        ShortDescription = new Description(description);
        Modified();
    }

    public void ChangeMainDescription(string description)
    {
        MainDescription = new Description(description);
        Modified();
    }

    public void ChangeSeoDescription(string description)
    {
        SeoDescription = new Description(description);
        Modified();
    }

    public void ChangePrice(int price)
    {
        Price = price;
        Modified();
    }

    public void ChangeIsSpecial(bool isSpecial)
    {
        IsSpecial = IsSpecial;
        Modified();
    }

    public void ChangeDiscountedPercent(int discountedPercent)
    {
        DiscountedPercent = discountedPercent;
        Modified();
    }

    public void ChangeInventory(int inventory)
    {
        Inventory = inventory;
        Modified();
    }

    public void ChangeImageName(string imageName)
    {
        ImageName = imageName;
        Modified();
    }

    public void EnableIsSpecial()
    {
        IsSpecial = true;
        Modified();
    }

    public void DisableIsSpecial()
    {
        IsSpecial = false;
        Modified();
    }

    public void DeleteProduct()
    {
        IsDelete = true;
    }

    public int IncreaseInventory(int amount)
    {
        Inventory += amount;
        Modified();
        return Inventory;
    }

    public int DecreaseInventory(int amount)
    {
        Inventory -= amount;
        Modified();
        return Inventory;
    }

    public int GetPrice()
    {
        return (Price) * (DiscountedPercent / 100);
    }

    public int SalesNumber()
    {
        return OrderLines.Count == 0 ? 0 : OrderLines.Where(t => t.Order.IsApproved).Sum(t => t.Count);
    }

    public void UpdateProduct(string? name, string? shortDescription, string? mainDescription, string? seoDescription, string? imageName, int? price, int? discountedPercent, int? inventory, bool? isSpecial)
    {
        if (!string.IsNullOrEmpty(name)) ChangeName(name);
        if (!string.IsNullOrEmpty(shortDescription)) ChangeShortDescription(shortDescription);
        if (!string.IsNullOrEmpty(mainDescription)) ChangeMainDescription(mainDescription);
        if (!string.IsNullOrEmpty(seoDescription)) ChangeSeoDescription(seoDescription);
        if (!string.IsNullOrEmpty(imageName)) ChangeImageName(imageName);
        if (price.HasValue && price != 0) ChangePrice(price.Value);
        if (discountedPercent.HasValue && discountedPercent != 0) ChangeDiscountedPercent(discountedPercent.Value);
        if (inventory.HasValue && inventory != 0) ChangeInventory(inventory.Value);
        if (isSpecial.HasValue) ChangeIsSpecial(isSpecial.Value);
    }

    #endregion
}
