using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.5f;
    public bool verticalScroll = false;  // Если true, фон прокручивается вертикально
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = verticalScroll ? new Vector2(0, Time.time * speed) : new Vector2(Time.time * speed, 0);
        rend.material.mainTextureOffset = offset;
    }
}
