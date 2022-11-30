namespace si730ebu201920124.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}