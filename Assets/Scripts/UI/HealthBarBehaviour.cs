using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour{

    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset; // Noy all characters have the same height

    public void SetHealth(float health, float maxHealth){
        //The health bar should only be visible when the enemy is not at full health
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        //Set the color of the health bar dependent on how hurt the enemy is
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    // Update is called once per frame
    void Update() {
        // Transforms the position from a 3D world position to a 2D screen point
        // Where you see the object on the screen
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
