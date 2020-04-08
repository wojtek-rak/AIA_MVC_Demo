using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AIA_MVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AIA_MVC_Demo.Controllers
{
    public class GithubController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GithubInputModel inputModel)
        {
            var userName = inputModel.UserName;
            var repositoryName = inputModel.RepositoryName;

            var webRequest = (HttpWebRequest)WebRequest.Create($"https://api.github.com/repos/{userName}/{repositoryName}");
            webRequest.UserAgent = "userAgent";

            WebResponse webResp;

            try
            {
                webResp = webRequest.GetResponse();
            }
            catch(WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        if((int)response.StatusCode == 404)
                        {
                            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                        }
                    }
                }

                throw ex;
            }
            GithubResultModel githubResult;

            using (var reader = new StreamReader(webResp.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                githubResult = JsonConvert.DeserializeObject<GithubResultModel>(result);

            }

            return View(githubResult);
        }
    }
}