namespace osuTools
{
    /// <summary>
    /// 因为.NetFramework 4.6.2缺少ValueTuple，这是一个临时代替品
    /// </summary>
    /// <typeparam name="T1">元素1的类型</typeparam>
    /// <typeparam name="T2">元素2的类型</typeparam>
    /// <typeparam name="T3">元素3的类型</typeparam>
    public class ValueTuple<T1,T2,T3>
    {
        /// <summary>
        /// 获取元素1
        /// </summary>
        public T1 Item1 { get; }
        /// <summary>
        /// 获取元素2
        /// </summary>
        public T2 Item2 { get; }
        /// <summary>
        /// 获取元素3
        /// </summary>
        public T3 Item3 { get; }
        /// <summary>
        /// 解构函数
        /// </summary>
        /// <param name="val1">元素1的值</param>
        /// <param name="val2">元素2的值</param>
        /// <param name="val3">元素3的值</param>
        public ValueTuple(T1 val1,T2 val2,T3 val3)
        {
            Item1 = val1;
            Item2 = val2;
            Item3 = val3;
        }
        /// <summary>
        /// 解构函数
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="val3"></param>
        public void Deconstruct(out T1 val1, out T2 val2, out T3 val3)
        {
            val1 = Item1;
            val2 = Item2;
            val3 = Item3;
        }
    }
}
