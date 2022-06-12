using server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace server.Data
{
public class MessageData
    { // messagedata.cs
        public static List<QueryResponse> MessagesData = new List<QueryResponse>
    {  // other than id 5 - 6 more properties
    // int32 collectionId = 1;
    // bool hasAttachments = 2;
    // string subject = 3;
        new QueryResponse
        {
            CollectionId = 1,
            HasAttachments = true,
            Subject = "nill"
            // date
        },
        new QueryResponse
        {
            CollectionId = 2,
            HasAttachments = true,
            Subject = "Payment Info"
        },
        new QueryResponse
        {
            CollectionId = 3,
            HasAttachments = false,
            Subject = "Important Information"
        },
        new QueryResponse
        {
            CollectionId = 4,
            HasAttachments = true,
            Subject = "nill"
        },
        new QueryResponse
        {
            CollectionId = 5,
            HasAttachments = false,
            Subject = "Important Payment Details"
        }
    };
    }
}