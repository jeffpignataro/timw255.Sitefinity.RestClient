﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.SiteSync;
using Telerik.Sitefinity.SiteSync.Web;
using Telerik.Sitefinity.Web.Services;
using timw255.Sitefinity.RestClient.Model;
using timw255.Sitefinity.RestClient.SitefinityClient.ServiceWrappers;

namespace timw255.Sitefinity.RestClient.ServiceWrappers.SiteSync
{
    public class SiteSyncServiceWrapper : ServiceWrapper
    {
        public SiteSyncServiceWrapper(SitefinityRestClient sf)
        {
            this.ServiceUrl = "Sitefinity/Services/SiteSync/SiteSyncService.svc/";
            this.SF = sf;
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/CalculateDependentItems/")]
        public IDictionary<string, IDictionary<Guid, IEnumerable<Guid>>> CalculateDependentItems(SyncSettings settings)
        {
            var request = new RestRequest(this.ServiceUrl + "/CalculateDependentItems/", Method.POST);

            request.AddParameter("application/json", SerializeObject(settings), ParameterType.RequestBody);

            return ExecuteRequestFor<IDictionary<string, IDictionary<Guid, IEnumerable<Guid>>>>(request);
        }

        //[WebGet(UriTemplate = "/ConfirmConnection/")]
        public bool ConfirmConnection()
        {
            var request = new RestRequest(this.ServiceUrl + "/ConfirmConnection/", Method.GET);

            return ExecuteRequestFor<bool>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/ForceStopSync/")]
        public void ForceStopSync(Guid syncTaskId)
        {
            var request = new RestRequest(this.ServiceUrl + "/ForceStopSync/", Method.POST);

            request.AddParameter("application/json", SerializeObject(syncTaskId), ParameterType.RequestBody);

            ExecuteRequest(request);
        }

        //[WebGet(UriTemplate = "/GenerateSiteSyncLogEntries/")]
        public void GenerateSiteSyncLogEntries()
        {
            var request = new RestRequest(this.ServiceUrl + "/GenerateSiteSyncLogEntries/", Method.GET);

            ExecuteRequest(request);
        }

        //[WebInvoke(Method = "GET", UriTemplate = "/GetCurrentSyncState/?syncTaskId={syncTaskId}")]
        public double GetCurrentSyncState(Guid syncTaskId)
        {
            var request = new RestRequest(this.ServiceUrl + "/GetCurrentSyncState/?syncTaskId={syncTaskId}", Method.GET);

            request.AddUrlSegment("syncTaskId", syncTaskId.ToString());

            return ExecuteRequestFor<double>(request);
        }

        //[WebGet(UriTemplate = "/GetInfo/")]
        public TargetServerInfo GetInfo()
        {
            var request = new RestRequest(this.ServiceUrl + "/GetInfo/", Method.GET);

            return ExecuteRequestFor<TargetServerInfo>(request);
        }

        //[WebGet(UriTemplate = "/LastSyncSummary/?serverId={serverId}")]
        public SyncSummary GetLastSyncSummary(Guid serverId)
        {
            var request = new RestRequest(this.ServiceUrl + "/LastSyncSummary/?serverId={serverId}", Method.GET);

            request.AddUrlSegment("serverId", serverId.ToString());

            return ExecuteRequestFor<SyncSummary>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/GetPendingItems/?typeName={typeName}&server={server}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}")]
        public CollectionContext<SiteSyncLogEntryViewModel> GetPendingItems(string typeName, string server, string sortExpression, int skip, int take, string filter, string taxFilter)
        {
            var request = new RestRequest(this.ServiceUrl + "/GetPendingItems/?typeName={typeName}&server={server}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", Method.POST);

            request.AddUrlSegment("typeName", typeName);
            request.AddUrlSegment("server", server);
            request.AddUrlSegment("sortExpression", sortExpression);
            request.AddUrlSegment("skip", skip.ToString());
            request.AddUrlSegment("take", take.ToString());
            request.AddUrlSegment("filter", filter);

            request.AddParameter("application/json", SerializeObject(taxFilter), ParameterType.RequestBody);

            return ExecuteRequestFor<CollectionContext<SiteSyncLogEntryViewModel>>(request);
        }

        //[WebGet(UriTemplate = "/GetPendingItemsCount/?typeName={typeName}&server={server}&filter={filter}")]
        public int GetPendingItemsCount(string typeName, string server, string filter)
        {
            var request = new RestRequest(this.ServiceUrl + "/GetPendingItemsCount/?typeName={typeName}&server={server}&filter={filter}", Method.GET);

            request.AddUrlSegment("typeName", typeName);
            request.AddUrlSegment("server", server);
            request.AddUrlSegment("filter", filter);

            return ExecuteRequestFor<int>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/GetPendingItemsIds/?typeName={typeName}&server={server}")]
        public IEnumerable<Guid> GetPendingItemsIds(string typeName, string server, string taxFilter)
        {
            var request = new RestRequest(this.ServiceUrl + "/GetPendingItemsIds/?typeName={typeName}&server={server}", Method.POST);

            request.AddUrlSegment("typeName", typeName);
            request.AddUrlSegment("server", server);

            request.AddParameter("application/json", SerializeObject(taxFilter), ParameterType.RequestBody);

            return ExecuteRequestFor<IEnumerable<Guid>>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/SyncItemErrorDetails/?server={server}&type={type}&getErrors={getErrors}")]
        public IEnumerable<string> GetSyncItemErrorDetails(string server, string type, bool getErrors)
        {
            var request = new RestRequest(this.ServiceUrl + "/SyncItemErrorDetails/?server={server}&type={type}&getErrors={getErrors}", Method.POST);

            request.AddUrlSegment("server", server);
            request.AddUrlSegment("type", type);
            request.AddUrlSegment("getErrors", getErrors.ToString());

            return ExecuteRequestFor<IEnumerable<string>>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/SyncTypeDetails/")]
        public IEnumerable<SummaryItemTypeDetails> GetSyncTypeDetails(string server)
        {
            var request = new RestRequest(this.ServiceUrl + "/SyncTypeDetails/", Method.POST);

            request.AddParameter("application/json", SerializeObject(server), ParameterType.RequestBody);

            return ExecuteRequestFor<IEnumerable<SummaryItemTypeDetails>>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/MigrateProviders/")]
        public SiteSyncMigrationMappings MigrateProviders(ProviderMigrationRequest providersReq)
        {
            var request = new RestRequest(this.ServiceUrl + "/MigrateProviders/", Method.POST);

            request.AddParameter("application/json", SerializeObject(providersReq), ParameterType.RequestBody);

            return ExecuteRequestFor<SiteSyncMigrationMappings>(request);
        }

        //[WebGet(UriTemplate = "/RequestTargetInfo/?serverId={serverId}")]
        public TargetServerInfo RequestTargetInfo(Guid serverId)
        {
            var request = new RestRequest(this.ServiceUrl + "/RequestTargetInfo/?serverId={serverId}", Method.GET);

            request.AddUrlSegment("serverId", serverId.ToString());

            return ExecuteRequestFor<TargetServerInfo>(request);
        }

        //[WebGet(UriTemplate = "/RequestTargetSites/?url={url}&userName={userName}&password={password}&provider={provider}")]
        public TargetServerInfo RequestTargetSites(string url, string userName, string password, string provider)
        {
            var request = new RestRequest(this.ServiceUrl + "/RequestTargetSites/?url={url}&userName={userName}&password={password}&provider={provider}", Method.GET);

            request.AddUrlSegment("url", url);
            request.AddUrlSegment("userName", userName);
            request.AddUrlSegment("password", password);
            request.AddUrlSegment("provider", provider);

            return ExecuteRequestFor<TargetServerInfo>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/RequestValidation/")]
        public string RequestValidation(SyncSettings settings)
        {
            var request = new RestRequest(this.ServiceUrl + "/RequestValidation/", Method.POST);

            request.AddParameter("application/json", SerializeObject(settings), ParameterType.RequestBody);

            return ExecuteRequestFor<string>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/Schedule/")]
        public void Schedule(SyncSettings settings)
        {
            var request = new RestRequest(this.ServiceUrl + "/Schedule/", Method.POST);

            request.AddParameter("application/json", SerializeObject(settings), ParameterType.RequestBody);

            ExecuteRequest(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/StartSync/")]
        public void StartSync(SyncSettings settings)
        {
            var request = new RestRequest(this.ServiceUrl + "/StartSync/", Method.POST);

            request.AddParameter("application/json", SerializeObject(settings), ParameterType.RequestBody);

            ExecuteRequest(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/StopSync/")]
        public void StopSync(Guid syncTaskId)
        {
            var request = new RestRequest(this.ServiceUrl + "/StopSync/", Method.POST);

            request.AddParameter("application/json", SerializeObject(syncTaskId.ToString()), ParameterType.RequestBody);

            ExecuteRequest(request);
        }

        //[WebGet(UriTemplate = "/TestConnection/?serverId={serverId}")]
        public string TestConnection(Guid serverId)
        {
            var request = new RestRequest(this.ServiceUrl + "/TestConnection/?serverId={serverId}", Method.GET);

            request.AddUrlSegment("serverId", serverId.ToString());

            return ExecuteRequestFor<string>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/Validate/")]
        public List<string> Validate(SiteSyncValidationRequest validationRequest)
        {
            var request = new RestRequest(this.ServiceUrl + "/Validate/", Method.POST);

            request.AddParameter("application/json", SerializeObject(validationRequest), ParameterType.RequestBody);

            return ExecuteRequestFor<List<string>>(request);
        }
    }
}
