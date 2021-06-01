using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuTools.Skins.Exceptions
{
    public class SkinFileNotFoundException:Exception
    {
        public SkinFileNotFoundException():base("找不到文件。可能是该皮肤没有定义该元素或者该元素没有使用png格式的图片。")
        {
        }
        public SkinFileNotFoundException(string msg):base(msg)
        {
        }
    }
}
