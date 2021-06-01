namespace osuTools
{

    using System;
   
   namespace osuToolsException
    {
        public class OnlineQueryFailed : Exception
        {
            public OnlineQueryFailed(string infom) : base(infom)
            {

            }
        }
        public class FailToParse:Exception
        {
            public FailToParse(string message) : base(message)
            {
               
            }
        }
        public class NoBeatmapInFolder:Exception
        {
            string f;
            public string Folder { get => f; }
            public NoBeatmapInFolder(string message,string folder):base(message)
            {
                f = folder;
            }
        }
        public class BeatmapWasNotFound : Exception
        {
           
            public BeatmapWasNotFound(string message) : base(message)
            {
               
            }
        }
        public class NoReplayInFolder:Exception
        {
            string f;
            public string Folder { get => f; }
            public NoReplayInFolder(string message, string folder) : base(message)
            {
                f = folder;
            }
        }
        public class ReplayWasNotFound : Exception
        {
           
            public ReplayWasNotFound(string message) : base(message)
            {
               
            }
        }



    }
}