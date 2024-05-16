using RestSharp;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Timers;

namespace TaskService
{
    public partial class Service1 : ServiceBase
    {
        readonly Request requestClass;
        readonly Response responseClass;
        readonly FileHandler fileHandler;
        public Service1()
        {
            InitializeComponent();
            requestClass = new Request();
            responseClass = new Response();
            fileHandler = new FileHandler();
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            string filePath = fileHandler.GetFileDirectory("Requests.csv");
            List<Request> requests = requestClass.ReadRequests(filePath);
            foreach (var request in requests)
            {
                string body = requestClass.SerializeData(request);
                IRestResponse response = requestClass.SubmitRequest(body);
                responseClass.HandleResponse(response, request.MobileNumber);
            }
            fileHandler.MoveFiles("Done", "Requests.csv");
        }

        protected override void OnStop()
        {
        }
    }
}
