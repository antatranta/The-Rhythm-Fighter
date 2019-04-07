using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public delegate void InputtedAction(int trackNumber);
    public static event InputtedAction inputtedEvent;

    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyPressed;

    private SpriteRenderer buttonRenderer;
    private int trackLength;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keyPressed))
        {
            buttonRenderer.sprite = pressedImage;
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                Inputted(0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Inputted(1);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Inputted(2);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Inputted(3);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Inputted(4);
            }
        }
        if (Input.GetKeyUp(keyPressed))
        {
            buttonRenderer.sprite = defaultImage;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("User has paused the game!");
            // handle pause
        }
    }

    void Inputted(int i)
    {
        // tells conductor a key was pressed
        if (inputtedEvent != null) 
        {
            inputtedEvent(i);
        }
    }
}