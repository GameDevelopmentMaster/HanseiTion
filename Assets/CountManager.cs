using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    public static CountManager instance;
    public Image score;
    public int totalNote;
    private int processedNote;
    public int ProCessNote
    {
        get { return processedNote; }
        set
        {
            processedNote = value;
            score.fillAmount = (float)processedNote / totalNote;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
