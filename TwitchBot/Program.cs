// See https://aka.ms/new-console-template for more information

using TwitchBot;
using Microsoft.Extensions.Configuration;

var channel = Environment.GetEnvironmentVariable("CHANNEL");
var oauth_token = Environment.GetEnvironmentVariable("OAUTH_TOKEN");

if (channel != null && oauth_token != null)
{
    var bot = new Bot(channel.Trim(), oauth_token.Trim());
}
else
{
    throw new Exception("Setup incomplete");
}

Console.ReadLine();