using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public string loadScene;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(loadScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
