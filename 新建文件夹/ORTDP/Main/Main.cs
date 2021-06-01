using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuRTDataProvider.BeatmapInfo;
namespace osuTools
{
    
    public partial class ORTDP
    {        
        public ORTDP()
        {
            InitLisenter();
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            System.AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Sync.Tools.IO.CurrentIO.Write("ORTDP初始化完成");
            ppinfo = new SyncPPInfo("rtpp",null,null, this);
        }
        
        public ORTDP(OsuRTDataProvider.OsuRTDataProviderPlugin p)
        {
            InitLisenter(p);
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            Sync.Tools.IO.CurrentIO.Write("ORTDP初始化完成");
            ppinfo = new SyncPPInfo("rtpp",null,null, this);
            
        }
        public ORTDP(OsuRTDataProvider.OsuRTDataProviderPlugin p,RealTimePPDisplayer.RealTimePPDisplayerPlugin rp,ConsoleApp1.RtppdInfo d)
        {
            InitLisenter(p);
            if (rp != null&&d!=null)
            {
                arp = rp;
                arp.RegisterDisplayer("my", (id) => d = new ConsoleApp1.RtppdInfo());
                rtppi = (ConsoleApp1.RtppdInfo)d;
            }
            Sync.Tools.IO.CurrentIO.Write("ORTDP初始化完成");
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            ppinfo = new SyncPPInfo("rtpp", arp,rtppi,this);
           
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.IO.File.WriteAllText("osuToolsEx.txt", ((Exception)(e.ExceptionObject)).ToString());
        }
        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            System.IO.File.WriteAllText("osuToolsEx.txt", e.Exception.ToString());
        }
    }
}
