namespace osuTools
{
    namespace Skins
    {
        interface ManiaSkinBase
        {
            /// <summary>
            /// 判定线的位置
            /// </summary>
            int HitPosition { get; }
            /// <summary>
            /// 是否显示判定线
            /// </summary>
            bool JudgementLine { get; }
            /// <summary>
            /// 小节线的高度
            /// </summary>
            bool BarlineHeight { get; }
        }
    }
}