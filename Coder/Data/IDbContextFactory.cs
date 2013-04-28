using System.Data.Entity;
namespace Coder.Data
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
