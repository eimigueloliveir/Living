﻿using Living.Domain.Features.Users;
using Microsoft.AspNetCore.Identity;

#pragma warning disable CS8765

namespace Living.Domain.Entities.Users;
public class UserClaim : IdentityUserClaim<Guid>
{
    public new Guid Id { get; init; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }
    public User User { get; set; }
}
