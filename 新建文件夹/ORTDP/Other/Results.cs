namespace osuTools
{
    public partial class ClearAndFail
    {
        int f, c;
        public int Fails { get => f; }
        public int Clears { get => c; }
        public ClearAndFail()
        {
            f = 0;
            c = 0;
        }
        public void AddSuccess()
        {
            c++;
        }
        public void AddFail()
        {
            f++;
        }
    }
}