using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EndDeviceService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EndDeviceService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private IHttpClientFactory _iHttpClientFactory;
        public WeaponsController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }

        /// <summary>
        /// 向SMP发送外挂数据
        /// </summary>        
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Weapon weapon)
        {
            var client = _iHttpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(weapon));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://enddeviceservice/weapons", content);
            response.EnsureSuccessStatusCode();
            return Ok();
        }

        /// <summary>
        /// 获取外挂信息
        /// </summary>        
        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> GetAsync()
        {
            var client = _iHttpClientFactory.CreateClient();
            var response = await client.GetStringAsync("http://enddeviceservice/weapons");
            var weapons = JsonConvert.DeserializeObject<List<Weapon>>(response);
            return Ok(weapons);
            //return Ok(new List<Weapon>(){new Weapon(){Type = WeaponType.PL10, num=1}});
        }

    }
}