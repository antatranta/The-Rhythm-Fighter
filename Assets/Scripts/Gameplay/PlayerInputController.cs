using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Sprite defaultImage;
    public Sprite pressedImage;
    public Sprite defaultLight;
    public Sprite pressedLight;

    public KeyCode keyPressed;

    private SpriteRenderer buttonRenderer;
    private SpriteRenderer buttonLight;
    private int trackLength;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonLight = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keyPressed))
        {
            buttonLight.sprite = pressedLight;
            buttonRenderer.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyPressed))
        {
            buttonLight.sprite = defaultLight;
            buttonRenderer.sprite = defaultImage;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("User has paused the game!");
            // handle pause
        }
    }
}
