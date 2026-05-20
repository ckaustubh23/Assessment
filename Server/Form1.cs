using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class Form1 : Form
    {
        TcpListener server;
        int _port = 5000;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Start.Enabled = false;
                server = new TcpListener(IPAddress.Any, _port);
                server.Start();

                Log("Server Started...", Color.Black);

                while (true) 
                { 
                    TcpClient client = await server.AcceptTcpClientAsync(); 
                    Log("Client connected", Color.Green); 
                    _ = Task.Run(() => HandleClient(client)); 
                }
            }
            catch (SocketException)
            {
                Log("Server stopped.", Color.Red);
            }
            catch (Exception ex)
            {
                Log("Error : " + ex.Message, Color.Red);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        Log("Client Disconnected", Color.Purple);
                        break;
                    }

                    //string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    string encryptedRequest = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    string request = EncryptionHelper.Decrypt(encryptedRequest);
                    Log("Received : " + request, Color.Blue);

                    string[] parts = request.Split('-');

                    if (parts.Length != 2)
                    {
                        await SendMessage(stream, "");
                        continue;
                    }

                    string setNameInput = parts[0];
                    string keyNameInput = parts[1];

                    if (Enum.TryParse(setNameInput, true, out DataSet parsedSet))
                    {
                        if (Enum.TryParse(keyNameInput, true, out DataKey parsedKey))
                        {
                            if (IsValidPair(parsedSet, parsedKey))
                            {
                                int loopCount = (int)parsedKey;

                                for (int i = 0; i < loopCount; i++)
                                {
                                    string currentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                                    await SendMessage(stream, currentTime);
                                    Log("Send : " + currentTime, Color.Black);
                                    await Task.Delay(1000);
                                }
                            }
                            else
                            {
                                await SendMessage(stream, "");
                                Log($"Key '{keyNameInput}' is not valid for {setNameInput}", Color.Black);
                            }
                        }
                        else
                        {
                            await SendMessage(stream, "");
                            Log("Key Not Found", Color.Black);
                        }
                    }
                    else
                    {
                        await SendMessage(stream, "");
                        Log("Set Not Found", Color.Black);
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Error : " + ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// binding the set to there key
        /// </summary>
        private bool IsValidPair(DataSet set, DataKey key)
        {
            return set switch
            {
                DataSet.SetA => key == DataKey.One || key == DataKey.Two,
                DataSet.SetB => key == DataKey.Three || key == DataKey.Four,
                DataSet.SetC => key == DataKey.Five || key == DataKey.Six,
                DataSet.SetD => key == DataKey.Seven || key == DataKey.Eight,
                DataSet.SetE => key == DataKey.Nine || key == DataKey.Ten,
                _ => false
            };
        }

        private async Task SendMessage(NetworkStream stream, string message)
        {
            string encryptedMessage = EncryptionHelper.Encrypt(message);
            byte[] data = Encoding.UTF8.GetBytes(encryptedMessage + "\n");
            await stream.WriteAsync(data, 0, data.Length);
        }

        private void Log(string message, Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateLogBox(message, color)));
            }
            else
            {
                UpdateLogBox(message, color);
            }
        }

        private void UpdateLogBox(string message, Color color)
        {
            txtLogs.SelectionStart = txtLogs.TextLength;
            txtLogs.SelectionLength = 0;
            txtLogs.SelectionColor = color;
            txtLogs.AppendText(message + Environment.NewLine);
            txtLogs.SelectionColor = txtLogs.ForeColor;
            txtLogs.ScrollToCaret();
        }
    }
}
