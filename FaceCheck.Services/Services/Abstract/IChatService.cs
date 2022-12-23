using FaceCheck.Services.Models;
namespace FaceCheck.Services.Abstract;

public interface IChatService
{
    ChatModel GetChat(Guid id);

    ChatModel UpdateChat(Guid id, UpdateChatModel chat;

    void DeleteChat(Guid id);

    PageModel<ChatPreviewModel> GetChats(int limit = 20, int offset = 0);
    ChatModel CreateChat(ChatModel chatModel);
}