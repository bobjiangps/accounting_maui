﻿namespace accounting;

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


