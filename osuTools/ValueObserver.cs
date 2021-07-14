using System.Diagnostics;

namespace osuTools
{
    /// <summary>
    /// 框架版本不做做出来代替的ValueTuple
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
    /// <summary>
    /// 值变化时可触发事件的包装器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueObserver<T>
    {
        private T _val;
        private T _oldVal;
        /// <summary>
        /// 是否在改变值时中断，这个选项只在Debug模式下生效
        /// </summary>
        public bool BreakWhenChange { get; set; }
        /// <summary>
        /// 使用一个值初始化，并可以指定是否在初始化时中断。中断仅在Debug模式下有效
        /// </summary>
        /// <param name="val">初始值</param>
        /// <param name="breakWhenAssign">是否在初始化时中断</param>
        public ValueObserver(T val = default,bool breakWhenAssign = false)
        {

            _val = val;
            if (breakWhenAssign)
                Debugger.Break();
        }
        /// <summary>
        /// 获取或更改其中的值
        /// </summary>
        public T Value
        {
            get => _val;
            set
            {
                if (_val == null)
                {

                    OnChanged(_val, value);
                    _val = value;
                    if (BreakWhenChange)
                        Debugger.Break();
                }
                else if (!_val.Equals(value))
                {

                    _oldVal = _val;
                    OnChanged(_oldVal, value);
                    _val = value;
                    if (BreakWhenChange)
                        Debugger.Break();
                }

            }
        }
        /// <summary>
        /// 更改之前的值。在未发生更改的情况下，为类型的默认值
        /// </summary>
        public T OldValue => _oldVal;

        /// <summary>
        /// 为OnChanged提供参数
        /// </summary>
        /// <param name="oldVal">更改前的值</param>
        /// <param name="val">更改后的值</param>
        public delegate void Changed(T oldVal, T val);
        /// <summary>
        /// 值发生更改时触发的事件
        /// </summary>

        public event Changed OnChanged = (oldVal, val) => { };
        /// <summary>
        /// 将其中存储的值隐式转换为对应的类型
        /// </summary>
        /// <param name="observer"></param>

        public static implicit operator T(ValueObserver<T> observer)
        {
            return observer.Value;
        }
        /// <summary>
        /// 使用外部值构造一个新的<see cref="ValueObserver{T}"/>
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ValueObserver<T>(T val)
        {
            return new ValueObserver<T>(val);
        }
        /// <summary>
        /// 使用外部值构造一个新的<see cref="ValueObserver{T}"/>
        /// </summary>
        /// <param name="val"></param>
        /// <param name="breakWhenAssign">是否在赋值时中断，这个选项只在Debug模式下生效</param>
        public static ValueObserver<T> FromValue(T val, bool breakWhenAssign = false)
        {
            var c = new ValueObserver<T>(val,breakWhenAssign);
            return c;

        }
    }
}
