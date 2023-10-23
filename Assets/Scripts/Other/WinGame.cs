using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField]    Canvas winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        //Time.timeScale = 0.0f;
        //CanvasObject.GetComponent<Canvas> ().enabled = false;    
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
