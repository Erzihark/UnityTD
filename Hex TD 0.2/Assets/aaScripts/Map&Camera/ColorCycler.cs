using UnityEngine;

public class ColorCycler : MonoBehaviour
{

    private Color color;
    public float R;
    public float G;
    public float B;
    private float min = 0f, max = 2.5f;
    private float speed = 2f;

    Renderer rend;

    static readonly int materialColor = Shader.PropertyToID("_EmissionColor");

    private void Start()
    {
        rend = GetComponent<Renderer>();

    }

    private void Update()
    {
        color = new Color(R, G, B, 2);
        rend.material.SetColor(materialColor, color);

        if (R == min && G < max && B == min)
        {
            G += speed * Time.deltaTime;
            if (G > max)
                G = max;
        }

        if (R < max && G == max && B == min)
        {
            R += speed * Time.deltaTime;
            if (R > max)
                R = max;
        }
        if (R == max && G > min && B == min)
        {
            G -= speed * Time.deltaTime;
            if (G < min)
                G = min;
        }
        if (R == max && G == min && B < max)
        {
            B += speed * Time.deltaTime;
            if (B > max)
                B = max;
        }
        if (R > min && G == min && B == max)
        {
            R -= speed * Time.deltaTime;
            if (R < min)
                R = min;
        }
        if (R == min && G < max && B == max)
        {
            G += speed * Time.deltaTime;
            if (G > max)
                G = max;
        }
        if (R == min && G == max && B > min)
        {
            B -= speed * Time.deltaTime;
            if (B < min)
                B = min;
        }

   

    }


}