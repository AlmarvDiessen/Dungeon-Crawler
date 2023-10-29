using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;    // Reference to the UI Text element
    [SerializeField] private Health health;                 // Reference to Health
    [SerializeField] private Image bloodAroundScreen;       // image that shows blood effect to the screen

    Color alphaColor = Color.white;
    //float maxHealth = 1;
    float currentHealth;
    float maxHealth;


    void Start()
    {
        health = gameObject.GetComponent<Health>();
        //health.onHealthChange +=
        //bloodAroundScreen
        health.onHealthChange += ChangeOpacityBlood;
        alphaColor.a = 1;

    }

    private void ChangeOpacityBlood(int currentHealth, int maxHealth)
    {

        // Update the TextMeshPro Text element with the current health value
        //healthText.text = "Health: " + currentHealth;
        healthText.text = "Health: " + health.getHealth;

        alphaColor.a = currentHealth / maxHealth;
        Debug.Log("blood alpha is " + alphaColor.a);
        bloodAroundScreen.color = alphaColor;
    }

    private void Update()
    {
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