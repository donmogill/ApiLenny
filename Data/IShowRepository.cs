using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<List<ShowDto>> GetAll();
}