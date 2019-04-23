using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTester : MonoBehaviour
{
    AniController A;
    void Start()
    {
        A = GetComponent<AniController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) A.playerHit();
        else if (Input.GetKeyDown(KeyCode.A)) A.playerAttack();
    }
}
