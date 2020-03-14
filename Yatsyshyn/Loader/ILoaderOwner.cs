using System.ComponentModel;
using System.Windows;

namespace Yatsyshyn.Loader
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}