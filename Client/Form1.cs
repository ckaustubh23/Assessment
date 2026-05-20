using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnConnect.Focus();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text;
                int port = Convert.ToInt32(txtPort.Text);

                client = new TcpClient();

                await client.ConnectAsync(ip, port);

                stream = client.GetStream();

                Log("Connected to server at Port 5000", Color.Green);
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                Log("Error : " + ex.Message, Color.Red);
            }
        }



        private void Log(string message, Color? color)
        {
            txtLogs.SelectionStart = txtLogs.TextLength;
            txtLogs.SelectionLength = 0;

            txtLogs.SelectionColor = color ?? Color.Black;

            txtLogs.AppendText(message + Environment.NewLine);

            txtLogs.SelectionColor = txtLogs.ForeColor;

            txtLogs.ScrollToCaret();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    Log("Failed to connect", Color.Red);
                    return;
                }

                string message = txtMessage.Text;

                //byte[] data = Encoding.UTF8.GetBytes(message);
                string encryptedMessage = EncryptionHelper.Encrypt(message);
                byte[] data = Encoding.UTF8.GetBytes(encryptedMessage);

                await stream.WriteAsync(data, 0, data.Length);

                Log("Send : " + message, Color.Blue);

                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead =
                        await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                        break;

                    string encryptedResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    string response = EncryptionHelper.Decrypt(encryptedResponse);

                    Log("Received : " + response.Trim(), Color.Black);
                }
            }
            catch (Exception ex)
            {
                Log("Error : " + ex.Message, Color.Red);
            }
        }
    }
}
