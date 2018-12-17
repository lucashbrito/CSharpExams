using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Chapter4
{
    public class TransactionsClass
    {
        public void UsingTransactions()
        {
            string connectionString = "";

            using (var transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(
                        @"INSERT INTO People([FirstName], [LastName], [MiddleInitial])
                    VALUES(‘John’, ‘Doe’, null)",
                    connection);
                    SqlCommand command2 = new SqlCommand(
                        @"INSERT INTO People([FirstName], [LastName], [MiddleInitial])
                    VALUES(‘Jane’, ‘Doe’, null)",
                    connection);
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                }
                transactionScope.Complete();
            }

        }

        private class TransactionScope : IDisposable
        {
            public void Complete() { }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
