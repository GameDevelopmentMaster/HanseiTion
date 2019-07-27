using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSort : MonoBehaviour
{
    RectTransform rt;
    int index;
    public int Index
    {
        get { return index; }
        set
        {
            index = value;
            rt.anchoredPosition = new Vector2(index * 1300, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        Debug.Log(rt.anchoredPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator iSort(Vector2 targetPos)
    {
        for(int i = 0; i < 15; i++)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, targetPos, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }
        rt.anchoredPosition = targetPos;
    }
}
