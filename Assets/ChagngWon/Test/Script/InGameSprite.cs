using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("EndPos").GetComponent<Image>().sprite = GameObject.Find("BackGroundEnd").GetComponent<Image>().sprite = SoundManager.instance.images[SoundManager.instance.index];
        GameObject.Find("EndPos").transform.localScale = GameObject.Find("BackGroundEnd").transform.localScale = SoundManager.instance.sizes[SoundManager.instance.index];
        GameObject.Find("Recorder").GetComponent<AudioSource>().clip = SoundManager.instance.clips[SoundManager.instance.index];
        GameObject.Find("Recorder").GetComponent<Reader>().recordFile = SoundManager.instance.curNotes[SoundManager.instance.index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void main()
    {
        //if(PlayerPrefs.GetFloat(SoundManager.instance.clips[SoundManager.instance.index].name) < GameObject.Find("EndPos").GetComponent<Image>().fillAmount)
        PlayerPrefs.SetFloat(SoundManager.instance.clips[SoundManager.instance.index].name, GameObject.Find("EndPos").GetComponent<Image>().fillAmount);
        SceneManager.LoadScene("Main");
        SoundManager.instance.Pause();
        Time.timeScale = 1;
    }
}
