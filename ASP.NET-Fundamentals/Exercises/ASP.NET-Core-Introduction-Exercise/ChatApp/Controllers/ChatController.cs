namespace ChatApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models.Message;

public class ChatController : Controller
{
    private static readonly IList<KeyValuePair<string, string>> s_messages =
        new List<KeyValuePair<string, string>>();

    public IActionResult Index() => RedirectToAction(nameof(Show));

    [HttpGet]
    public IActionResult Show() 
        => View(new ChatViewModel
        {
            Messages = s_messages.Select(kvp => new MessageViewModel
            {
                Sender = kvp.Key,
                MessageText = kvp.Value
            }).ToList()
        });

    [HttpPost]
    public IActionResult Send(ChatViewModel chat)
    {
        s_messages.Add(new KeyValuePair<string, string>(chat.CurrentMessage.Sender, chat.CurrentMessage.MessageText));
        return RedirectToAction(nameof(Show));
    }
}