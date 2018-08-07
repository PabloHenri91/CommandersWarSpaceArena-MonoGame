using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Hydra
{
    [Activity(Label = "@string/ApplicationName"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }

        protected override void OnPause()
        {
            base.OnPause();
            MemoryCard.current.saveGame();
        }
    }
}

