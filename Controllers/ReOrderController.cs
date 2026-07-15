using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Reader;
using SQLitePCL;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/pics/reorder")]
public class ReorderController : ControllerBase
{
    readonly private IPicRepository _picRepository;
    public ReorderController(IPicRepository picRepository)
    {
        _picRepository = picRepository;
    }

    public class ReorderRequest
    {
        public required List<int> ids { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> ReOrder(int[] ids)
    {
        int newOrder = 1;
        foreach (int id in ids)
        {
            // get pic from database
            var pic = await _picRepository.Get(id);

            var newPicDto = new PicDto(pic.Id, pic.Filename, newOrder);          
            newOrder++;
            
            await _picRepository.Update(newPicDto);
        }
        
        return Ok(ids);

    }
}
