using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EndDeviceService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AvionicsCloud.UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private IHttpClientFactory _iHttpClientFactory;
        public TargetsController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }

        /// <summary>
        /// 获取目标位置
        /// </summary>        
        [HttpGet]
        public async Task<ActionResult<Position>> GetAsync()
        {
            var client = _iHttpClientFactory.CreateClient();
            var response = await client.GetStringAsync("http://enddeviceservice/targets");
            var position = JsonConvert.DeserializeObject<Position>(response);
            return Ok(position);
        }
    }
}