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
    void Start() {
        health = gameObject.GetComponent<Health>();
        transparent.a = 0;
        opaque.a = 1;
        bloodAroundScreen.color = transparent;
        health.onHealthChange += ChangeOpacityBlood;
        healthText.text = "Health: " + health.getHealth.ToString();
    }

    private void ChangeOpacityBlood(int currentHealth, int maxHealth) {
        StartCoroutine(ChangeOpacity());
        healthText.text = "Health: " + currentHealth.ToString();
    }

    public IEnumerator ChangeOpacity() {
        Debug.Log("Blood");
        yield return new WaitForSeconds(0.4f);
        bloodAroundScreen.color = opaque;
        yield return new WaitForSeconds(0.4f);
        bloodAroundScreen.color = transparent;
    }
}