using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image Image;
    public AnimationCurve curve;
    int fadeSpeed = 2;

    private void Start()
    {
       StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * fadeSpeed;
            float a = curve.Evaluate(t); //controls the curve
            Image.color = new Color(0f, 0f, 0f, a); // this modifies the alpha value
            WaveSpawnerTopRight_Main.fadeIn = true;
            yield return 0; //skips to the next frame
        }
        if(t <= 0)
        {
            WaveSpawnerTopRight_Main.fadeIn = false;
        }
        MobileCameraControlBackup.gameEnd = false;
        Wave.EnemiesAlive = 0;
        WaveSpawnerTopRight_Main.EnemyCount = 0;
        WaveSpawnerTopRight_Main.countdown = 4f;
        WaveSpawnerTopRight_Main.startFirstWave = 0;
        OxygenUI.oxygenDepleteRate = 1000;
        Health.gameOver = false;

        BasicMovement.WallBottomLeftDestroyed = false;
        BasicMovement.WallBottomRightDestroyed = false;
        BasicMovement.WallTopLeftDestroyed = false;
        BasicMovement.WallTopRightDestroyed = false;

        //load a scene
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            float a = curve.Evaluate(t); //controls the curve
            Image.color = new Color(0f, 0f, 0f, a); // this modifies the alpha value
            yield return 0; //skips to the next frame
        }
        //load a scene

        SceneManager.LoadScene(scene);
    }

}
