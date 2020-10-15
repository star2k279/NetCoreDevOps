using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubnubApi;
using static DotNetCoreDockerized.PubNubNotifications;

namespace DotNetCoreDockerized.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevopsTrainingController : ControllerBase
    {
        PubNubNotifications _pubNubNotifications;
        public DevopsTrainingController(PubNubNotifications pubnubNotifications)
        {
            _pubNubNotifications = pubnubNotifications;
        }

        [HttpPost]
        public async Task<ResponseData> Post([FromQuery]string channelName)
        {
            return await _pubNubNotifications.PublishMessages(channelName);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ResponseData> Subscribe([FromQuery]string deviceToken)
        {
            return await _pubNubNotifications.RegisterDevice(deviceToken);
        }
    }
}
