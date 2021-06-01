﻿using System;
using System.IO;
using System.Net;
using osuTools.Online.ApiV2.Authorization;

namespace osuTools.Online.ApiV2
{
    /// <summary>
    ///     用于向OsuApiV2查询谱面
    /// </summary>
    public class OnlineBeatmapQueryV2
    {
        /// <summary>
        ///     <see cref="OsuApiV2Token" />，可以通过<see cref="OsuApiV2Authorization" />来获取
        /// </summary>
        public OsuApiV2Token Token { get; set; }

        /// <summary>
        ///     谱面ID
        /// </summary>
        public int BeatmapID { get; set; }

        private void getResult()
        {
            if (Token == null)
                throw new InvalidOperationException(
                    "必须指定一个Token。Token可以从Online.ApiV2.Authorization.OsuApiV2Authorization获取。");
            var uri = $"https://osu.ppy.sh/api/v2/beatmaps/{BeatmapID}";
            var request = WebRequest.CreateHttp(uri);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token.AccessToken}");
            if (request is null)
                throw new NullReferenceException();
            var r = new StreamReader(request.GetResponse().GetResponseStream() ?? new MemoryStream());
            var recvjson = r.ReadToEnd();
        }
    }
}