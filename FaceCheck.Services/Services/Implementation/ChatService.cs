using AutoMapper;
using FaceCheck.Entity.Models;
using FaceCheck.Repository;
using FaceCheck.Services.Abstract;
using FaceCheck.Services.Models;

namespace FaceCheck.Services.Implementation;

public class ChatService :IChatService
{
    private readonly IRepository<Chat> chatRepository;
    private readonly IMapper mapper;
    public ChatService(IRepository<Chat> chatRepository, IMapper mapper)
    {
        this.chatRepository = chatRepository;
        this.mapper = mapper;
    }

    public void DeleteChat(Guid id)
    {
        var chatToDelete =chatRepository.GetById(id);
        if (chatToDelete == null)
        {
            throw new Exception("Chat not found");
        }
        chatRepository.Delete(chatToDelete);
    }

    public ChatModel GetChat(Guid id)
    {
        var chat =chatRepository.GetById(id);
        return mapper.Map<ChatModel>(chat);
    }

    public PageModel<ChatPreviewModel> GetChats(int limit = 20, int offset = 0)
    {
        var chat =chatRepository.GetAll();
        int totalCount =chat.Count();
        var chunk=chat.OrderBy(x=>x.Name).Skip(offset).Take(limit);

        return new PageModel<ChatPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ChatPreviewModel>>(chat),
            TotalCount = totalCount
        };
    }

    public ChatModel UpdateChat(Guid id, UpdateChatModel chat)
    {
        var existingChat = chatRepository.GetById(id);
        if (existingChat == null)
        {
            throw new Exception("Chat not found");
        }
        existingChat.Name=chat.Name;
        existingChat = chatRepository.Save(existingChat);
        return mapper.Map<ChatModel>(existingChat);
    }
    public ChatModel CreateChat(ChatModel chatModel)
    {
        if(chatRepository.GetAll(x=>x.Id==chatModel.Id).FirstOrDefault()!=null)
       {
        throw new Exception ("Attempt to create a non-unique object!");
       }
       ChatModel create=new ChatModel();
       create.Name=chatModel.Name;
       chatRepository.Save(mapper.Map<Entity.Models.Chat>(create));
       return create;

    }
}