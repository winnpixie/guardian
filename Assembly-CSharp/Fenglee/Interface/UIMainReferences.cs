using System.Collections;
using System.IO;
using UnityEngine;

public class UIMainReferences : MonoBehaviour
{
    public static GameObject InputManagerObj;
    public static string Version = "01042015";
    public static string FengVersion = "01042015";
    private static bool IsFirstInit = true;

    public GameObject panelMain;
    public GameObject panelOption;
    public GameObject panelMultiROOM;
    public GameObject PanelMultiJoinPrivate;
    public GameObject PanelMultiWait;
    public GameObject PanelDisconnect;
    public GameObject panelMultiSet;
    public GameObject panelMultiStart;
    public GameObject panelCredits;
    public GameObject panelSingleSet;
    public GameObject PanelMultiPWD;
    public GameObject PanelSnapShot;

    private void Start()
    {
        string rcBuild = "8/12/2015";

        NGUITools.SetActive(panelMain, state: true);
        GameObject.Find("VERSION").GetComponent<UILabel>().text = "[9999FF]RC [-]" + rcBuild + " | [FFBB00]Guardian [-]" + Guardian.GuardianClient.Build;

        if (IsFirstInit)
        {
            IsFirstInit = false;

            Version = FengVersion;
            InputManagerObj = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("InputManagerController"));
            InputManagerObj.name = "InputManagerController";
            UnityEngine.Object.DontDestroyOnLoad(InputManagerObj);
            LoginFengKAI.LoginState = LoginState.LoggedOut;

            StartCoroutine(CoLoadAssets());
        }
    }

    private IEnumerator CoLoadAssets()
    {
        AssetBundleCreateRequest abcr = AssetBundle.CreateFromMemory(File.ReadAllBytes(Application.dataPath + "/RCAssets.unity3d"));
        yield return abcr;
        FengGameManagerMKII.RCAssets = abcr.assetBundle;

        FengGameManagerMKII.IsAssetLoaded = true;
    }
}
