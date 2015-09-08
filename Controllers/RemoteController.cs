using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using LircSharpAPI.Models;
using Newtonsoft.Json;

namespace LircSharpAPI.Controllers
{
    public class RemotesController : Controller
    {
        // GET: api/remotes
        [RouteAttribute("api/remotes")]
        [HttpGet]
        public string Get()
        {
            /* Get our remotes */
            LircSharpAPI.DAL.DAL dal = new DAL.DAL();
            List<Remote> remotes = dal.GetRemotes();
            
            /* Return as JSON */
            return JsonConvert.SerializeObject(remotes, Formatting.Indented);
        }

        // GET api/remotes/pioneer
        [RouteAttribute("api/remotes/{remoteName}")]
        [HttpGet]
        public string Get(string remoteName)
        {
           /* Get our specified remote */
            LircSharpAPI.DAL.DAL dal = new DAL.DAL();
            Remote remote = dal.GetRemote(remoteName);
            
            /* Return as JSON */
            return JsonConvert.SerializeObject(remote, Formatting.Indented);
        }
        
        // GET api/remotes/pioneer
        [RouteAttribute("api/remotes/{remoteName}/commands/{commandName}")]
        [HttpGet]
        public string Get(string remoteName, string commandName)
        {
           /* Get our specified remote */
            LircSharpAPI.DAL.DAL dal = new DAL.DAL();
            Remote remote = dal.GetRemote(remoteName);
            
            /* Return as JSON */
            return JsonConvert.SerializeObject(remote, Formatting.Indented);
        }

        // POST api/values
        [RouteAttribute("api/remotes/{remoteName}/commands/{commandName}")]
        [HttpPost]
        public void Post([FromBody]string remoteName, string commandName) 
        {
            LircSharpAPI.DAL.DAL dal = new DAL.DAL();
            RemoteCode code = new RemoteCode();
            
            code.RemoteName = remoteName;
            code.Name = commandName;
            
            dal.SendRemoteCode(code);
            
        }
    }
}