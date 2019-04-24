using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    //Serialized field will show in the inspector
    [SerializeField] private HealthBar healthBar;

    public float health = 1f;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        SongManager.onHitEvent += decrementHealth;
    }

    void Update()
    {
        //Health Color Display 
        if (health > .01f)
        {
            float temp_health = 1.0f - SongManager.songPosition / SongManager.songLength; //for constant decrease, change temp_health to health
            //Decreases Enemy HP bar based on position of song. 1/8 each time
            if (temp_health <= health - 0.125f)
            {
                health = temp_health;
            }
            else if (temp_health <= 0.01f)
            {
                health = 0;
            }
            // health = 1.0f - SongManager.songPosition / SongManager.songLength;
            //Debug.Log(health);
            healthBar.SetSize(health);
            //Under 30% health
            if (health < .3f)
            {
                //Bar flashes white under 30% health
                if ((int)(health * 100f) % 2 == 0)
                {
                    healthBar.SetColor(Color.white);
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

    void decrementHealth(int trackNumber, SongManager.Rank rank)
    {
        /*if (health > 0.1f && rank == SongManager.Rank.PERFECT)
        {
            health -= .2f;
            healthBar.SetSize(health);
        }
        else if (health > 0.1f && rank == SongManager.Rank.GOOD)
        {
            health -= .1f;
            healthBar.SetSize(health);
        }
        if (health > 0.1f && rank == SongManager.Rank.OKAY)
        {
            health -= .05f;
            healthBar.SetSize(health);
        }*/
        
    }
}
