using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{
    
    public Animator Player;
    public Animator Enemy;
    bool PlayerState;
    bool EnemyState;
    public SpriteRenderer smear;
    public Transform p;
    public Transform e;
    public SpriteRenderer pWhite;
    public SpriteRenderer eWhite;

    void Start()
    {
        SongManager.onHitEvent += x;
        PlayerState = false;
        EnemyState = false;
    }

    void Update()
    {
        Player.SetBool("att", PlayerState);
        Enemy.SetBool("att", EnemyState);
        
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
            if (r != SongManager.Rank.PERFECT)
                StartCoroutine(perfect());
        }
        else playerHit();
    }

    public void playerAttack()
    {
        StartCoroutine(pHit());
    }

    public void playerHit()
    {
        StartCoroutine(pDam());
    }    

    IEnumerator pHit()
    {
        PlayerState = true;
        yield return new WaitForSeconds(.07f);
        eWhite.enabled = true;
        e.localRotation = new Quaternion(p.localRotation.x, 90, p.localRotation.z, p.localRotation.w);
        yield return new WaitForSeconds(.03f);
        PlayerState = false;
        eWhite.enabled = false;
        e.localRotation = new Quaternion(p.localRotation.x, 0, p.localRotation.z, p.localRotation.w);
    }

    IEnumerator pDam()
    {
        EnemyState = true;
        yield return new WaitForSeconds(.07f);
        p.localRotation = new Quaternion(p.localRotation.x, 90, p.localRotation.z, p.localRotation.w);
        pWhite.enabled = true;
        yield return new WaitForSeconds(.03f);
        EnemyState = false;
        pWhite.enabled = false;
        p.localRotation = new Quaternion(p.localRotation.x, 180, p.localRotation.z, p.localRotation.w);
    }

    IEnumerator perfect()
    {
        yield return new WaitForSeconds(.07f);
        smear.enabled = true;
        yield return new WaitForSeconds(.03f);
        smear.enabled = false;
    }
}
