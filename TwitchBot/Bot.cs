using System.Globalization;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchBot;

public class Bot
{
    TwitchClient client;
    
    public Bot(string channel, string token)
    {
        var credentials = new ConnectionCredentials(channel, token);
        var clientOptions = new ClientOptions
        {
            MessagesAllowedInPeriod = 750,
            ThrottlingPeriod = TimeSpan.FromSeconds(30)
        };
        
        var customClient = new WebSocketClient(clientOptions);
        client = new TwitchClient();
        client.Initialize(credentials, channel);
        
        client.OnLog += Client_OnLog;
        client.OnJoinedChannel += Client_OnJoinedChannel;
        client.OnMessageReceived += Client_OnMessageReceived;
        client.OnWhisperReceived += Client_OnWhisperReceived;
        client.OnNewSubscriber += Client_OnNewSubscriber;
        client.OnConnected += Client_OnConnected;

        client.Connect();
    }

    private void Client_OnConnected(object? sender, OnConnectedArgs e)
    {
        Console.WriteLine("Client Connected");
    }

    private void Client_OnNewSubscriber(object? sender, OnNewSubscriberArgs e)
    {
        Console.WriteLine("Client OnNewSubscriber");
    }

    private void Client_OnWhisperReceived(object? sender, OnWhisperReceivedArgs e)
    {
        Console.WriteLine("Client OnWhisperReceived");
    }

    private void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
    {
        Console.WriteLine("Client OnMessageReceived");
    }

    private void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
    {
        Console.WriteLine($"Client joined {e.Channel}");
    }

    private void Client_OnLog(object? sender, OnLogArgs e)
    {
        Console.WriteLine($"{e.DateTime.ToString(CultureInfo.InvariantCulture)}: {e.BotUsername} - {e.Data}");
    }
}