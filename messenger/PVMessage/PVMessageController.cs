using GroupMessage;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.PVMessage;

[Route("[controller]")]
[ApiController]
public class PVMessageController : ControllerBase
{
    private readonly PVmessageService _PVMessageService;

    public PVMessageController(PVmessageService pVmessageService)
    {
        _PVMessageService = pVmessageService;
    }

    [HttpPost]
    [SwaggerRequestExample(typeof(PVMessage), typeof(PVMessageExamples))]
    public async Task<PVMessage> Create(PVMessage pvMessage)
    {
        return await _PVMessageService.Create(pvMessage);
    }

    [HttpGet]
    public async Task<List<PVMessage>> FindAll()
    {
        return await _PVMessageService.FindAll();
    }

    [HttpGet("{PVID}/{MessageID}")]
    public async Task<PVMessage> FindOne(int PVID, int MessageID)
    {
        return await _PVMessageService.FindOne(PVID , MessageID);
    }


}