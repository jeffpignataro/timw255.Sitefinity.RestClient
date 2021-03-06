﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Ecommerce.Orders.Model;
using Telerik.Sitefinity.Web.Services;
using timw255.Sitefinity.RestClient.SitefinityClient.ServiceWrappers;

namespace timw255.Sitefinity.RestClient.ServiceWrappers.Ecommerce.Order
{
    public class DiscountServiceWrapper : ServiceWrapper
    {
        public DiscountServiceWrapper(SitefinityRestClient sf)
        {
            this.ServiceUrl = "Sitefinity/Services/Ecommerce/Order/Discount.svc/";
            this.SF = sf;
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/batch/?provider={provider}&language={deletedLanguage}")]
        public bool BatchDeleteDiscounts(Guid[] discountIds, string provider, string deletedLanguage)
        {
            var request = new RestRequest(this.ServiceUrl + "/batch/?provider={provider}&language={deletedLanguage}", Method.POST);

            request.AddUrlSegment("provider", provider);
            request.AddUrlSegment("deletedLanguage", deletedLanguage);

            request.AddParameter("application/json", SerializeObject(discountIds), ParameterType.RequestBody);

            return ExecuteRequestFor<bool>(request);
        }

        //[WebInvoke(Method = "DELETE", UriTemplate = "/{discountId}/?provider={provider}&language={deletedLanguage}")]
        public bool DeleteDiscount(Guid discountId, string provider, string deletedLanguage)
        {
            var request = new RestRequest(this.ServiceUrl + "/{discountId}/?provider={provider}&language={deletedLanguage}", Method.DELETE);

            request.AddUrlSegment("discountId", discountId.ToString());
            request.AddUrlSegment("provider", provider);
            request.AddUrlSegment("deletedLanguage", deletedLanguage);

            return ExecuteRequestFor<bool>(request);
        }

        //[WebGet(UriTemplate = "/{discountId}/?provider={provider}")]
        public ItemContext<Discount> GetDiscount(Guid discountId, string provider)
        {
            var request = new RestRequest(this.ServiceUrl + "/{discountId}/?provider={provider}", Method.GET);

            request.AddUrlSegment("discountId", discountId.ToString());
            request.AddUrlSegment("provider", provider);

            return ExecuteRequestFor<ItemContext<Discount>>(request);
        }

        //[WebGet(UriTemplate = "/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}")]
        public CollectionContext<Discount> GetDiscounts(string provider, string sortExpression, int skip, int take, string filter)
        {
            var request = new RestRequest(this.ServiceUrl + "/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", Method.GET);

            request.AddUrlSegment("provider", provider);
            request.AddUrlSegment("sortExpression", sortExpression);
            request.AddUrlSegment("skip", skip.ToString());
            request.AddUrlSegment("take", take.ToString());
            request.AddUrlSegment("filter", filter);

            return ExecuteRequestFor<CollectionContext<Discount>>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/makeactive/?provider={provider}")]
        public bool MakeActive(Guid discountId, string provider)
        {
            var request = new RestRequest(this.ServiceUrl + "/makeactive/?provider={provider}", Method.POST);

            request.AddUrlSegment("provider", provider);

            request.AddParameter("application/json", SerializeObject(discountId), ParameterType.RequestBody);

            return ExecuteRequestFor<bool>(request);
        }

        //[WebInvoke(Method = "POST", UriTemplate = "/makeinactive/?provider={provider}")]
        public bool MakeInActive(Guid discountId, string provider)
        {
            var request = new RestRequest(this.ServiceUrl + "/makeinactive/?provider={provider}", Method.POST);

            request.AddUrlSegment("provider", provider);

            request.AddParameter("application/json", SerializeObject(discountId), ParameterType.RequestBody);

            return ExecuteRequestFor<bool>(request);
        }

        //[WebInvoke(Method = "PUT", UriTemplate = "/{discountId}/?provider={provider}")]
        public ItemContext<Discount> SaveDiscount(Guid discountId, ItemContext<Discount> discount, string provider)
        {
            var request = new RestRequest(this.ServiceUrl + "/{discountId}/?provider={provider}", Method.PUT);

            request.AddUrlSegment("discountId", discountId.ToString());
            request.AddUrlSegment("provider", provider);

            request.AddParameter("application/json", SerializeObject(discount), ParameterType.RequestBody);

            return ExecuteRequestFor<ItemContext<Discount>>(request);
        }
    }
}
