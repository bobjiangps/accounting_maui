namespace accounting;

public partial class MainPage : ContentPage
{
    string _fileName = Path.Combine(System.Environment.CurrentDirectory, "notes.txt");

    public MainPage()
	{
		InitializeComponent();

        if (File.Exists(_fileName))
        {
            editor.Text = File.ReadAllText(_fileName);
        }
        else
        {
            editor.Text = "Enter your note; no file in:" + _fileName;
        }
        systemHint.Text += DeviceInfo.Platform.ToString();
        MyStackLayout.Margin =
            DeviceInfo.Platform == DevicePlatform.iOS
                ? new Thickness(30, 60, 30, 30) // Shift down by 60 points on iOS only
                : new Thickness(30); // Set the default margin to be 30 points
    }

	private void SaveClicked(object sender, EventArgs e)
	{
		editor.Text = "Save click";
	}

    private void DeleteClicked(object sender, EventArgs e)
    {
		editor.Text = "Delete click";

    }
}


