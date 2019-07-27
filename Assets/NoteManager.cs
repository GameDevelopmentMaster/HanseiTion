using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoteManager : MonoBehaviour
{
    public GameObject clearUI;
    public int Combo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instance.Pause();
            Time.timeScale = 0;
            clearUI.SetActive(true);
        }
        GameObject.Find("Combo").GetComponent<Text>().text = "Combo : " + Combo.ToString();
        if (transform.childCount >= 0)
        {

        }
    }

    public void GameStart()
    {
        SoundManager.instance.Play();
        Time.timeScale = 1;
        clearUI.SetActive(false);
    }
}
