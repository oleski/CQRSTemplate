﻿using System.Collections.Generic;
using Base.DDD.Infrastructure.Events;
using Base.Mailing;
using Security.Application.Events;
using Security.Infrastructure.Mailing.MailData;

namespace Security.Infrastructure.Mailing.Events
{
    [EventListeners]
    public class UserCreatedEventListener : IEventListener<UserCreatedEvent>
    {
        public IMailMessageFactory MailMessageFactory { get; set; }

        public IMailer Mailer { get; set; }

        [EventListener(IsAsync = true)]
        public void Handle(UserCreatedEvent @event)
        {
            var message = MailMessageFactory.Create(new VerificationEmailData(@event.UserId, @event.VerificationToken));
            message.TemplateName = "verifyEmail";
            message.Recipients = new List<string>
                {
                    @event.Email
                };
            Mailer.Send(message);
        }
    }
}