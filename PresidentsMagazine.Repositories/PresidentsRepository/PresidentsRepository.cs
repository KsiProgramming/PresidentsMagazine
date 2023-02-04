using Microsoft.Extensions.Logging;
using PresidentsMagazine.Core.Entities;
using PresidentsMagazine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentsMagazine.Repositories.PresidentsRepository
{
    public class PresidentsRepository : IPresidentsRepository
    {
        private ILogger<PresidentsRepository> _Logger;
        private PresidentsMagazineContext _Db;
        public PresidentsRepository(ILogger<PresidentsRepository> aLogger, PresidentsMagazineContext aDb)
        {
            _Logger = aLogger;
            _Db = aDb ?? throw new ArgumentNullException(nameof(aDb));

        }

        public async Task<PresidentEntity> GetByIdAsync(Guid? aId)
        {
            _Logger.LogInformation($"Get by Id was requested");
            if (aId == Guid.Empty)
            {
                throw new ArgumentException(nameof(aId));
            }
            return await _Db.Presidents.FindAsync(aId);

        }
    }
}
