﻿namespace Kurstest.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string Email , string Subject , string message);
    }
}
