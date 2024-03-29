﻿using System.Net;
using Backups.Interfaces;

namespace Backups.Client.Interfaces
{
    public interface IServerArchiveService : IArchiveService
    {
        string IpAddress { get; }
        int Port { get; }
    }
}