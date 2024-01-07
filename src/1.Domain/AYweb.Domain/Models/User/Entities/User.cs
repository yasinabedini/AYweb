﻿using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AYweb.Domain.Models.User.ValueObjects;
using System.Drawing;

namespace AYweb.Domain.Models.User.Entities
{
    public class User : AggregateRoot<int>
    {
        #region Properties
        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public string? Email { get; private set; }

        public bool PhoneNumberConfrimation { get; private set; }

        public bool EmailConfrimation { get; private set; }

        public string Password { get; private set; }

        private VerificationCode VerificationCode { get; set; }

        public bool IsActive { get; private set; }

        public bool IsDelete { get; private set; }

        //public List<UserRoles> RolesList { get; set; }

        #endregion

        #region Constructors And Factories
        private User() { }
        public User(string firstName, string lastName, string phoneNumber, string hashPassword)
        {
            FirstName = new FirstName(firstName);
            LastName = new LastName(lastName);
            PhoneNumber = new PhoneNumber(phoneNumber);

            Random random = new Random();
            VerificationCode = new VerificationCode(random.Next(111111, 999999).ToString());

            Password = hashPassword;
            CreateAt = DateTime.Now;
            IsActive = true;
        }

        public static User Create(string firstName, string lastName, string phoneNumber, string hashPassword)
        {
            return new User(firstName, lastName, phoneNumber, hashPassword);
        }
        #endregion

        #region Command

        private void Modified()
        {
            ModifiedAt = DateTime.Now;
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = new FirstName(firstName);
            Modified();                            
        }

        public void ChangeLastName(string lastName)
        {
            LastName = new LastName(lastName);
            Modified();
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = new PhoneNumber(phoneNumber);
            PhoneNumberConfrimation = false;
            Modified();
        }

        public void ChangePassword(string hashPassword)
        {
            Password = hashPassword;
            Modified();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Modified();
        }

        public void ConfirmEmail()
        {
            EmailConfrimation = true;
            Modified();
        }

        public void ConfirmPhoneNumber()
        {
            PhoneNumberConfrimation = true;
            Modified();
        }

        private void ChangeVerificationCode()
        {
            Random random = new Random();
            VerificationCode = new VerificationCode(random.Next(111111, 999999).ToString());
            Modified();
        }

        public string GetVerificationCode()
        {
            string previousCode = VerificationCode.ToString();
            ChangeVerificationCode();
            return previousCode;
        }

        public void UpdateUser(string? firstName, string? lastName, string? phoneNumber)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                ChangeFirstName(firstName);
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                ChangeLastName(lastName);
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
               ChangePhoneNumber(phoneNumber);
            }            
        }

        public void DeleteUser()
        {
            IsDelete = true;
            Modified();
        }
        #endregion
    }
}
