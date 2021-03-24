using System.ComponentModel;

namespace YH.Arch.Domain
{
    public enum ResponseStatus : int
    {
        [Description("请求成功")]
        Success = 200,

        [Description("发送错误")]
        Error = 10000
    }
}