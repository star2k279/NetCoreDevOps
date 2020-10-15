using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PubnubApi;

namespace DotNetCoreDockerized
{
    public class PubNubNotifications
    {
        PNConfiguration pnConfiguration;
        Pubnub pubnub;
        Dictionary<string, string> message;
        public string UUID { get; set; }


        public PubNubNotifications()
        {
            pnConfiguration = new PNConfiguration();
            message = new Dictionary<string, string>();
            pnConfiguration.SubscribeKey = "sub-c-c0cb392e-07a9-11eb-9e1f-6e4e1d22e241";
            pnConfiguration.PublishKey = "pub-c-22a551fa-e5aa-4836-b54f-f2f758654d31";
            pnConfiguration.SecretKey = "sec-c-MzI0OWZlNGQtNjUxNi00ODAyLWFmZWYtYWE3ZjIxMjM4NzI2";
            pnConfiguration.Uuid = "devOpsAPI";
            pnConfiguration.Secure = true;
            pubnub = new Pubnub(pnConfiguration);
            message.Add("msg", "Hello to Devops training using Docker Containers and Azure");
        }


        public async Task<ResponseData> PublishMessages(string channelName)
        {
            ResponseData data = new ResponseData();
            PNResult<PNPublishResult> publishResponse = await pubnub.Publish().Channel(channelName)
                                                               .Message(message)
                                                               .ExecuteAsync();
            data.responseResult = publishResponse.Result != null ? publishResponse.Result.Timetoken.ToString() : string.Empty;
            data.status = publishResponse.Status != null ? publishResponse.Status.StatusCode.ToString() : string.Empty;
            return data;
        }

        public async Task<ResponseData> RegisterDevice(string deviceToken)
        {
            ResponseData data = new ResponseData();
            PNResult<PNPushAddChannelResult> response = await pubnub.AddPushNotificationsOnChannels()
                  .PushType(PNPushType.APNS)
                  .Channels(new string[] { "DevOps_Channel" })
                  .DeviceId(deviceToken)
                  .ExecuteAsync();
            data.responseResult = response.Result != null ? response.Result.ToString() : string.Empty;
            data.status = response.Status != null ? response.Status.StatusCode.ToString() : string.Empty;
            return data;
        }
    }

    public class ResponseData
    {
        public string responseResult {get; set;}
        public string status { get; set; }
    }
}
