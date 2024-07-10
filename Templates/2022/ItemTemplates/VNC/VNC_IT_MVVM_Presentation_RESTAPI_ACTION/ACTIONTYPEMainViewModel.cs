using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;

using $xxxAPPLICATIONxxx$.Core;
using $xxxAPPLICATIONxxx$.Core.Events;
using $xxxAPPLICATIONxxx$.Core.Events.$xxxNAMESPACExxx$;
using $xxxAPPLICATIONxxx$.Domain;
using $xxxAPPLICATIONxxx$.Domain.$xxxNAMESPACExxx$;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Prism.Events;

using VNC;
using VNC.Core.Services;
using VNC.HttpHelper;

namespace $xxxAPPLICATIONxxx$.$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxACTIONxxx$$xxxTYPExxx$MainViewModel : HTTPExchangeBase, I$xxxACTIONxxx$$xxxTYPExxx$MainViewModel
    {

        #region Constructors, Initialization, and Load

        public $xxxACTIONxxx$$xxxTYPExxx$MainViewModel(
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService) : base(eventAggregator, messageDialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_APPNAME);

            EventAggregator.GetEvent<$xxxACTIONxxx$$xxxTYPExxx$Event>().Subscribe($xxxACTIONxxx$$xxxTYPExxx$);

            // this.$xxxTYPExxx$s.PropertyChanged += Publish$xxxACTIONxxx$$xxxTYPExxx$Performed;
            
            Log.VIEWMODEL("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        // public RESTResult<$xxxTYPExxx$> $xxxTYPExxx$s { get; set; } = new RESTResult<$xxxTYPExxx$>();

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods


        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods

        private async void $xxxACTIONxxx$$xxxTYPExxx$($xxxACTIONxxx$$xxxTYPExxx$EventArgs args)
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

                        // $xxxTYPExxx$sRoot resultRoot = JsonConvert.DeserializeObject<$xxxTYPExxx$sRoot>(outJson);

                        // $xxxTYPExxx$s.ResultItems = new ObservableCollection<$xxxTYPExxx$>(resultRoot.value);

                        // IEnumerable<string> continuationHeaders = default;

                        // bool hasContinuationToken = response.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);

                        // $xxxTYPExxx$s.Count = $xxxTYPExxx$s.ResultItems.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_APPNAME);
                MessageDialogService.ShowInfoDialog($"Error ({ex})");
            }

            EventAggregator.GetEvent<HttpExchangeEvent>().Publish(RequestResponseExchange);
            
            EventAggregator.GetEvent<$xxxACTIONxxx$$xxxTYPExxx$Event>().Publish(new $xxxACTIONxxx$$xxxTYPExxx$EventArgs());
        }

        private void Publish$xxxACTIONxxx$Performed(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = Log.EVENT("Enter", Common.LOG_APPNAME);

            EventAggregator.GetEvent<$xxxACTIONxxx$$xxxTYPExxx$Event>().Publish(new $xxxACTIONxxx$$xxxTYPExxx$EventArgs());

            Log.EVENT("Exit", Common.LOG_APPNAME, startTicks);
        }
        
        #endregion

    }
}
