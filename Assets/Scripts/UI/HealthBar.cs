using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	Image healthbar;
	float maxHealth = 100;
	
	// Static so I can call it in enemy
	public static float health;

	// Start is called before the first frame update
	void Start()
    {
		healthbar = GetComponent<Image>();
		health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		healthbar.fillAmount = PlayerManager.Instance.player.health / PlayerManager.Instance.player.maxHealth;
    }
}
