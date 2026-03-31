using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

// TODO Phase 7: Implement with Betalgo.Ranul.OpenAI
public class ChatbotService : IChatbotService
{
    public Task<string> AskAsync(string userMessage, List<(string Role, string Content)> history)
    {
        throw new NotImplementedException("Chatbot service sẽ được triển khai ở Giai đoạn 7.");
    }
}
