namespace RPS_Server.Signal
{
	public class Signal_Server		//signals sent from and to server
	{
		public static const byte SERVER_ACK = 1;		//server acknowledge signals from client

		public static const byte SERVER_ROCK = 255;		//server using rock
		public static const byte SERVER_PAPER = 254;	//server using paper
		public static const byte SERVER_SCISSOR = 253;	//server using scissor

		public static const byte SERVER_NEUTRAL = 252;	//server has not sent rock or paper or scissor
	}

	public class Signal_Client {		//signals sent from and to client
		public static const byte CLIENT_ACK = 1;		//client acknowledge signals from server

		public static const byte CLIENT_ROCK = 255;		//client using rock
		public static const byte CLIENT_PAPER = 254;	//client using paper
		public static const byte CLIENT_SCISSOR = 253;	//client using scissor

		public static const byte CLIENT_NEUTRAL = 252;	//client has not sent rock or paper or scissor
	}

	public class Signal_Game
	{
		public static const byte FINISH = 98;
		public static const byte START = 99;
		public static const byte LOSE = 100;
		public static const byte DRAW = 101;
		public static const byte WIN = 102;
	}
}
