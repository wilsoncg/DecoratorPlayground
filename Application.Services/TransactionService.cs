using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransactionService
    {
        public int GenerateNewTransactionId()
        {
            var num = new byte[3];
            RandomNumberGenerator.Create().GetBytes(num);
            return num[0] + num[1] + num[2] + num[3];
        }

        public void UpdateTransactionState(int transactionId, int transactionState)
        {
        }
    }
}
