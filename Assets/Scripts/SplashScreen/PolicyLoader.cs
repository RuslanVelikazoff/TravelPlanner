using System.Collections;
using UnityEngine;

public class PolicyLoader : MonoBehaviour
{
    public GameObject webViewPanel;
    public SplashScreenLoader splashScreen;
    public UniWebView policyWebView;
    public string policyUrl;
    public GameObject noConnectionPanel;
    public GameObject loadingPanel;
    public GameObject policyBackground, otherBackground;
    
    private bool pageLoaded = false; 

    private void Start()
    {
        StartConfiguration();
        CheckInternetConnection();
    }

    private void StartConfiguration()
    {
        policyWebView.gameObject.SetActive(true);
        webViewPanel.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingPanel.SetActive(false);
            noConnectionPanel.SetActive(true);
        }
        else
        {
            CheckConfirmedPolicy();
        }
    }

    private IEnumerator CheckConnectionAndOpenPanel()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingPanel.SetActive(false);
            noConnectionPanel.SetActive(true);
            yield return new WaitForSeconds(5f);
        }

        noConnectionPanel.SetActive(false);
        PolicyLoadUrl();
    }

    private void PolicyLoadUrl()
    {
        policyWebView.OnPageFinished += PageLoaded;
        policyWebView.Load(policyUrl);
    }

    private void PageLoaded(UniWebView viewer, int code, string currentLink)
    {
        if (pageLoaded) return; 

        OpenRightPanelAndBackground(currentLink);
        policyWebView.Show();

        if (policyUrl != currentLink)
        {
            Destroy(gameObject);
        }

        pageLoaded = true; 
    }

    private void OpenRightPanelAndBackground(string currentLink)
    {
        bool isPolicy = currentLink == policyUrl;
        GameObject currentBackground = isPolicy ? policyBackground : otherBackground;
        currentBackground.SetActive(true);
        Screen.orientation = isPolicy ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolicy ? "Verified" : currentLink);
    }

    public void ConfirmPolicy()
    {
        webViewPanel.SetActive(false);
        policyBackground.SetActive(false);
        CheckConfirmedPolicy();
        policyWebView.gameObject.SetActive(false);
    }

    private void CheckConfirmedPolicy()
    {
        if (PlayerPrefs.GetString("PolicyCheck", "") == "")
        {
            StartCoroutine(CheckConnectionAndOpenPanel());
        }
        else
        {
            string policyResult = PlayerPrefs.GetString("PolicyCheck", "");
            if (policyResult == "Confirmed")
            {
                loadingPanel.SetActive(true);
                splashScreen.load = true;
            }
            else
            {
                policyWebView.Load(policyResult);
                policyWebView.Show();
                otherBackground.SetActive(true);
            }
        }
    }

    public void BackButtonAction()
    {
        if (policyWebView.CanGoBack)
        {
            policyWebView.GoBack();
        }
    }

    public void ForwardButtonAction()
    {
        if (policyWebView.CanGoForward)
        {
            policyWebView.GoForward();
        }
    }
}
