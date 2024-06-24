using Microsoft.EntityFrameworkCore;

namespace  MessageReply;

public class MessageReplyService
{
    private readonly MessageReplyDbContext _messageReplyDbContext;

    public MessageReplyService(MessageReplyDbContext messageReplyDbContext)
    {
        _messageReplyDbContext = messageReplyDbContext;
    }

    public async Task<MessageReply> Create(MessageReply messageReply)
    {
        _messageReplyDbContext.MessageReply.Add(messageReply);
        await _messageReplyDbContext.SaveChangesAsync();
        return messageReply;
    }

    public async Task<List<MessageReply>> FindAll()
    {
        return await _messageReplyDbContext.MessageReply.ToListAsync();
    }

    public async Task<MessageReply> FindOne(int MessageID, int replyID)
    {
        return await _messageReplyDbContext.MessageReply.FindAsync(MessageID, replyID);
    }
}