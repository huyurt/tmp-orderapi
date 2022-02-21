using OrderApi.EntityFrameworkCore;

namespace OrderApi.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly OrderApiDbContext _context;

        public InitialHostDbBuilder(OrderApiDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
