using si730ebu201920124.API.Shared.Domain.Repositories;
using si730ebu201920124.API.Shared.Persistence.Contexts;

namespace si730ebu201920124.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
