using BuggyMaui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MetroLog;

namespace BuggyMaui.ViewModels
{
    [QueryProperty(nameof(Message), nameof(Message))]
    public partial class SuccessViewModel : ObservableObject
    {
        #region Private fields

        IConnectivity connectivity;

        private ILogger _logger = InternalLogger.Current;

        private string message;

        #endregion

        #region Public properties

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        #endregion

        #region Constructor

        public SuccessViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;
            _logger.Info("[SuccessViewModel]: constructor initialized");
        }

        #endregion
    }
}
