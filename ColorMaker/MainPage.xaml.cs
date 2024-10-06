

using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        private string hexValue;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            setColor(color);
        }

        private void setColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void BtnRandom_OnClicked(object? sender, EventArgs e)
        {
            Random random = new Random();
            Color color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

            setColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
        }

        private async void ImageButton_OnClicked(object? sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short,
                12);
            await toast.Show();
        }
    }

}
