#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using AppKit;
using Foundation;

using Hydra;
#endregion

namespace Untitled.macOS
{
    class Program : NSApplicationDelegate
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new Program();

			using (var game = new Game1())
			{
				game.Run();
			}

            MemoryCard.current.saveGame(true);
        }

		public override void WillResignActive(NSNotification notification)
		{
            MemoryCard.current.saveGame();
		}
	}
}
