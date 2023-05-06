using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Server_Remaster;
namespace Server_Remaster
{
    internal class ClientState
    {
        public int x;
        public int y;
        string ID;
        public TcpClient tcpClient;
        public bool[,] Bomb_Placed;
        public bool Out = false;
        public bool Open = false;
        public Form1 form1;

        public ClientState(string id , TcpClient input_socket,ref Form1 form)
        {
            ID = id;
            tcpClient = input_socket;
            Thread thread = new Thread(Client_Listening);
            form1 = form;
            thread.IsBackground = true;
            thread.Start();
        }
        private void Client_Listening()
        {
            NetworkStream networkStream = tcpClient.GetStream();

            while (true)
            {
                try
                {
                    if (networkStream.CanRead)
                    {
                        byte[] buffer = new byte[2048];
                        int BytesReaded = networkStream.Read(buffer, 0, buffer.Length);
                        if (BytesReaded <= 0)
                        {
                            //MessageBox.Show("Fail to Read");
                        }
                        else
                        {
                            string Message_From_Client = Encoding.UTF8.GetString(buffer, 0, BytesReaded);
                            string command = Message_From_Client.Substring(0, 2);
                            if (command == "PB")//ex.PB32 => Place Bomb At (3,2)
                            {
                                int x = int.Parse(Message_From_Client.Substring(2, 1));
                                int y = int.Parse(Message_From_Client.Substring(3, 1));
                                form1.Map[x, y] = true;
                            }
                            else if (command == "PL")//ex.PL33 => Player is At (3,3)
                            {
                                int new_X = int.Parse(Message_From_Client.Substring(2, 1));
                                int new_Y = int.Parse(Message_From_Client.Substring(3, 1));
                                x = new_X;
                                y = new_Y;
                            }
                            else if(command == "OP")
                            {
                                Open = true;
                            }
                            else
                                MessageBox.Show(Message_From_Client);
                            //MessageBox.Show("Sucessfully Receive " + Message_From_Client + " Form Client");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }
        public void Start_Position_Set()
        {
            int tmp = int.Parse(ID) - 1;
            if (tmp / 2 == 0) { x = 0; }
            else { x = 5; }
            if (tmp % 2 == 0) { y = 0; }
            else { y = 5; }
        }
    }
}
