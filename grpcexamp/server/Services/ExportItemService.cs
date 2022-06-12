using Grpc.Core;
using server;
using server.Data;
using System;
namespace server.Services{ // export item service
    public class ExportItemService : ExportItem.ExportItemBase

    {
        private readonly ILogger<ExportItemService> _logger;
        public ExportItemService(ILogger<ExportItemService> logger)
        {
            _logger = logger;
        }
                
        public override async Task FindItems(QueryRequest request,IServerStreamWriter<QueryResponse> responseStream, ServerCallContext context)
        {
            string req = request.Filter;
            req.Trim();
            string[] sep = req.split(" ");
            bool? flag = null;
            string subj = "";
            for(int i = 0 ; i < sep.Length ; i++){
                if(sep[i].Contains("HasAttachments")){
                    if(sep[i+2] == "true"){
                        flag = true;
                    }
                    else{
                        flag = false;
                    }
                }
                if(sep[i].Contains("subject")){
                    subj = sep[i+2];
                }
            }
            var items = MessageData.MessagesData.Where(p => p.HasAttachments == flag && p.Subject.Contains(subj)).ToList();
            foreach(var item in items){
                await responseStream.WriteAsync(item);
            }
        }
}

}

//C:\Users\t-anigupta\grpcexamp\server\Services\ExportItemService.cs