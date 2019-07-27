using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public int index;
    public AudioSource audio;
    public AudioClip[] clips=new AudioClip[3];
    public GameObject[] texts = new GameObject[3];
    public TextAsset[] curNotes = new TextAsset[3];
    public Sprite[] images = new Sprite[3];
    public Vector2[] sizes = new Vector2[3];
    public int Index
    {
        get { return index; }
        set
        {
            index = value;
            audio.clip = clips[index];
            for(int i = 0; i < 3; i++)
            {
                texts[i].SetActive(false);
            }
            texts[index].SetActive(true);
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            SoundManager.instance.texts[0] = GameObject.Find("Stage_1");
            SoundManager.instance.texts[1] = GameObject.Find("Stage_2");
            SoundManager.instance.texts[2] = GameObject.Find("Stage_3");
            SoundManager.instance.Index = 0;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        Index = 0;
        Stop();
    }
    private void Update()
    {
        if (GameManager.instance != null) {
            if (GameManager.instance.GameState == GameState.Collection)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    Left();
                    Stop();
                    Play();
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Right();
                    Stop();
                    Play();
                }
        }
        }
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
    public void Left()
    {
        if (Index >=1)
        {
            Index--;
        }
    }
    public void Right()
    {
        if (Index <=1)
        {
            Index++;
        }
    }
    public void Play()
    {
        audio.Play();
    }
    public void Stop()
    {
        audio.Stop();
    }
    public void Pause()
    {
        audio.Pause();

    }
    public void SetVolum(float f)
    {
        audio.volume = f;
    }

}
