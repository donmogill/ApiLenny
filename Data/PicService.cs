using Microsoft.EntityFrameworkCore;

public class PicService
{
    public IPicRepository _repo { get; }

    public PicService(IPicRepository repo)
    {
        _repo = repo;
    }

    public int GetNextDisplayOrder()
    {
        var maxDisplayOrder = _repo.GetAllSync().Result.MaxBy(p => p.DisplayOrder);

        if (maxDisplayOrder == null)
        {
            return 1;
        }

        return maxDisplayOrder.DisplayOrder + 1;
    }

}