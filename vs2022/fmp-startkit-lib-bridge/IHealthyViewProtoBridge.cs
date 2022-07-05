using System.Threading.Tasks;
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.Bridge
{
    /// <summary>
    /// 处理UI触发的事件（协议部分）
    /// </summary>
    public interface IHealthyViewProtoBridge : View.Facade.Bridge
    {
        Task OnEchoSubmit(IDTO _dto);
    }

}
