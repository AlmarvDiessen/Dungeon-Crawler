using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    // Start is called before the first frame update

    private void Update() {
        if(Cursor.lockState == CursorLockMode.Locked ) {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
        
    }

    public void Quit() {
        Application.Quit();
    }

}
