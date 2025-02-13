
#if ANDROID
using Android.Content; // For launching intents
using Android.Bluetooth;
using Android;
#endif

namespace Quapper
{

    public partial class MainPage : ContentPage
    {
#if ANDROID
        BluetoothAdapter DeviceBridge = BluetoothAdapter.DefaultAdapter;
#endif
        public MainPage()
        {
#if ANDROID
            InitializeComponent();

            if (DeviceBridge == null) { CounterBtn.Text = "No Bluetooth adapter found on device"; }
            else if (!DeviceBridge.IsEnabled) { CounterBtn.Text = "Bluetooth device is disabled"; }
            else { CounterBtn.Text = "Everythin fine"; }


#endif
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
#if ANDROID
            try
            {
                var intent = new Intent(Intent.ActionView);
                intent.SetAction(Intent.ActionMain);
                intent.SetPackage("com.kitus.quack");
                Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.StartActivity(intent);
            }
            catch
            {
                CounterBtn.Text = "Sad, no Quack App :,(";
                SemanticScreenReader.Announce(CounterBtn.Text);
            }
#endif

        }
    }

}
