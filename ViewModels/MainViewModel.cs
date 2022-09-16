using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;

namespace RESTAPI.ViewModels;

public class MainViewModel : ObservableRecipient, INotifyPropertyChanged
{
    public string textBoxURI;
    public string TextBoxURI
    { get => textBoxURI;
        set=> SetProperty(ref textBoxURI, value);
    }
    public string comboBoxAuthType;
    public string ComboBoxAuthType
    {
        get => comboBoxAuthType;
        set => SetProperty(ref comboBoxAuthType, value);
    }
    public string comboBoxTechnique;
    public string ComboBoxTechnique
    {
        get => comboBoxTechnique;
        set => SetProperty(ref comboBoxTechnique, value);
    }
    public string textBoxUsername;
    public string TextBoxUsername
    {
        get => textBoxUsername;
        set => SetProperty(ref textBoxUsername, value);
    }
    public string textBoxPassword;
    public string TextBoxPassword
    {
        get => textBoxPassword;
        set => SetProperty(ref textBoxPassword, value);
    }
    public ICommand ClearCommand
    {
        get; set;
    }
    public ICommand GoCommand
    {
        get; set;
    }
    public ICommand CopyCommand
    {
        get;set;
    }
    public MainViewModel()
    {
        GoCommand = new RelayCommand(OnGoClicked);
        ClearCommand = new RelayCommand(OnClearClicked);
        CopyCommand = new RelayCommand(OnCopyClicked);
    }

    public void OnGoClicked()
    {
        Debug.WriteLine("Go Cllicked");
    
    }
    public void OnClearClicked()
    {
        Debug.WriteLine("Clear Cllicked");
    }
    public void OnCopyClicked()
    {
        Debug.WriteLine("Copy Cllicked");
    }
}
