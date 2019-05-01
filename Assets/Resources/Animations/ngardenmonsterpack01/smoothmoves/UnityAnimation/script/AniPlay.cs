using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniPlay : MonoBehaviour
{
    Animator ThisAnimator;

    // Use this for initialization
    void Start()
    {
        ThisAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            ThisAnimator.SetBool("att", true);
        }
    }
}
