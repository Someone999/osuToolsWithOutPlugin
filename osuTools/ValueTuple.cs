namespace osuTools
{
    /// <summary>
    /// 框架版本不够做出来代替的ValueTuple
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class ValueTuple<T1,T2,T3>
    {
        /// <summary>
        /// 第一个值
        /// </summary>
        public T1 Value1 { get; }
        /// <summary>
        /// 第二个值
        /// </summary>
        public T2 Value2 { get; }
        /// <summary>
        /// 第三个值
        /// </summary>
        public T3 Value3 { get; }
        /// <summary>
        /// 解构函数
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        public void Deconstruct(out T1 value1,out T2 value2,out T3 value3)
        {
            value1 = Value1;
            value2 = Value2;
            value3 = Value3;
        }
        /// <summary>
        /// 用三个值初始化一个ValueTuple
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="val3"></param>
        public ValueTuple(T1 val1,T2 val2,T3 val3)
        {
            Value1 = val1;
            Value2 = val2;
            Value3 = val3;
        }
        /// <summary>
        /// 初始化一个ValueTuple，内部的值均为类型默认值
        /// </summary>
        public ValueTuple()
        {
            Value1 = default;
            Value2 = default;
            Value3 = default;
        }
    }
}