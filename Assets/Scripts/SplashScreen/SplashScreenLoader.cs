using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenLoader : MonoBehaviour
{
    private bool load = false;

    [SerializeField]
    private Image loadImage;

    private void Update()
    {
        if (load)
        {
            loadImage.fillAmount += .35f * Time.deltaTime;
            
            if (loadImage.fillAmount >= 1f)
            {
                Screen.orientation = ScreenOrientation.Portrait;
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void StartLoad()
    {
        load = true;
    }
}
