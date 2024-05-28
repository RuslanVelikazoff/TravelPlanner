using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenLoader : MonoBehaviour
{
    public bool load = false;

    [SerializeField]
    private Image loadImage;

    private void Update()
    {
        if (load)
        {
            loadImage.fillAmount += .35f * Time.deltaTime;
            
            if (loadImage.fillAmount >= 1f)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
