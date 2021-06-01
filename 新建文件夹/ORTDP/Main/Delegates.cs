namespace osuTools
{
    using System;
    partial class ORTDP
    {
        public delegate void OnFailedHandler(EventArgs e);
        public event OnFailedHandler OnFail;
        public delegate void OnNoFailHandler(EventArgs e);
        public event OnNoFailHandler OnNoFail;
        public delegate void OnRetryHandler(int times);
        public event OnRetryHandler OnRetry;
    }
}