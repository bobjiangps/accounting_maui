using System.Net.Http.Json;


namespace accounting;

public class Blog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
}

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

    async void APIClicked(object sender, EventArgs e)
    {
        httpMsg.Text = "Message by getting rest api: ";
        CallAPIBtn.Text = "API Called..Wait..";
        try
        {
            HttpClient client = new HttpClient();
            Blog text_api_get = await client.GetFromJsonAsync<Blog>("http://jsonplaceholder.typicode.com/posts/1");
            httpMsg.Text += $"{text_api_get.Id} - {text_api_get.UserId} - {text_api_get.Body} - {text_api_get.Title}";
            //String text_api_get = await client.GetStringAsync("http://120.78.133.207:8090/tool/share");
            //httpMsg.Text += text_api_get;
            CallAPIBtn.Text = "API Called and Completed";
        }
        catch (Exception ee)
        {
            httpMsg.Text = ee.Message;
            CallAPIBtn.Text = "API Called and Failed";
        }
    }
}


