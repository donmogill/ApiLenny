using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<IEnumerable<ShowEntity>> GetAll();
}