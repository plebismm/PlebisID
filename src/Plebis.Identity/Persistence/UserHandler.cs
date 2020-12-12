using MediatR;
using Microsoft.AspNetCore.Identity;
using Plebis.Core;
using Plebis.Core.EventBus;
using Plebis.Identity.Data;
using Plebis.Identity.Domain;
using Plebis.Identity.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Plebis.Identity.Persistence
{
    public class UserHandler : INotificationHandler<CreateUser>, INotificationHandler<VerifyUserEmail>
    {
        private readonly IEventsService<User, Guid> eventsService;
        readonly UserManager<PlebisUser> userManager;
        public UserHandler(IEventsService<User, Guid> eventsService, UserManager<PlebisUser> userManager)
        {
            this.userManager = userManager;
            this.eventsService = eventsService;
        }

        public async Task Handle(CreateUser notification, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(notification.Email))
                throw new ValidationException("Unable to create user", new ValidationError(nameof(CreateUser.Email), "email cannot be empty"));

            var exists = (await userManager.FindByEmailAsync(notification.Email)) != null;
            if (exists)
                throw new ValidationException("Unable to create user", new ValidationError(nameof(CreateUser.Email), "email already exists"));

            await userManager.CreateAsync(new PlebisUser
            {
                UserName = notification.Email,
                FamilyName = notification.FamilyName,
                GivenName = notification.GivenName,
                Email = notification.Email
            }, notification.Password);

            var domainUser = new User(notification.Id, notification.GivenName, notification.FamilyName, notification.Email);
            await eventsService.PersistAsync(domainUser);
        }

        public async Task Handle(VerifyUserEmail notification, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(notification.UserId.ToString("d"));
            var result = await userManager.ConfirmEmailAsync(user, notification.Code);

            if (result.Succeeded)
            {
                var domainUser = await eventsService.RehydrateAsync(notification.UserId);
                domainUser.ConfirmEmail();
                await eventsService.PersistAsync(domainUser);
            }

        }
    }

}
