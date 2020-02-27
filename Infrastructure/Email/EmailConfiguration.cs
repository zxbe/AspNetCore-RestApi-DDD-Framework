﻿namespace Infrastructure.Email
{
    public class EmailConfiguration
    {
        public string EmailFrom { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string SslProtocol { get; set; }
    }
}