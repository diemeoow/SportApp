using Microsoft.EntityFrameworkCore;
using Npgsql;
using SportClub.Data;
using SportClub.Interfaces;

namespace SportClub.Services
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

        public async Task<List<T>> GetAllAsync()
        {
            var query = _dbSet.AsQueryable();

            // Автоматически подключаем навигационные свойства
            var navProperties = _context.Model.FindEntityType(typeof(T))
             .GetNavigations()
             .Select(n => n.Name);

            foreach (var nav in navProperties)
            {
                query = query.Include(nav);
            }

            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
		public async Task AddAsync(T entity)
		{

			var entry = _context.Entry(entity);
			foreach (var nav in entry.Navigations)
			{
				var val = nav.CurrentValue;
				if (val != null)
					_context.Entry(val).State = EntityState.Unchanged;
			}

			try
			{
				await _dbSet.AddAsync(entity);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex) when (ex.InnerException is PostgresException pg && pg.SqlState == "23503")
			{
				throw new InvalidOperationException($"Ошибка добавления: внешний ключ не найден ({pg.ConstraintName}).");
			}
		}

		public async Task UpdateAsync(T entity)
		{
			try
			{
				_dbSet.Update(entity);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
			{
				throw new InvalidOperationException($"Ошибка обновления: внешний ключ не найден ({pgEx.ConstraintName}).");
			}
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			if (entity == null)
				throw new KeyNotFoundException($"Сущность типа {typeof(T).Name} с id={id} не найдена.");

			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
