using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void botonReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
