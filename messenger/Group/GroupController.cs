using messenger.Channel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace messenger.Group;

[Route("[controller]")]
[ApiController]

public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(Group), typeof(GroupExamples))]
    public async Task<Group> Create(Group group)
    {
        return await _groupService.Create(group);
    }

    [HttpGet]
    public async Task<List<Group>> FindAll()
    {
        return await _groupService.FindAll();
    }

    [HttpGet("ID")]
    public async Task<Group> FindOne(int ID)
    {
        return await _groupService.FindOne(ID);
    }

    [HttpPatch]
    public async Task<Group> Update(Group account)
    {
        return await _groupService.Update(account);
    }
}