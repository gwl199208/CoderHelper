using System.Data.Entity;

namespace Coder.Data
{
    public class DbContextFactory:IDbContextFactory
    {
        private readonly DbContext context;
        public DbContextFactory()
        {
            context = new Db();
        }
        public DbContext GetContext()
        {
            return context;
        }
    }
}
