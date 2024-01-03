using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.User;
public class Counseling
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public string Title { get; set; }
    public string? Notes { get; set; }
    public bool IsCall { get; set; }    
}
