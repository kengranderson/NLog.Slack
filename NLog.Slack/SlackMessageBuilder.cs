using System;
using System.Threading.Tasks;
using NLog.Slack.Models;

namespace NLog.Slack
{
    public class SlackMessageBuilder
    {
        readonly string _webHookUrl;
        readonly SlackClient _client;
        readonly Payload _payload;

        public SlackMessageBuilder(string webHookUrl)
        {
            _webHookUrl = webHookUrl;
            _client = new SlackClient();
            _payload = new Payload();
        }

        public static SlackMessageBuilder Build(string webHookUrl)
        {
            return new SlackMessageBuilder(webHookUrl);
        }

        public SlackMessageBuilder WithMessage(string message)
        {
            _payload.Text = message;
            return this;
        }

        public SlackMessageBuilder AddAttachment(Attachment attachment)
        {
            _payload.Attachments.Add(attachment);
            return this;
        }

        public SlackMessageBuilder OnError(Action<Exception> error)
        {
            _client.Error += error;
            return this;
        }

        public async Task SendAsync()
        {
            await _client.SendAsync(_webHookUrl, _payload.ToJson()).ConfigureAwait(false);
        }
    }
}