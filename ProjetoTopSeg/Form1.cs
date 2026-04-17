using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using EI.SI;

namespace ProjetoTopSeg
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private ProtocolSI protocolSI;
        private Thread receiveThread;

        public Form1()
        {
            InitializeComponent();

            protocolSI = new ProtocolSI();

            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect("127.0.0.1", 50003);
                networkStream = tcpClient.GetStream();

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ligar ao servidor: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                    if (bytesRead == 0)
                    {
                        listBox1.Invoke((MethodInvoker)(() =>
                            listBox1.Items.Add("Servidor desconectado")));
                        break;
                    }

                    if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                    {
                        string msg = protocolSI.GetStringFromData();

                        listBox1.Invoke((MethodInvoker)(() =>
                        {
                            listBox1.Items.Add(msg);
                        }));
                    }
                    else if (protocolSI.GetCmdType() == ProtocolSICmdType.EOF)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (listBox1.IsHandleCreated)
                {
                    listBox1.Invoke((MethodInvoker)(() =>
                        MessageBox.Show("Erro receção: " + ex.Message)));
                }
            }
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            string msg = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            try
            {
                byte[] pacote = protocolSI.Make(ProtocolSICmdType.DATA, msg);
                networkStream.Write(pacote, 0, pacote.Length);

                listBox1.Items.Add("Eu: " + msg);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                byte[] pacote = protocolSI.Make(ProtocolSICmdType.EOF);
                networkStream.Write(pacote, 0, pacote.Length);

                networkStream.Close();
                tcpClient.Close();
            }
            catch { }
        }
    }
}