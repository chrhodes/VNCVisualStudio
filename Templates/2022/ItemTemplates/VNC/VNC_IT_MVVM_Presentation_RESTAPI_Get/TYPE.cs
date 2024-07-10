using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using $xxxAPPLICATIONxxx$.Domain$xxxNAMESPACExxx$.Events;

using Newtonsoft.Json;

using Prism.Events;

using VNC;
using VNC.Core.Net;

namespace $xxxAPPLICATIONxxx$.Domain$xxxNAMESPACExxx$
{
    namespace Events
    {
        public class Get$xxxTYPExxx$sEvent : PubSubEvent<Get$xxxTYPExxx$sEventArgs> { }

        public class Get$xxxTYPExxx$sEventArgs
        {
            public Organization Organization;

            // public Domain.Core.Process Process;

            // public Core.Project Project;

            // public Domain.Core.Team Team;

            // public WorkItemType WorkItemType;
        }

        public class Selected$xxxTYPExxx$ChangedEvent : PubSubEvent<$xxxTYPExxx$> { }
    }

    // TODO(crhodes)
    // PasteSpecial from Json result text

    // Nest any additional classes inside class $xxxTYPExxx$

    public class $xxxTYPExxx$sRoot
    {
        public int count { get; set; }
        public $xxxTYPExxx$[] value { get; set; }
    }

    public class $xxxTYPExxx$
    {
        public RESTResult<$xxxTYPExxx$> Results { get; set; } = new RESTResult<$xxxTYPExxx$>();

        public async Task<RESTResult<$xxxTYPExxx$>> GetList(Get$xxxTYPExxx$sEventArgs args)
        {
            Int64 startTicks = Log.DOMAIN("Enter($xxxTYPExxx$)", Common.LOG_CATEGORY);
            
            using (HttpClient client = new HttpClient())
            {
                Results.InitializeHttpClient(client, args.Organization.PAT);

                // TODO(crhodes)
                // Update Uri  Use args for parameters.
                var requestUri = $"{args.Organization.Uri}/_apis/"
                    + $"<UPDATE URI>"
                    + "?api-version=6.1-preview.1";

                var exchange = Results.InitializeExchange(client, requestUri);

                using (HttpResponseMessage response = await client.GetAsync(requestUri))
                {
                    Results.RecordExchangeResponse(response, exchange);

                    response.EnsureSuccessStatusCode();

                    string outJson = await response.Content.ReadAsStringAsync();

                    $xxxTYPExxx$sRoot resultRoot = JsonConvert.DeserializeObject<$xxxTYPExxx$sRoot>(outJson);

                    Results.ResultItems = new ObservableCollection<$xxxTYPExxx$>(resultRoot.value);

                    // TODO(crhodes)
                    // Remove this if not using continuationHeaders
                    
                    #region ContinuationHeaders
                    
                    IEnumerable<string> continuationHeaders = default;

                    bool hasContinuationToken = response.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);
                    
                    while (hasContinuationToken)
                    {
                        string continueToken = continuationHeaders.First();

                        var requestUri2 = $"{args.Organization.Uri}/_apis/"
                            + $"<UPDATE URI>"
                            + $"continuationToken={continueToken}"                            
                            + "?api-version=6.1-preview.1";
                    
                        var exchange2 = Results.ContinueExchange(client, requestUri2);

                        using (HttpResponseMessage response2 = await client.GetAsync(requestUri2))
                        {
                            Results.RecordExchangeResponse(response2, exchange2);

                            response2.EnsureSuccessStatusCode();
                            string outJson2 = await response2.Content.ReadAsStringAsync();

                            BuildsRoot resultRootC = JsonConvert.DeserializeObject<BuildsRoot>(outJson2);

                            Results.ResultItems.AddRange(resultRootC.value);

                            hasContinuationToken = response2.Headers.TryGetValues("x-ms-continuationtoken", out continuationHeaders);
                        }
                    }
                    
                    #endregion

                    Results.Count = Results.ResultItems.Count;
                }

                Log.DOMAIN("Exit($xxxTYPExxx$)", Common.LOG_CATEGORY, startTicks);

                return Results;
            }
        }
    }
}
