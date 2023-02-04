using PresidentsMagazine.Core.Entities;

namespace PresidentsMagazine.Repositories.PresidentsRepository
{
    public interface IPresidentsRepository
    {
        Task<PresidentEntity> GetByIdAsync(Guid? aId);
    }
}