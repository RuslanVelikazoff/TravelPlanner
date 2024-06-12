using System.Collections;
using UnityEngine;

public class PolicyLoader : MonoBehaviour
{
    public SplashScreenLoader loader;
    public UniWebView webViewForPolicy;
    public string policyLink;
    public GameObject noConnectionPanel; 
    public GameObject loadingPanel;
    public GameObject webViewPanel;
    public GameObject policyBackground, otherBackground; 
 
    private bool pageLoadComplete = false; 
 
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        CheckInitialConnection();
    }
 
    private void CheckInitialConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingPanel.SetActive(false);
            noConnectionPanel.SetActive(true);
        }
        else
        {
            NavigateBasedOnPolicyCheck();
        }
    }
 
    private IEnumerator CheckConnectionAndProceed()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingPanel.SetActive(false);
            noConnectionPanel.SetActive(true);
            yield return new WaitForSeconds(5f);
        }
 
        noConnectionPanel.SetActive(false);
        loadingPanel.SetActive(true);
        DisplayPolicyPage();
    }
 
    private void DisplayPolicyPage()
    {
        webViewForPolicy.OnPageFinished += OnWebViewForPolicyPageLoadComplete; 
        webViewForPolicy.Load(policyLink);
    }
 
    private void OnWebViewForPolicyPageLoadComplete(UniWebView webView, int statusCode, string currentUrl)
    {
        if (pageLoadComplete) return; 
 
        UpdateUIBasedOnUrl(currentUrl);
        webViewForPolicy.Show();
 
        if (policyLink != currentUrl)
        {
            Destroy(gameObject);
        }
 
        pageLoadComplete = true; 
    }
 
    private void UpdateUIBasedOnUrl(string currentUrl)
    {
        bool isPolP = currentUrl == policyLink;
        GameObject activeBackground = isPolP ? policyBackground : otherBackground;
        activeBackground.SetActive(true);
        Screen.orientation = isPolP ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolP ? "Confirmed" : currentUrl);
    }
 
    public void ConfirmPolicy()
    {
        NavigateBasedOnPolicyCheck();
    }
 
    private void NavigateBasedOnPolicyCheck()
    {
        if (PlayerPrefs.GetString("PolicyCheck", "") == "")
        {
            StartCoroutine(CheckConnectionAndProceed());
        }
        else
        {
            string policyCheck = PlayerPrefs.GetString("PolicyCheck", "");
            if (policyCheck == "Confirmed")
            {
                LoadingGameScene();
            }
            else
            {
                LoadingLink(policyCheck);
            }
        }
    }

    private void LoadingGameScene()
    {
        webViewPanel.SetActive(false);
        webViewForPolicy.gameObject.SetActive(false);
        policyBackground.SetActive(false);
        loadingPanel.SetActive(true);
        loader.StartLoad();
    }

    private void LoadingLink(string policyCheck)
    {
        webViewPanel.SetActive(true);
        webViewForPolicy.gameObject.SetActive(true);
        webViewForPolicy.Load(policyCheck);
        webViewForPolicy.Show();
        otherBackground.SetActive(true);
    }

    public void BackPage()
    {
        if (webViewForPolicy.CanGoBack)
        {
            webViewForPolicy.GoBack();
        }
    }

    public void ForwardPage()
    {
        if (webViewForPolicy.CanGoForward)
        {
            webViewForPolicy.GoForward();
        }
    }
}
