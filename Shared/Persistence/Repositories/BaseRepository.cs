using si730ebu201920124.API.Shared.Persistence.Contexts;

namespace si730ebu201920124.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}