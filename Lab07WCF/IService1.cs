using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lab07WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract] //SOA
        [WebInvoke(RequestFormat =WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json, 
            UriTemplate="GetTbAccounts", Method ="GET")] //RESTFull
        Task<List<TbAccount>> GetTbAccounts();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "saveTbAccounts", Method = "POST")] //RESTFull
        Task<TbAccount> saveAccount(TbAccount account);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
