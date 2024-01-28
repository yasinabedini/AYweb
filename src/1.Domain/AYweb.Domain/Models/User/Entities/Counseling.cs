using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.User.Entities
{
    public class Counseling:Entity
    {        
        public  string UserName { get; private set; }
        public  PhoneNumber PhoneNumber { get; private set; }
        public  Description Message { get; private set; }
        public  Title Title { get; private set; }
        public  string? Notes { get; private set; }
        public  bool IsCall { get; private set; }

        private Counseling() { }
        public Counseling(string userName, string phoneNumber, string message, string title, string? notes)
        {            
            UserName = userName;
            PhoneNumber = phoneNumber;
            Message = message;
            Title = title;
            Notes = notes;
            IsCall = false;
        }
        public static Counseling Create(string userName, string phoneNumber, string message, string title, string? notes)
        {
            return new Counseling(userName, phoneNumber, message, title, notes);
        }

        private void Modified()
        {
            ModifiedAt = DateTime.Now;
        }

        public void CallSuccess()
        {
            IsCall = true;
            Modified();
        }

        public void SetNotes(string notes)
        {
            Notes = notes;
            Modified();
        }

        public void Delete()
        {
            IsDelete = true;
            Modified();
        }
    }
}
