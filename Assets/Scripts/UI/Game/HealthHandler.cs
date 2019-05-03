using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour {

    //Serialized field will show in the inspector
    [SerializeField] private HealthBar healthBar;

    public float health = 1f;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        SongManager.onHitEvent += DecrementHealth;
    }
    
    void Update()
    {
        //Health Color Display 
        if (health > .01f)
        {
            healthBar.SetSize(health);
            //Under 30% health
            if (health < .3f)
            {
                //Bar flashes white under 30% health
                if ((int)(health * 100f) % 2 == 0)
                {
                    //healthBar.SetColor(Color.white);
                }
                else
                {
                    healthBar.SetColor(Color.red);
                }
            }
        }
        else
        {
            health = 1f;
            healthBar.SetColor(Color.red);
        }
    }
    
    //Healthbar update related to missing notes
    void DecrementHealth(int trackNumber, SongManager.Rank rank)
    {
        if (health > 0f && rank == SongManager.Rank.MISS)
        {
            health -= .05f;
        }
        else if (health < 1f && rank == SongManager.Rank.OKAY) 
        {
            health += .01f;
        }
        else if (health < 1f && rank == SongManager.Rank.GOOD)
        {
            health += .025f;
        }
        else if (health < 1f && rank == SongManager.Rank.PERFECT)
        {
            health += .05f;
        }
        healthBar.SetSize(health);
    }
    
    void OnDestroy() 
    {
        SongManager.onHitEvent -= DecrementHealth;
    }
}
