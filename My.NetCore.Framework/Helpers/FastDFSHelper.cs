using FastDFS.Client;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Helpers
{
    public class FastDFSHelper
    {

        static FastDFSHelper()
        {
            var config = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (config.Value.FastDFS == null)
                throw new ArgumentNullException(nameof(config.Value.FastDFS));
            if (string.IsNullOrEmpty(config.Value.FastDFS.Host))
                throw new ArgumentNullException(nameof(config.Value.FastDFS.Host));

            var trackerIPs = new List<IPEndPoint>();
            var endPoint = new IPEndPoint(IPAddress.Parse(config.Value.FastDFS.Host), config.Value.FastDFS.Port);
            trackerIPs.Add(endPoint);
            ConnectionManager.Initialize(trackerIPs);
        }

        public static async Task<string> UpdateFile(Byte[] content, string fileExt = "jpg", string groupName = "group1")
        {
            if (content == null) throw new ArgumentNullException(nameof(content));

            var node = await FastDFSClient.GetStorageNodeAsync(groupName);
            return await FastDFSClient.UploadFileAsync(node, content, fileExt);
        }

        public static async Task<string> UpdateFile(Stream fileStream, string fileExt = "jpg", string groupName = "group1")
        {
            if(fileStream==null) throw new ArgumentNullException(nameof(fileStream));

            byte[] content = new byte[fileStream.Length];

            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                content = reader.ReadBytes((int)fileStream.Length);
            }

            var node = await FastDFSClient.GetStorageNodeAsync(groupName);
            return await FastDFSClient.UploadFileAsync(node, content, fileExt);
        }
    }
}
