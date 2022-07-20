using Steamworks;
using UnityEngine;
/// <summary>
/// Steam小额支付管理类
/// 小额支付文档：https://partner.steamgames.com/doc/features/microtransactions/implementation
/// </summary>
public class SteamSdk
{
    static SteamSdk() {
        _instance = null;
    }
    static private SteamSdk _instance = null;
    private SteamSdk Instance {
        get {
            return _instance;
        }
    }
    #region Steam支付相关
    private string url = @"https://partner.steam-api.com/ISteamMicroTxn/*";
    private string test_url = @"https://partner.steam-api.com/ISteamMicroTxnSandbox/*";
    private CallResult<MicroTxnAuthorizationResponse_t> m_MicroTxnAuthorizationResponse_t;
    public void StartPay() {

        CSteamID cSteamID = SteamUser.GetSteamID();
        AppId_t appId_t = SteamUtils.GetAppID();
        uint appId = null != appId_t ? appId_t.m_AppId : 0;
        ulong steamId = null != cSteamID? cSteamID.m_SteamID:0;
        string gameLang = SteamApps.GetCurrentGameLanguage();
        if (appId <= 0 || steamId <= 0) {
            Debug.LogError("appid或SteamId不能为0");
            return;
        }
        //string ctryCode = SteamUtils.GetIPCountry();
        //string currency = "";

        if (null == m_MicroTxnAuthorizationResponse_t)
        {
            m_MicroTxnAuthorizationResponse_t = CallResult<MicroTxnAuthorizationResponse_t>.Create(OnMicroTxnAuthorizationResponse);
        }
    }
    /// <summary>
    /// 购买结果回调,将交易结果告知服务器，以确认最终交易
    /// </summary>
    /// <param name="pCallback"></param>
    /// <param name="bIOFailure"></param>
    private void OnMicroTxnAuthorizationResponse(MicroTxnAuthorizationResponse_t pCallback, bool bIOFailure) {
        if (bIOFailure)
        {
            Debug.Log(string.Format("### Pay Error. m_unAppID:{0},m_ulOrderID:{1},m_bAuthorized:{2}", pCallback.m_unAppID, pCallback.m_ulOrderID, pCallback.m_bAuthorized));
        }
        else
        {
            
        }
    }
    #endregion
    public void GetTicket() {
        //SteamUser.GetAuthSessionTicket();
        //SteamUser.GetEncryptedAppTicket();
        //SteamUser.RequestEncryptedAppTicket();
    }
}
