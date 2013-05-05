﻿using CQRS.Base.DDD.Domain.Annotations;
using CQRS.Base.DDD.Domain.Support;

namespace CQRS.Security.Domain
{
    [DomainFactory]
    public class UserFactory
    {
        public InjectorHelper Helper { get; set; }

        public User CreateUser(string email, string password, string salt)
        {
            var user = new User(email, password, salt);
            Helper.InjectDependencies(user);
            return user;
        }

    }
}
