using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using EI.SI;

class Servidor
{
    static public List<NetworkStream> streams = new List<NetworkStream>();
    static private int countClients = 0;

    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 50003);
        listener.Start();
        Console.WriteLine("[Servidor] listening on port 50003...");

        while (true)
        {
            TcpClient tcpCliente = listener.AcceptTcpClient();

            countClients++;
            int clientNumber = countClients;

            Console.WriteLine($"[Servidor] Client {clientNumber} connected");

            NetworkStream networkStream = tcpCliente.GetStream();
            streams.Add(networkStream);

            Thread t = new Thread(() => MessageHandler(networkStream, clientNumber));
            t.IsBackground = true;
            t.Start();
        }
    }

    static void MessageHandler(NetworkStream networkStream, int clientNumber)
    {
        ProtocolSI protocolSI = new ProtocolSI();

        try
        {
            while (true)
            {
                networkStream.ReadExactly(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                {
                    string mensagem = protocolSI.GetStringFromData();
                    Console.WriteLine($"Cliente {clientNumber}: {mensagem}");

                    Send(mensagem, networkStream);
                }
                else if (protocolSI.GetCmdType() == ProtocolSICmdType.EOF)
                {
                    Console.WriteLine("[Servidor] Client disconnected.");
                    break;
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("[Servidor] Error: " + exception.Message);
        }
        finally
        {
            streams.Remove(networkStream);
            networkStream.Close();
        }
    }

    static void Send(string mensagem, NetworkStream sender)
    {
        ProtocolSI protocolSI = new ProtocolSI();
        byte[] pacote = protocolSI.Make(ProtocolSICmdType.DATA, mensagem);

        foreach (NetworkStream ns in streams)
        {
            if (ns == sender) continue;

            try
            {
                ns.Write(pacote, 0, pacote.Length);
            }
            catch
            {
                Console.WriteLine("[Servidor] Failed sending the message to the client.");
            }
        }
    }
}