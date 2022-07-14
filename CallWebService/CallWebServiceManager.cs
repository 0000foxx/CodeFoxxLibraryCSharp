using Newtonsoft.Json;
using System;

namespace CodeFoxxLibrary.CallWebServiceLibrary
{
    public class CallWebServiceManager
    {

        public string callWebService()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Encoding = System.Text.Encoding.UTF8;

            string queryURL = "http://59.125.146.7:8080/APQPService/openWindow1CustNo";
            string response = client.UploadString(queryURL, generateQueryParameter());
            return response;
        }

        private string generateQueryParameter()
        {
            //以下欄位名稱必須和Web Service上要求的參數名稱相同，否則query會出錯
            //e.g., QueryItem - WWID / userid / page / data
            //e.g., QueryItemData - data.condition
            QueryItem queryItem = new QueryItem();
            queryItem.WWID = "13145774WWGlobal999988owquery999";
            queryItem.userid = "110045";
            queryItem.page = "1";

            QueryItemData data = new QueryItemData();
            data.condition = "";
            queryItem.data = data;

            string queryJson = JsonConvert.SerializeObject(queryItem);
            Console.WriteLine("d1, queryJson = " + queryJson);
            return queryJson;
        }

    }

    class QueryItem
    {
        public string WWID;
        public string userid;
        public string page;
        public QueryItemData data;
    }

    class QueryItemData
    {
        public string condition;
    }
}
