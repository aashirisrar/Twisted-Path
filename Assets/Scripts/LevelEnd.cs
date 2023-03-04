using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject nextLevelMenu;
    public GameObject pauseBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            nextLevelMenu.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
