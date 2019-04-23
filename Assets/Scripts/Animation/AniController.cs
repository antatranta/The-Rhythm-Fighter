using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{
    
    public Animator Player;
    public Animator Enemy;
    int PlayerState;
    int EnemyState;

    void Start()
    {
        SongManager.onHitEvent += x;
        PlayerState = 0;
        EnemyState = 0;
    }

    void Update()
    {
        Player.SetInteger("Player State", PlayerState);
        Enemy.SetInteger("Enemy State", EnemyState);
    }

    private void OnDestroy()
    {
        SongManager.onHitEvent -= x;
    }

    void x(int t, SongManager.Rank r)
    {
        if (r != SongManager.Rank.MISS)
        {
            playerAttack();
        }
        else playerHit();
    }

    public void playerAttack()
    {
        StartCoroutine(pHit(1));
    }

    public void playerHit()
    {
        StartCoroutine(pHit(2));
    }    

    IEnumerator pHit(int state)
    {
        PlayerState = state;
        EnemyState = state;
        yield return new WaitForSeconds(.1f);
        PlayerState = 0;
        EnemyState = 0;
    }
}
