using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AppointmentBooking.Models;


namespace AppointmentBooking.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AppDbContext _context = null;
        public DbSet<T> table = null;

        public GenericRepository()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnectionString");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                             .UseSqlServer(connectionString)
                             .Options;

            _context = new AppDbContext(options);

            table = _context.Set<T>();
        }
        public GenericRepository(AppDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
