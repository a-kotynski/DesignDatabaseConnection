using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.udemy.com/course/csharp-intermediate-classes-interfaces-and-oop/learn/lecture/2480692#content
namespace DesignDatabaseConnection
{
    public abstract class DbConnection
    {
        public DbConnection(string connectionString)
        {
            try
            {
                if (connectionString == null)
                {
                    throw new InvalidOperationException("It's a NULL.");
                }
                else if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentException("It's a whitespace or empty.");
                }
                else
                {
                    ConnectionString = connectionString;
                }
            }
            catch (InvalidOperationException)
            {

                throw;
            }
        }

        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }
        public abstract void DatabaseOpen();
        public abstract void DatabaseClose();
    }
    public class DbCommand
    {
        public DbCommand(DbConnection dbConnection, string instruction)
        {
            try
            {
                if (dbConnection == null)
                {
                    throw new InvalidOperationException("It's a NULL.");
                }
                else if (String.IsNullOrWhiteSpace(instruction))
                {
                    throw new ArgumentException("It's a whitespace or empty.");
                }
                else
                {
                    DbConnection = dbConnection;
                    Instruction = instruction;
                }
            }
            catch (InvalidOperationException)
            {

                throw;
            }
        }
        public DbConnection DbConnection { get; set; }
        public string Instruction { get; set; }

        public void Execute()
        {
            DbConnection.DatabaseOpen();
            Console.WriteLine($"Instruction: {Instruction}");
            DbConnection.DatabaseClose();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
