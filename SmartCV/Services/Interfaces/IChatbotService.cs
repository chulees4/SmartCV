namespace SmartCV.Services.Interfaces;

public interface IChatbotService
{
    Task<string> AskAsync(string userMessage, List<(string Role, string Content)> history);
}
