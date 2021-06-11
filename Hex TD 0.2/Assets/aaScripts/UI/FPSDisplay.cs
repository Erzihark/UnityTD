using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
    private int interval = 6;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);

        if (Time.frameCount % interval == 0)
        {
            avgFrameRate = (int)current;
            display_Text.text = avgFrameRate.ToString() + " FPS";
        }
        
    }
}

