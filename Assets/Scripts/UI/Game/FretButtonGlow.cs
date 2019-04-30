using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretButtonGlow : MonoBehaviour
{
    public KeyCode keyPressed;

    private SpriteRenderer glowRenderer;
    // Start is called before the first frame update
    void Start()
    {
        glowRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            glowRenderer.color = new Color(1f, 1f, 1f, 0.35f);
        }
        if (Input.GetKeyUp(keyPressed))
        {
            glowRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
