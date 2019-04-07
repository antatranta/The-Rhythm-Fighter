using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils; //free utils offered by codemonkey

public class GameHandler : MonoBehaviour {

    //Serialized field will show in the inspector
    [SerializeField] private HealthBar healthBar; 

	private void Start () {
        float health = 1f;

        FunctionPeriodic.Create(() => {
            if (health > .01f) {
                health -= .01f;
                healthBar.SetSize(health);
                //Under 30% health
                if (health < .3f) {
                   //Bar flashes white under 30% health
                    if ((int)(health * 100f) % 3 == 0) {
                        healthBar.SetColor(Color.white);
                    } else {
                        healthBar.SetColor(Color.red);
                    }
                }
            } else {
                health = 1f;
                healthBar.SetColor(Color.red);
            }
        }, .05f);
	}
}
