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
    public class DbCommand : DbConnection
    {
        public DbCommand(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void DatabaseOpen()
        {
            throw new NotImplementedException();
        }
        public override void DatabaseClose()
        {
            throw new NotImplementedException();
        }
        public void Run()
        {
            Console.WriteLine(ConnectionString);
            Console.ReadLine();
        }
        public void Execute()
        {
            DatabaseOpen();
            Run();
            DatabaseClose();
        }
        public void ExecuteNoDb()
        {
            Run();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DbCommand command = new DbCommand("instruction?");
            command.ExecuteNoDb();
        }
    }
}
