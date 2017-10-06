using System;
using Impression;

namespace Example02Texture2D
{
    class Program
    {
        static void Main(string[] args)
		{
			using(var game = new Example02Texture2DGame())
            {
                game.Run();
            }
		}
    }
}