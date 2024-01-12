﻿using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Product.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Product.Entities;

[EntityTypeConfiguration(typeof(CommentConfig))]
public class Comment : Entity
{
    #region Properties
    public Title Title { get; private set; }

    public Description Text { get; private set; }

    public string UserName { get; private set; }

    public PhoneNumber UserPhoneNumber { get; private set; }

    public int ProductId { get; private set; }

    public bool IsDelete { get; private set; }

    public Product Product { get; private set; } 
    #endregion

    #region Constructors And Factories

    private Comment() { }
    public Comment(string title, string text, string userName, string phoneNumber, int productId)
    {
        Title = new Title(title);
        Text = new Description(text);
        UserName = userName;
        UserPhoneNumber = new PhoneNumber(phoneNumber);
        ProductId = productId;
        CreateAt = DateTime.Now;
    }
    public static Comment Create(string title, string text, string userName, string phoneNumber, int productId)
    {
        return new Comment(title, text, userName, phoneNumber, productId);
    } 
    #endregion

    #region Command
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    } 
    #endregion
}