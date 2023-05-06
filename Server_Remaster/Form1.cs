using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Timers;
namespace Server_Remaster
{
    public partial class Form1 : Form
    {
        //Variable For Game
        public bool[,] Map;
        Dictionary<string, ClientState> Players;
        int Round = 1;
        public System.Timers.Timer timer;
        public int count_for_client_openenUI;
        //

        //Variable For Connection
        TcpListener tcpListener;
        int Client_ID = 1;
        //
        public Form1()
        {
            InitializeComponent();
            //Initial Connection Variable
            tbx_IP.Text = GetLocalIpAddress();
            tbx_PORT.Text = "10000";
            tcpListener = new TcpListener(IPAddress.Parse(tbx_IP.Text), int.Parse(tbx_PORT.Text));
            //

            //Initial Game Variable
            Players = new Dictionary<string, ClientState>();
            Map = new bool[6, 6];
            timer = new System.Timers.Timer(30000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Gameloop);
            count_for_client_openenUI = 0;
            Map_Reset();

        }
        #region Connection
        public string GetLocalIpAddress()
        {
            string ipAddress = string.Empty;
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return "127.0.0.1";
        }
        public void Start_Listening()
        {
            tcpListener.Start();
            ADD_TO_LOG("Waiting For Connections");
            Thread connectionThread = new Thread(AcceptConnections);
            ADD_TO_LOG("Server is listening at " + tbx_IP.Text + ":" + tbx_PORT.Text);
            connectionThread.IsBackground = true;
            connectionThread.Start();
        }
        public void AcceptConnections()
        {
            TcpClient new_client;
            while (true)
            {
                new_client = tcpListener.AcceptTcpClient();
                try
                {
                    if (new_client.Connected)
                    {
                        Players.Add(Client_ID.ToString(), new ClientState(Client_ID.ToString(), new_client));
                        SentToSingleClient(Client_ID, "ID"+Client_ID.ToString());
                        ADD_TO_LOG("Client " + Client_ID.ToString() + " :" + new_client.Client.RemoteEndPoint + " is joined");
                        Client_ID++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SentToAllClient(string Mesaage)
        {
            byte[] data = Encoding.UTF8.GetBytes(Mesaage);
            foreach (var kvp in Players)
            {
                string Client_ID = kvp.Key;
                TcpClient client_socket = Players[Client_ID].tcpClient;
                NetworkStream networkStream = client_socket.GetStream();
                try
                {
                    if (networkStream.CanWrite)
                    {
                        networkStream.Write(data, 0, data.Length);
                        ADD_TO_LOG("Message '" + Mesaage + "' is sent to Client " + Client_ID);
                    }
                    else
                        ADD_TO_LOG("Fail to sent to Client " + Client_ID);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public void SentToSingleClient(int Client_ID, string Mesaage)
        {
            byte[] data = Encoding.UTF8.GetBytes(Mesaage);
            TcpClient client_socket = Players[Client_ID.ToString()].tcpClient;
            NetworkStream networkStream = client_socket.GetStream();
            try
            {
                if (networkStream.CanWrite)
                {
                    networkStream.Write(data, 0, data.Length);
                    ADD_TO_LOG("Message '" + Mesaage + "' is sent to Client " + Client_ID);
                }
                else
                    ADD_TO_LOG("Fail to sent to Client " + Client_ID);
            }
            catch (IOException ex)
            {
                ADD_TO_LOG(ex.Message);
            }
        }
        #endregion
        #region Map
        public void Map_Reset()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                    Map[i, j] = false;
            }
        }
        public void Set_Bomb(int x, int y)
        {
            Map[x, y] = true;
        }

        #endregion
        #region GameControl
        void GameStart()
        {
            for (int i = 1; i <= Players.Count; i++)
                Players[i.ToString()].Start_Position_Set();
            for(int i = 1; i <= Players.Count; i++)
            {
                for(int j = 1; j <= Players.Count; j++)
                {
                    if (j != i)
                        SentToSingleClient(i, "NP" + j.ToString() + Players[j.ToString()].x.ToString() + Players[j.ToString()].y.ToString());
                }
            }
            SentToAllClient("GS" + Round.ToString());
        }
        void EndRound()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if (Map[i, j])
                    {
                        SentToAllClient("BS" + i.ToString() + j.ToString()); //BSxy ex.A bomb is located at (3,2) => BS32
                    }
                }
            }
            for(int i = 1; i <= Players.Count; i++)
            {
                int Player_X = Players[i.ToString()].x;
                int Player_Y = Players[i.ToString()].y;
                if (Map[Player_X, Player_Y])
                {
                    Players[i.ToString()].Out = true;
                    SentToAllClient("PLD" + i.ToString() + Player_X.ToString() + Player_Y.ToString()); //PLDixy ex.if player 1 is dead at (1,1) => PLN11
                }
                else
                    SentToAllClient("PLA" + i.ToString() + Player_X.ToString() + Player_Y.ToString());//PLAixy ex.if player 1 is alive at (1,2) => PLY11
            }
            SentToAllClient("ER");
            Map_Reset();
        }
        void CheckForNewRound()
        {
            int counter = 0;
            for(int i = 1; i <= Players.Count; i++)
            {
                if (Players[i.ToString()].Out)
                    counter++;
            }
            if (counter == Players.Count - 1)
            {
                timer.Stop();
                for (int i = 1; i <= Players.Count; i++)
                {
                    if (!Players[i.ToString()].Out)
                        SentToAllClient("GE" + i.ToString());
                }
            }
            else if (counter == Players.Count)
            {
                timer.Stop();
                SentToAllClient("GEN");
            }
            else
                ;

        }
        void NewRound()
        {
            SentToAllClient("NR" + (++Round).ToString());
        }
        void Gameloop(object obj,ElapsedEventArgs args)
        {
            EndRound();
            Thread.Sleep(5000);
            CheckForNewRound();
            NewRound();
        }
        #endregion
        #region Button

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ServerStart_Click(object sender, EventArgs e)
        {
            Start_Listening();
            btn_ServerStart.Enabled = false;
        }

        private void btn_GameStart_Click(object sender, EventArgs e)
        {
            if (count_for_client_openenUI != Players.Count)
                MessageBox.Show("There's player who doesn't enter the game");
            GameStart();
            timer.Start();
        }
        #endregion
        #region LOG
        void ADD_TO_LOG(string message)
        {
            if (list_LOG.InvokeRequired)
            {
                list_LOG.Invoke((MethodInvoker)(() => list_LOG.Items.Add(message)));
            }
            else
            {
                list_LOG.Items.Add(message);
            }
        }
        void ADD_TO_Recv(string message)
        {
            if (Recv.InvokeRequired)
            {
                list_Recv.Invoke((MethodInvoker)(() => list_Recv.Items.Add(message)));
            }
            else
            {
                list_Recv.Items.Add(message);
            }
        }
        #endregion
        
    }
}
