using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI healthText; // Reference to the UI Text element
   [SerializeField] private Health health; // Reference to Health

    void Start()
    {
        health = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        // Get the health value from your Health script
        //int currentHealth = Health.Instance.health; // Replace 'YourHealthScript' with the actual name of your health script

        // Update the TextMeshPro Text element with the current health value
        healthText.text = "Health: " + health.getHealth;
    }
}