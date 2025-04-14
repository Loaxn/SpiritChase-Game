using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{  
    //load scene
    public void PlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }
}
