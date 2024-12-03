using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public class BlogRepository : IBlogRepository
    {
        //ссылка на контекст
        private readonly BlogContext _context;

        //метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            //добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            //сщхранение ихменений
            await _context.SaveChangesAsync();
        }
    }
}
