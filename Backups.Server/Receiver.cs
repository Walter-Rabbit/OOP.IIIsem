﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Backups.Tools;

namespace Backups.Server
{
    public static class Receiver
    {
        public static void Receive(IPAddress ipAddress, int port)
        {
            var tcpListener = new TcpListener(
                ipAddress ?? throw new BackupsException("IpAddress is null"),
                port);

            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                var streamReader = new StreamReader(tcpClient.GetStream());
                string mode = streamReader.ReadLine();

                if (mode == "send")
                {
                    string fileSize = streamReader.ReadLine();
                    string fileName = streamReader.ReadLine();

                    int length = Convert.ToInt32(fileSize);
                    byte[] buffer = new byte[length];

                    tcpClient.GetStream().Read(buffer, 0, length);

                    using var fileStream = new FileStream(fileName ?? string.Empty, FileMode.Create);
                    fileStream.Write(buffer, 0, buffer.Length);
                    fileStream.Flush();
                    fileStream.Close();
                    
                    tcpClient.Close();
                }

                if (mode == "take")
                {
                    string fileName = streamReader.ReadLine();
                    string targetFile = streamReader.ReadLine();

                    byte[] bytes = File.ReadAllBytes(fileName);

                    var streamWriter = new StreamWriter(tcpClient.GetStream());
                    streamWriter.WriteLine(bytes.Length.ToString());
                    streamWriter.Flush();

                    streamWriter.WriteLine(targetFile);
                    streamWriter.Flush();

                    tcpClient.Client.SendFile(fileName);
                    streamWriter.Flush();
                    File.Delete(fileName);

                    streamWriter.Close();
                    tcpClient.Close();
                }
            }
        }
    }
}