using Microsoft.UI.Xaml.Controls;

using RESTAPI.ViewModels;

namespace RESTAPI.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();


    }

    private void buttonClear_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }

    private void buttonGo_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        RestClient rClient = new RestClient();
        rClient.endPoint = textBoxURI.Text;
        switch (comboBoxVerb.SelectedItem)
        {
            case "POST":
                rClient.httpMethod = httpVerb.POST;
                rClient.postJSON = textBoxJSON.Text;
                break;
            default:
                rClient.httpMethod = httpVerb.GET;
                break;
        }
        rClient.userName = textBoxUsername.Text;
        rClient.userPassword = textBoxPassword.Text;
        string strResponse = string.Empty;
        strResponse = rClient.makeRequest();
        textBlockReposse.Text =strResponse;
    }

    private void buttonCopy_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }
}
