using Lib.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AUwebServices.Controllers
{
    public class ServersController : Controller
    {
        private HttpClient client;

        private string APIpath = UI.Properties.Settings.Default.API;
        
        public ServersController ()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// !Current route will be return JSON with all servers list!
        /// </summary>
        /// <returns></returns>
        // GET: Servers
        public async Task<ActionResult> Index()
        {
            IEnumerable<Server> servers = null;

            string json = await client.GetStringAsync($"{APIpath}/Servers");

            servers = JsonConvert.DeserializeObject<IEnumerable<Server>>(json);

            return View(servers);
        }

        /// <summary>
        /// !Page with form -> form with POST request (make veiw)!
        /// !In view should be checked on null!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Server serverForUpdating = null;

            HttpResponseMessage response = await client.GetAsync($"{APIpath}/Servers/{id}");

            if (response.IsSuccessStatusCode)
            {
                serverForUpdating = await response.Content.ReadAsAsync<Server>();
            }

            return View(serverForUpdating);
        }
        
        /// <summary>
        /// !REQUEST from updating form!
        /// </summary>
        /// <param name="server"></param>
        [HttpPut]
        public async Task<HttpStatusCode> Edit(Server server)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{APIpath}/Servers", server);

            return response.IsSuccessStatusCode ? HttpStatusCode.OK : HttpStatusCode.NotFound;

        }

        /// <summary>
        /// !you should add "ADD" view with form!
        /// </summary>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// !you should send POST request from form after submit button click!
        /// </summary>
        [HttpPost]
        public async Task<HttpStatusCode> Add(Server server)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{APIpath}/Servers", server);
            
            return response.IsSuccessStatusCode ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        }

        /// <summary>
        /// !It is just request on some link use this controller with id parameter into link url!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<HttpStatusCode> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{APIpath}/Servers/{id}");

            return response.IsSuccessStatusCode ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        }
    }
}