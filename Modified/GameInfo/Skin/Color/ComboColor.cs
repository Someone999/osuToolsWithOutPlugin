using System;
namespace osuTools.Skins.Colors
{
    public enum ComboNumber {Last = 1,First,Second,Third,Fourth,Fifth,Sixth,Seventh }
    public class ComboColor:RGBColor
    {
        public ComboColor(int r, int g, int b) : base(r, g, b)
        {
        }
    }
    public class ComboColorCollection
    {
        internal void setColor(ComboNumber comboNum,ComboColor color)
        {          
            switch(comboNum)
            {
                case ComboNumber.Last:LastCombo = color;break;
                case ComboNumber.First: FirstCombo = color; break;
                case ComboNumber.Second: SecondCombo = color; break;
                case ComboNumber.Third: ThirdCombo = color; break;
                case ComboNumber.Fourth: FourthCombo = color; break;
                case ComboNumber.Fifth: FifthCombo = color; break;
                case ComboNumber.Sixth: SixthCombo = color; break;
                case ComboNumber.Seventh: SeventhCombo = color; break;
                default:throw new ArgumentException("输入的序号错误。");
            }                
        }
        public ComboColorCollection()
        {           
        }
        public ComboColor LastCombo { get; private set; } = new ComboColor(255, 192, 0);
        public ComboColor FirstCombo { get; private set; } = new ComboColor(0, 202, 0);
        public ComboColor SecondCombo { get; private set; } = new ComboColor(181, 24, 255);
        public ComboColor ThirdCombo { get; private set; } = new ComboColor(242, 24, 57);
        public ComboColor FourthCombo { get; private set; }
        public ComboColor FifthCombo { get; private set; }
        public ComboColor SixthCombo { get; private set; }
        public ComboColor SeventhCombo { get; private set; }
    }
}