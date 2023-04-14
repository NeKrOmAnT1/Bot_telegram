using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.GettingUpdates;

internal class Program
{
    static public string token = "6248732398:AAGDMlNDSaouWjYwb5q_5ojnZNWPz-kvQwc";
    static public BotClient api = new BotClient(token);



    
    private static void Main(string[] args)
    {
        var updates = api.GetUpdates();
        while (true)
        {
            if (updates.Any())
            {
                foreach (var item in updates)
                {
                    if (item.Message.Text.ToLower() == "/start")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Hello World");
                    }
                    else if (item.Message.Text.ToLower() == "/joke")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Хорошая шутка. О карьере в Stand Up не задумывался?");
                    }
                    else if (item.Message.Text.ToLower() == "нет")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Ну, и пошел тогда в досрочный отпуск, петушара");
                    }        
                    
                }

                var offset = updates.Last().UpdateId + 1;
                updates = api.GetUpdates(offset);
            }
            else
            {
                updates = api.GetUpdates(); 
            }
        }
    }
}