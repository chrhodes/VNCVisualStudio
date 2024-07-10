using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;

using $xxxAPPLICATIONxxx$.Core;
using $xxxAPPLICATIONxxx$.Core.Events;
using $xxxAPPLICATIONxxx$.Core.Events$xxxNAMESPACExxx$;
using $xxxAPPLICATIONxxx$.Domain;
using $xxxAPPLICATIONxxx$.Domain$xxxNAMESPACExxx$;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Services;
using VNC.HttpHelper;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxTYPExxx$MainViewModel : HTTPExchangeBase, I$xxxTYPExxx$MainViewModel
    {

        #region Constructors, Initialization, and Load

        public $xxxTYPExxx$MainViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            EventAggregator.GetEvent<Get$xxxTYPExxx$sEvent>().Subscribe(Get$xxxTYPExxx$s);

            this.Results.PropertyChanged += PublishSelectionChanged;
            
            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        public RESTResult<$xxxTYPExxx$> Results { get; set; } = new RESTResult<$xxxTYPExxx$>();

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods

        private async void Get$xxxTYPExxx$s(Get$xxxTYPExxx$sEventArgs args)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Helpers.InitializeHttpClient(args.Organization, client);

                    // TODO(crhodes)
                    // Update Uri  Use args for parameters.
                    var requestUri = $"{args.Organization.Uri}/_apis/"
                        + $"<UPDATE URI>"
                        + "?api-version=6.1-preview.1";

                    RequestResponseInfo exchange = InitializeExchange(client, requestUri);

                    using (HttpResponseMessage response = await client.GetAsync(requestUri))
                    {
                        RecordExchangeResponse(response, exchange);

                        response.EnsureSuccessStatusCode();

                        string outJson = await response.Content.ReadAsStringAsync();

                        JObject o = JObject.Parse(outJson);

                        $xxxTYPExxx$sRoot resultRoot = JsonConvert.DeserializeObject<$xxxTYPExxx$sRoot>(outJson);

                        Results.ResultItems = new ObservableCollection<$xxxTYPExxx$>(resultRoot.value);

                        IEnumerable<string> continuationHeaders = default;

                        bool hasContinuationToken = response.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);

                        Results.Count = Results.ResultItems.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                ExceptionDialogService.DisplayExceptionDialog(DialogService, ex);
            }

            EventAggregator.GetEvent<HttpExchangeEvent>().Publish(RequestResponseExchange);
        }

        private void PublishSelectionChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_CATEGORY);

            EventAggregator.GetEvent<Selected$xxxTYPExxx$ChangedEvent>().Publish(Results.SelectedItem);

            Log.EVENT("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        #endregion

    }
}
