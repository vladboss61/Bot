using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Passport;
using Telegram.Bot.Types.Payments;

namespace TelegramBot.Models
{
    public class MessageAdapter : IMessage
    {
        private readonly Message _message;

        public MessageAdapter(Message message)
        {
            _message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public int MessageId
        {
            get => _message.MessageId;
            set => _message.MessageId = value;
        }

        public User From
        {
            get => _message.From;
            set => _message.From = value;
        }

        public DateTime Date
        {
            get => _message.Date;
            set => _message.Date = value;
        }

        public Chat Chat
        {
            get => _message.Chat;
            set => _message.Chat = value;
        }

        public bool IsForwarded => _message.IsForwarded;

        public User ForwardFrom
        {
            get => _message.ForwardFrom;
            set => _message.ForwardFrom = value;
        }

        public Chat ForwardFromChat
        {
            get => _message.ForwardFromChat;
            set => _message.ForwardFromChat = value;
        }

        public int ForwardFromMessageId
        {
            get => _message.ForwardFromMessageId;
            set => _message.ForwardFromMessageId = value;
        }

        public string ForwardSignature
        {
            get => _message.ForwardSignature;
            set => _message.ForwardSignature = value;
        }

        public DateTime? ForwardDate
        {
            get => _message.ForwardDate;
            set => _message.ForwardDate = value;
        }

        public Message ReplyToMessage
        {
            get => _message.ReplyToMessage;
            set => _message.ReplyToMessage = value;
        }

        public DateTime? EditDate
        {
            get => _message.EditDate;
            set => _message.EditDate = value;
        }

        public string MediaGroupId
        {
            get => _message.MediaGroupId;
            set => _message.MediaGroupId = value;
        }

        public string AuthorSignature
        {
            get => _message.AuthorSignature;
            set => _message.AuthorSignature = value;
        }

        public string Text
        {
            get => _message.Text;
            set => _message.Text = value;
        }

        public MessageEntity[] Entities
        {
            get => _message.Entities;
            set => _message.Entities = value;
        }

        public IEnumerable<string> EntityValues => _message.EntityValues;

        public MessageEntity[] CaptionEntities
        {
            get => _message.CaptionEntities;
            set => _message.CaptionEntities = value;
        }

        public IEnumerable<string> CaptionEntityValues => _message.CaptionEntityValues;

        public Audio Audio
        {
            get => _message.Audio;
            set => _message.Audio = value;
        }

        public Document Document
        {
            get => _message.Document;
            set => _message.Document = value;
        }

        public Animation Animation
        {
            get => _message.Animation;
            set => _message.Animation = value;
        }

        public Game Game
        {
            get => _message.Game;
            set => _message.Game = value;
        }

        public PhotoSize[] Photo
        {
            get => _message.Photo;
            set => _message.Photo = value;
        }

        public Sticker Sticker
        {
            get => _message.Sticker;
            set => _message.Sticker = value;
        }

        public Video Video
        {
            get => _message.Video;
            set => _message.Video = value;
        }

        public Voice Voice
        {
            get => _message.Voice;
            set => _message.Voice = value;
        }

        public VideoNote VideoNote
        {
            get => _message.VideoNote;
            set => _message.VideoNote = value;
        }

        public string Caption
        {
            get => _message.Caption;
            set => _message.Caption = value;
        }

        public Contact Contact
        {
            get => _message.Contact;
            set => _message.Contact = value;
        }

        public Location Location
        {
            get => _message.Location;
            set => _message.Location = value;
        }

        public Venue Venue
        {
            get => _message.Venue;
            set => _message.Venue = value;
        }

        public User[] NewChatMembers
        {
            get => _message.NewChatMembers;
            set => _message.NewChatMembers = value;
        }

        public User LeftChatMember
        {
            get => _message.LeftChatMember;
            set => _message.LeftChatMember = value;
        }

        public string NewChatTitle
        {
            get => _message.NewChatTitle;
            set => _message.NewChatTitle = value;
        }

        public PhotoSize[] NewChatPhoto
        {
            get => _message.NewChatPhoto;
            set => _message.NewChatPhoto = value;
        }

        public bool DeleteChatPhoto
        {
            get => _message.DeleteChatPhoto;
            set => _message.DeleteChatPhoto = value;
        }

        public bool GroupChatCreated
        {
            get => _message.GroupChatCreated;
            set => _message.GroupChatCreated = value;
        }

        public bool SupergroupChatCreated
        {
            get => _message.SupergroupChatCreated;
            set => _message.SupergroupChatCreated = value;
        }

        public bool ChannelChatCreated
        {
            get => _message.ChannelChatCreated;
            set => _message.ChannelChatCreated = value;
        }

        public long MigrateToChatId
        {
            get => _message.MigrateToChatId;
            set => _message.MigrateToChatId = value;
        }

        public long MigrateFromChatId
        {
            get => _message.MigrateFromChatId;
            set => _message.MigrateFromChatId = value;
        }

        public Message PinnedMessage
        {
            get => _message.PinnedMessage;
            set => _message.PinnedMessage = value;
        }

        public Invoice Invoice
        {
            get => _message.Invoice;
            set => _message.Invoice = value;
        }

        public SuccessfulPayment SuccessfulPayment
        {
            get => _message.SuccessfulPayment;
            set => _message.SuccessfulPayment = value;
        }

        public string ConnectedWebsite
        {
            get => _message.ConnectedWebsite;
            set => _message.ConnectedWebsite = value;
        }

        public PassportData PassportData
        {
            get => _message.PassportData;
            set => _message.PassportData = value;
        }

        public MessageType Type => _message.Type;
    }
}
