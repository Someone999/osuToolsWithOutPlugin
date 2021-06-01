namespace osuTools
{
    using System.Collections.Generic;
    namespace Replay
    {
        public class ReplayCollection
        {
           
            List<OsrData> rdata = new List<OsrData>();
            public IReadOnlyList<OsrData> Replays { get => rdata.AsReadOnly(); }
            internal void Add(OsrData data) => rdata.Add(data);
            internal void Remove(OsrData data) => rdata.Remove(data);
            public bool Contains(OsrData data) => rdata.Contains(data);
            public ReplayCollection Find(string UsernName)
            {
                ReplayCollection r = new ReplayCollection();
                foreach(var replay in rdata)
                {
                    if(replay.Player==UsernName)
                    {
                        r.Add(replay);
                    }
                    if(r.Replays.Count==0)
                    {
                        throw new osuTools.osuToolsException.ReplayWasNotFound("找不到指定玩家的录像");
                    }
                }
                return r;
            }
            public IEnumerator<OsrData> GetEnumerator()=>rdata.GetEnumerator();
            
        }
        public static class ReplayTools
        {
            public static ReplayCollection GetAllReplays(string replaydir)
            {
                ReplayCollection rc = new ReplayCollection();
                string[] dirs = System.IO.Directory.GetFiles(replaydir, "*.osr", System.IO.SearchOption.AllDirectories);
                foreach (string osrfile in dirs)
                {
                    var stream= System.IO.File.OpenRead(osrfile);
                    System.IO.BinaryReader bin = new System.IO.BinaryReader(stream);
                    OsrData osr = new OsrData(bin,osrfile);                  
                    rc.Add(osr);
                }
                return rc;
            }
        }

    }
}