﻿namespace Producer
{
    public class SenderConfiguration
    {
        public static readonly int Port = 5672;
        public static readonly string HostName = "localhost";
        public static readonly string UserName = "guest";
        public static readonly string Password = "guest";
        public static readonly string BookQueue = "BookQueue";
    }
}
