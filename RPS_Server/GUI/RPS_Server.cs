using RPS_Server.Signal;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

/*
 * Client play the game first
 * then the server
 * Communicating using only 1 byte of signal
 */
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
			startGame();
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
			mySelection = Signal_Game.NEUTRAL;
			myResult = Signal_Game.DRAW;
			opponentSelection = Signal_Game.NEUTRAL;
		}

		private void startListening()
		{
			Console.WriteLine("Server start listening");
			server.Start();		//server start listening
			client = server.AcceptTcpClient();
			dataStream = client.GetStream();
			Console.WriteLine("Server accepted a client and ready to communicate");
		}

		private void startGame()
		{
			//throw new NotImplementedException();
			sendSignalToClient(Signal_Game.START);
		}

		private void sendSignalToClient(byte signal)
		{
			dataStream.WriteByte(Signal_Client.CLIENT_SEND_REQ);		//request to send to client
			signalReceive = receiveSignalFromClient();					//receive respond from client after request
			if(signalReceive == Signal_Client.CLIENT_ACK)				//if client acknowledged
			{
				dataStream.WriteByte(signal);
			}
		}

		private byte receiveSignalFromClient()
		{
			return Convert.ToByte(dataStream.ReadByte());		//read 1 byte of signal from client
		}

		private void btnScissor_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Game.SCISSOR;
		}

		private void btnPaper_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Game.PAPER;
		}

		private void btnRock_Click(object sender, EventArgs e)
		{
			mySelection = Signal_Game.ROCK;
		}
	}
}
