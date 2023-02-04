using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PresidentsMagazine.Data;
using PresidentsMagazine.Repositories.PresidentsRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Fact]
        public async Task GetPresidentByIdAsync_EmptyGuid_ThrowExceptionV2()
        {
            //Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            var options = new DbContextOptionsBuilder<PresidentsMagazineContext>().UseSqlite(connection).Options;
            using (var context = new PresidentsMagazineContext(options))
            {
                //context.Database.OpenConnection();
                //context.Database.EnsureCreated();               
                //context.SaveChanges();
            }
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<PresidentsRepository>();
            
            using (var context = new PresidentsMagazineContext(options))
            {
                var presidentsRepository = new PresidentsRepository(logger, context);

                //Assert
                await Assert.ThrowsAsync<ArgumentException>( //Act
                                                            () => presidentsRepository.GetByIdAsync(Guid.Empty)
                                                            );
            }
        }
    }
}
