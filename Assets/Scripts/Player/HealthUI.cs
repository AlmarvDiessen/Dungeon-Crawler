using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI healthText;    // Reference to the UI Text element
    [SerializeField] private Health health;                 // Reference to Health
    [SerializeField] private Image bloodAroundScreen;       // image that shows blood effect to the screen

    Color transparent = Color.white;
    Color opaque = Color.white;
    //float maxHealth = 1;
    float currentHealth;
    float maxHealth;


    void Start() {
        health = gameObject.GetComponent<Health>();
        transparent.a = 0;
        opaque.a = 1;
        bloodAroundScreen.color = transparent;
        health.onHealthChange += ChangeOpacityBlood;
    }

    private void ChangeOpacityBlood(int currentHealth, int maxHealth) {
        StartCoroutine(ChangeOpacity());
        // Update the TextMeshPro Text element with the current health value
        //healthText.text = "Health: " + currentHealth;
        //healthText.text = "Health: " + health.getHealth;

        //transparent.a = currentHealth / maxHealth;
        //Debug.Log("blood alpha is " + transparent.a);
        //bloodAroundScreen.color = transparent;
    }

    public IEnumerator ChangeOpacity() {
        Debug.Log("Blood");
        yield return new WaitForSeconds(0.4f);
        bloodAroundScreen.color = opaque;
        yield return new WaitForSeconds(0.4f);
        bloodAroundScreen.color = transparent;
    }

    private void Update() {
        // Get the health value from your Health script
        //int currentHealth = Health.Instance.health; // Replace 'YourHealthScript' with the actual name of your health script

        // Update the TextMeshPro Text element with the current health value
        //healthText.text = "Health: " + health.getHealth;
    }

    // 10 / 20
    // delegate on health change met mix en current health


    //private void TakeDamage()
    //{
    //    alphaColor.a += .1f;
    //    //health--;
    //    bloodAroundScreen.color = alphaColor;
    //}

    //private void Heal()
    //{
    //    alphaColor.a -= .1f;
    //    //health++;
    //    bloodAroundScreen.color = alphaColor;
    //}
}