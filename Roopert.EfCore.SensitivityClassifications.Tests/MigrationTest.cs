using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace Roopert.EfCore.SensitivityClassifications.Tests
{
    public class UnitTest1 : MigrationsTestBase<UnitTest1.MigrationsSqlServerFixture>
    {
        [Fact]
        public void Add_Classification()
        {
            var builder = new ModelBuilder(new ConventionSet());
            builder.Entity("Person", e =>
            {
                e.Property<int>("Id");
                e.Property<string>("LastName")
                    .HasAnnotation("SensitivityClassification", new SensitivityClassificationItem);
            });


            await base.Create_table();

            AssertSql(
                """
                CREATE TABLE "People" (
                    "Id" INTEGER NOT NULL CONSTRAINT "PK_People" PRIMARY KEY AUTOINCREMENT,
                    "Name" TEXT NULL
                );
                """);
        }

        public class MigrationsSqlServerFixture : MigrationsFixtureBase
        {
            protected override string StoreName
                => nameof(MigrationsSqlServerTest);

            protected override ITestStoreFactory TestStoreFactory
                => SqlServerTestStoreFactory.Instance;

            public override RelationalTestHelpers TestHelpers
                => SqlServerTestHelpers.Instance;

            protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
                => base.AddServices(serviceCollection)
                    .AddScoped<IDatabaseModelFactory, SqlServerDatabaseModelFactory>();
        }
    }
}