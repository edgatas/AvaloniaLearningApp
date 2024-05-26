using Avalonia.Media;
using Avalonia.Threading;
using LearningApp.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Task.Run(ChangeListBoxTextBackground);

        _listBoxText = new ObservableCollection<string>
        {
            "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1",
            "Test1"
        };
        _listBoxBackgroundColor = new SolidColorBrush(Colors.Black);
        _simpleModelList = CreateSimpleModelListData();

        ResetListButtonCommand = ReactiveCommand.Create(ResetListBoxText);
    }


    public string Greeting => "Welcome to Avalonia! And Not Live";


    public ICommand ResetListButtonCommand { get; set; }

    public void ResetListBoxText()
    {
        ListBoxText =
        [
            "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1", "Test1",
            "Test1"
        ];
    }

    private void ChangeListBoxTextBackground()
    {
        while (true)
        {
            Thread.Sleep(100);
            Random random = new Random();
            int itemPosition = random.Next(_listBoxText.Count);
            _listBoxText[itemPosition] =
                _listBoxText[itemPosition].Substring(0, 4) + " " + random.Next(1000).ToString("000");

            ListBoxText = new ObservableCollection<string>(_listBoxText.Order().ToList());

            List<string> sortedList = _listBoxText.Order().ToList();

            bool match = true;
            for (int i = 0; i < sortedList.Count; i++)
            {
                match = sortedList[i] == _listBoxText[i];
                if (!match)
                {
                    break;
                }
            }

            Dispatcher.UIThread.Invoke(() =>
            {
                ListBoxBackgroundColor =
                    match
                        ? new SolidColorBrush(Color.FromRgb(0, 255, 0), 0.2)
                        : new SolidColorBrush(Color.FromRgb(255, 0, 0), 0.2);
            });
        }
    }

    #region Properties

    private ObservableCollection<string> _listBoxText;

    public ObservableCollection<string> ListBoxText
    {
        get => _listBoxText;
        set => this.RaiseAndSetIfChanged(ref _listBoxText, value);
    }

    private Brush _listBoxBackgroundColor;

    public Brush ListBoxBackgroundColor
    {
        get => _listBoxBackgroundColor;
        set => this.RaiseAndSetIfChanged(ref this._listBoxBackgroundColor, value);
    }


    private ObservableCollection<SimpleModel> _simpleModelList;

    public ObservableCollection<SimpleModel> SimpleModelList
    {
        get => _simpleModelList;
        set => this.RaiseAndSetIfChanged(ref _simpleModelList, value);
    }

    private SimpleModel _selectedSimpleModel;

    public SimpleModel SelectedSimpleMode
    {
        get => _selectedSimpleModel;
        set
        {
            PopulateSimpleModelProperties(value);
            this.RaiseAndSetIfChanged(ref _selectedSimpleModel, value);
        }
    }

    private int _simpleModelId;

    public int SimpleModelId
    {
        get => _simpleModelId;
        set => this.RaiseAndSetIfChanged(ref _simpleModelId, value);
    }

    private string _caption = string.Empty;

    public string Caption
    {
        get => _caption;
        set => this.RaiseAndSetIfChanged(ref _caption, value);
    }

    private decimal _cost;

    public decimal Cost
    {
        get => _cost;
        set => this.RaiseAndSetIfChanged(ref _cost, value);
    }

    #endregion

    private void PopulateSimpleModelProperties(SimpleModel value)
    {
        SimpleModelId = value.SimpleModelId;
        Caption = value.Caption;
        Cost = value.Cost;
    }

    #region Testing Populators

    private ObservableCollection<SimpleModel> CreateSimpleModelListData()
    {
        ObservableCollection<SimpleModel> simpleModels =
        [
            new SimpleModel()
            {
                SimpleModelId = 1,
                Caption = "Model 1",
                Cost = 50.53M
            },

            new SimpleModel()
            {
                SimpleModelId = 2,
                Caption = "This is a bit longer caption",
                Cost = 5000.35M
            },

            new SimpleModel()
            {
                SimpleModelId = 3,
                Caption = "This is the caption",
                Cost = 1.99M
            }
        ];
        return simpleModels;
    }

    #endregion
}