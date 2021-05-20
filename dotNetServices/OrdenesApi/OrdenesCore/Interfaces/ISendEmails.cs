using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCore.Interfaces
{
    public interface ISendEmails
    {
        public Task<bool> SendEmail(string sender, string body);
    }
}
