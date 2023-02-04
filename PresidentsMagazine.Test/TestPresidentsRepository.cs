using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PresidentsMagazine.Data;
using PresidentsMagazine.Repositories.PresidentsRepository;

namespace PresidentsMagazine.Test
{
    public class TestPresidentsRepository
    {
        [Fact]
        public async Task GetPresidentByIdAsync_EmptyGuid_ThrowException()
        {
            //Arrange            
            var services = new ServiceCollection()
                                                    .AddDbContext<PresidentsMagazineContext>((Options =>
                                                    {
                                                        Options.UseSqlite(new SqliteConnection(
                                                                         (new SqliteConnectionStringBuilder { DataSource = ":memory:" }).ConnectionString)
                                                                          );
                                                    }))
                                                    .AddLogging()
                                                    .AddScoped<IPresidentsRepository, PresidentsRepository>()
                                                    .BuildServiceProvider();

            var presidentsRepository = services.GetRequiredService<IPresidentsRepository>();
            //Assert
            await Assert.ThrowsAsync<ArgumentException>( //Act
                                                        () => presidentsRepository.GetByIdAsync(Guid.Empty)
                                                        );
        }
       
    }
}
