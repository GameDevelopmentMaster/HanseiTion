using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    Vector3 firstPos;
    
    public Sprite[] sprite = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {

        firstPos = transform.position;
        StartCoroutine(iPopUP());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetUp(int v,Vector2 pos)
    {
        GetComponent<SpriteRenderer>().sprite = sprite[v];
        transform.position = pos;
    }
    IEnumerator iPopUP()
    {
        for(int i = 0; i < 15; i++)
        {
            transform.position = Vector3.Lerp(transform.position, firstPos + Vector3.up,0.5f);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = firstPos + Vector3.up;
        while (transform.localScale.x >= 0.1f)
        {
            transform.localScale -= Vector3.one * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
