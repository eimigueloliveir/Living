﻿namespace Living.Domain.Features.Users.Constants;
public static class UserErrors
{
    public static Notification NOT_FOUND => new("USER");
    public static Notification PASSWORD_INVALID => new("USER");
    public static Notification EMAIL_ALREADY_IN_USE => new("USER");
    public static Notification USERNAME_ALREADY_IN_USE => new("USER");
    public static Notification LOCKED_OUT => new("USER");
    public static Notification NOT_ALLOWED => new("USER");
    public static Notification REQUIRES_TWO_FACTOR => new("USER");
    public static Notification INVALID_REFRESH_TOKEN => new("USER");
    public static Notification INVALID_USER_ID => new("USER");

    public static Notification NAME_IS_REQUIRED => new("USER");
    public static Notification NAME_LENGTH_INVALID => new("USER");
    public static Notification USERNAME_IS_REQUIRED => new("USER");
    public static Notification USERNAME_LENGTH_INVALID => new("USER");

    public static Notification EMAIL_IS_REQUIRED => new("USER");
    public static Notification INVALID_EMAIL => new("USER");

    public static Notification EMAIL_LENGTH_INVALID => new("USER");
}
