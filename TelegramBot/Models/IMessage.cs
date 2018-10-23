using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Passport;
using Telegram.Bot.Types.Payments;

namespace TelegramBot.Models
{
    public interface IMessage
    {

        int MessageId { get; set; }

        User From { get; set; }

        DateTime Date { get; set; }

        Chat Chat { get; set; }

        bool IsForwarded { get; }

        User ForwardFrom { get; set; }

        Chat ForwardFromChat { get; set; }

        int ForwardFromMessageId { get; set; }

        string ForwardSignature { get; set; }

        DateTime? ForwardDate { get; set; }

        Message ReplyToMessage { get; set; }

        DateTime? EditDate { get; set; }

        string MediaGroupId { get; set; }

        string AuthorSignature { get; set; }

        string Text { get; set; }

        MessageEntity[] Entities { get; set; }

        IEnumerable<string> EntityValues { get; }

        MessageEntity[] CaptionEntities { get; set; }

        IEnumerable<string> CaptionEntityValues { get; }

        Audio Audio { get; set; }

        Document Document { get; set; }

        Animation Animation { get; set; }

        Game Game { get; set; }

        PhotoSize[] Photo { get; set; }

        Sticker Sticker { get; set; }

        Video Video { get; set; }

        Voice Voice { get; set; }

        VideoNote VideoNote { get; set; }

        string Caption { get; set; }

        Contact Contact { get; set; }

        Location Location { get; set; }

        Venue Venue { get; set; }

        User[] NewChatMembers { get; set; }

        User LeftChatMember { get; set; }

        string NewChatTitle { get; set; }

        PhotoSize[] NewChatPhoto { get; set; }

        bool DeleteChatPhoto { get; set; }

        bool GroupChatCreated { get; set; }

        bool SupergroupChatCreated { get; set; }

        bool ChannelChatCreated { get; set; }

        long MigrateToChatId { get; set; }

        long MigrateFromChatId { get; set; }

        Message PinnedMessage { get; set; }

        Invoice Invoice { get; set; }

        SuccessfulPayment SuccessfulPayment { get; set; }

        string ConnectedWebsite { get; set; }

        PassportData PassportData { get; set; }

        MessageType Type { get; }
    }
}
