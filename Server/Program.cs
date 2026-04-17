using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using ProtocolSI;

class Servidor
{
    static public List<NetworkStream> streams = new List<NetworkStream>();
    static private int countClients = 0;

    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 50003);
        listener.Start();
        Console.WriteLine("[Servidor] listening on port 500003...");

        while (true)
        {
            TcpClient tcpCliente = listener.AcceptTcpClient();

            countClients++;
            int clientNumber = countClients;

            Console.WriteLine($"[Servidor] Cliente {clientNumber} conectado");

            NetworkStream networkStream = tcpCliente.GetStream();
            streams.Add(networkStream);

            Thread t = new Thread(() => TratarCliente(networkStream, clientNumber));
            t.IsBackground = true;
            t.Start();
        }
    }

    static void TratarCliente(NetworkStream networkStream, int clientNumber)
    {
        ProtocolSI protocolSI = new ProtocolSI();

        try
        {
            while (true)
            {
                // Lê a mensagem que chegou do cliente
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                if (protocolSI.GetCmdType() == ProtocolSICmdType.MESSAGE)
                {
                    string mensagem = protocolSI.GetStringFromData();
                    Console.WriteLine($"Cliente {clientNumber}: " + mensagem);

                    EnviarParaTodos(mensagem, networkStream);
                }
                else if (protocolSI.GetCmdType() == ProtocolSICmdType.EOF)
                {
                    Console.WriteLine("[Servidor] Cliente desligou.");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Servidor] Erro: " + ex.Message);
        }
        finally
        {
            streams.Remove(networkStream);
            networkStream.Close();
        }
    }

    static void EnviarParaTodos(string mensagem, NetworkStream remetente)
    {
        ProtocolSI protocolSI = new ProtocolSI();
        byte[] pacote = protocolSI.Make(ProtocolSICmdType.MESSAGE, mensagem);

        foreach (NetworkStream ns in streams)
        {
            if (ns == remetente) continue;

            try
            {
                ns.Write(pacote, 0, pacote.Length);
            }
            catch
            {
                Console.WriteLine("[Servidor] Falhou ao enviar para um cliente.");
            }
        }
    }
}