﻿using Living.Application.UseCases.Users.Login;
using Living.Application.UseCases.Users.Register;
using Living.Domain.Features.Users.Constants;

namespace Living.Tests.Setup;

#pragma warning disable S101
#pragma warning disable MA0048

public partial class SetupWebAPI
{
    protected async Task<Guid> LoginAsync(string? permission = null)
    {
        var registerUserCommand = Fixture.Create<RegisterUserCommand>();
        var userId = await RegisterAsync(registerUserCommand);

        var cookies = await LoginWebAPIAsync(registerUserCommand.Email, registerUserCommand.Password);

        var user = await UserRepository.DBSet()
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null)
            throw new Exception("User not found");

        if (permission is not null)
            user.AddClaim(UserClaimsTokens.PERMISSION, permission);

        await UserRepository.CommitAsync();

        AddCookies(cookies);

        return userId;
    }

    private async Task<Guid> RegisterAsync(RegisterUserCommand registerUserCommand)
    {
        var responseRegister = await PostAsync<BaseResponse<Guid>>("/api/auth/register", registerUserCommand);

        if (responseRegister.HasNotifications)
            throw new Exception(responseRegister.Notifications.ToString());

        return responseRegister.Data;
    }

    private async Task<ICollection<Cookie>> LoginWebAPIAsync(string email, string password)
    {
        var command = new LoginUserCommand
        {
            EmailOrUsername = email,
            Password = password,
        };

        var responseLogin = await Http.PostAsJsonAsync("/api/auth/login", command);

        responseLogin.StatusCode.Should().Be(HttpStatusCode.OK);

        return responseLogin.GetCookies();
    }
}
