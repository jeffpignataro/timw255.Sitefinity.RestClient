﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Services.Common;
using Telerik.Sitefinity.Web.Model;
using timw255.Sitefinity.RestClient.SitefinityClient.ServiceWrappers;

namespace timw255.Sitefinity.RestClient.ServiceWrappers.Common
{
    public class QueryBuilderServiceWrapper : ServiceWrapper
    {
        public QueryBuilderServiceWrapper(SitefinityRestClient sf)
        {
            this.ServiceUrl = "Sitefinity/Services/Common/QueryBuilderService.svc/";
            this.SF = sf;
        }

        //[WebInvoke(Method = "PUT", UriTemplate = "/{queryId}/?provider={providerName}")]
        public void CreateOrUpdateQuery(QueryData query, Guid queryId, string providerName)
        {
            var request = new RestRequest(this.ServiceUrl + "/{queryId}/?provider={providerName}", Method.PUT);

            request.AddUrlSegment("queryId", queryId.ToString());
            request.AddUrlSegment("providerName", providerName);

            request.AddParameter("application/json", SerializeObject(query), ParameterType.RequestBody);

            ExecuteRequest(request);
        }

        //[WebInvoke(Method = "GET", UriTemplate = "/?sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}&provider={providerName}")]
        public QueryCollectionContext GetQueries(string sortExpression, int skip, int take, string filter, string providerName)
        {
            var request = new RestRequest(this.ServiceUrl + "/?sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}&provider={providerName}", Method.GET);

            request.AddUrlSegment("sortExpression", sortExpression);
            request.AddUrlSegment("skip", skip.ToString());
            request.AddUrlSegment("take", take.ToString());
            request.AddUrlSegment("filter", filter);
            request.AddUrlSegment("providerName", providerName);

            return ExecuteRequestFor<QueryCollectionContext>(request);
        }

        //[WebInvoke(Method = "GET", UriTemplate = "/{id}/?provider={providerName}")]
        public QueryData GetQuery(Guid id, string providerName)
        {
            var request = new RestRequest(this.ServiceUrl + "/{id}/?provider={providerName}", Method.GET);

            request.AddUrlSegment("id", id.ToString());
            request.AddUrlSegment("providerName", providerName);

            return ExecuteRequestFor<QueryData>(request);
        }

        //[WebInvoke(Method = "PUT", UriTemplate = "", RequestFormat = WebMessageFormat.Json)]
        public string GetQueryExpression(QueryData query)
        {
            var request = new RestRequest(this.ServiceUrl + "", Method.PUT);

            request.AddParameter("application/json", SerializeObject(query), ParameterType.RequestBody);

            return ExecuteRequestFor<string>(request);
        }
    }
}
