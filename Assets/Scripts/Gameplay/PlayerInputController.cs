﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private SpriteRenderer buttonRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyPressed;

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
}