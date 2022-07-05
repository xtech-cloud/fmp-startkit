using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.Bridge
{
    /// <summary>
    /// 刷新视图的结果（协议部分）
    /// </summary>
    public interface IHealthyUiProtoBridge : View.Facade.Bridge
    {
        void Alert(string _code, string _message);
        void RefreshEcho(IDTO _dto);
    }
}
