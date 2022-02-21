using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.EntityFrameworkCore
{
    public static class OrderApiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OrderApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OrderApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}