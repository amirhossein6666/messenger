using  Channel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace PV;
[Route("[controller]")]
[ApiController]
public class PVController
{
    private readonly PVService _pvService;

    public PVController(PVService groupService)
    {
        _pvService = groupService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(PV), typeof(PVExamples))]
    public async Task<PV> Create(PV pv)
    {
        return await _pvService.Create(pv);
    }

    [HttpGet]
    public async Task<List<PV>> FindAll()
    {
        return await _pvService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<PV> FindOne(int ID)
    {
        return await _pvService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<PV> Update(PV pv)
    {
        return await _pvService.Update(pv);
    }
}