using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BezierCurves : MonoBehaviour
{
    GameObject StartPos;
    GameObject P1;
    GameObject P2;
    GameObject EndPos;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = new GameObject();
        P2 = new GameObject();
        P1 = new GameObject();
        EndPos= GameObject.Find("EndPos");
        StartPos.transform.position = new Vector3(transform.position.x, transform.position.y);
        P1.transform.position -= StartPos.transform.right * 3;
        P2.transform.position = new Vector3(P1.transform.position.x, EndPos.transform.position.y);
    }

    Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return (1f - t) * a + t * b;
    }

    Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = Lerp(p0, p1, t);
        Vector3 b = Lerp(p1, p2, t);
        Vector3 c = Lerp(p2, p3, t);
        Vector3 d = Lerp(a, b, t);
        Vector3 e = Lerp(b, c, t);
        Vector3 pointOnCurve = Lerp(d, e, t);

        return pointOnCurve;
    }
    // Update is called once per frame
    void Update()
    {
            t += Time.deltaTime*2f;
            transform.position = GetPointOnBezierCurve(StartPos.transform.position, P1.transform.position, P2.transform.position, EndPos.transform.position, t);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "EndPos")
        {
            Destroy(P1);
            Destroy(P2);
            Destroy(StartPos);
            Destroy(gameObject);
        }
    }

}
