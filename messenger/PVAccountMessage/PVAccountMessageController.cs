using  GroupAccountMessage;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace  PVAccountMessage;
[Route("[controller]")]
[ApiController]
public class PVAccountMessageController: ControllerBase
{
    private readonly PVAccountMessageService _pvAccountMessageService;

    public PVAccountMessageController(PVAccountMessageService pvAccountMessageService)
    {
        _pvAccountMessageService = pvAccountMessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(PVAccountMessage), typeof(PVAccountMessageExamples))]
    public async Task<PVAccountMessage> Create(PVAccountMessage pvAccountMessage)
    {
        return await _pvAccountMessageService.Create(pvAccountMessage);
    }

    [HttpGet]
    public async Task<List<PVAccountMessage>> FindAll()
    {
        return await _pvAccountMessageService.FindAll();
    }

    [HttpGet("{PVID}/{AccountID}/{MessageID}")]
    public async Task<PVAccountMessage> FindOne(int PVID, int AccountID, int MessageID)
    {
        return await _pvAccountMessageService.FindOne(PVID, AccountID, MessageID);
    }

    [HttpPatch]
    public async Task<PVAccountMessage> Update(PVAccountMessage updatedPvAccountMessage)
    {
        return await _pvAccountMessageService.Update(updatedPvAccountMessage);
    }
}