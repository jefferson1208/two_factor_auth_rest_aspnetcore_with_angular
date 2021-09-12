using System.Threading.Tasks;

namespace TFA.Api.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
