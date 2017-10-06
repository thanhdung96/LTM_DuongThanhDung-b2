using System;
using System.Text;
using RPS_Server.Signal;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace RPS_Server.GUI
{
	public partial class RPS_ServerForm : Form
	{
		private TcpListener server;
		private TcpClient client;

		private NetworkStream dataStream;

		private byte[] sendBuffer, receiveBuffer;
		private byte signalSend, signalReceive;

		private byte mySelection, opponentSelection, myResult;

		public RPS_ServerForm()
		{
			Console.WriteLine("Server initialising GUI components");
			InitializeComponent();

			setInit();
			startListening();
		}

		private void setInit()
		{
			Console.WriteLine("Server initialising network components");
			//init server
			server = new TcpListener(IPAddress.Any, 1724);		//server will receive any connection to any interface, port 1724
			sendBuffer = new byte[1024];		//init buffer send to client, 1Kb
			receiveBuffer = new byte[1024];		//init buffer receive from client, 1Kb
			//init game
			Console.WriteLine("Server initialising game");
			mySelection = Signal_Server.SERVER_NEUTRAL;
			myResult = Signal_Game.DRAW;
			opponentSelection = Signal_Client.CLIENT_NEUTRAL;
		}

		private void startListening()
		{
			Console.WriteLine("Server start listening");
			server.Start();		//server start listening
			client = server.AcceptTcpClient();
			Console.WriteLine("Server accepted a client");

		}

		private void btnScissor_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Server.SERVER_SCISSOR;
		}

		private void btnPaper_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Server.SERVER_PAPER;
		}

		private void btnRock_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Server.SERVER_ROCK;
		}
	}
}
