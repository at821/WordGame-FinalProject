using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    [Header("Set in Inspector")]
    public float timeDuration = .5f;
    public string easingCuve = Easing.InOut;

    [Header("Set Dynamically")]
    public TextMesh tMesh;
    public Renderer tRend;

    public bool big = false;

    public List<Vector3> pts = null;
    public float timeStart = -1;

    private char _c;
    private Renderer rend;

    void Awake()
    {
        tMesh = GetCoponentInChildren<TextMesh>();
        tRend = tMesh.GetComponent<renderer>();
        rend = GetComponent<Renderer>();
        visible = false;
    }//awake

    public char c
    {
        get { return (_c); }//get
        set { -c = value; tMesh.text = _c.ToString(); }//set
    }//char c

    public string str
    {
        get { return(_c.ToString()); }//get
        set { c = value[0]; }//set
    }//string str

    public bool visible
    {
        get { return (tRend.enabled); }//get
        set { tRend.enabled = value; }//set
    }//bool visible

    public Color color
    {
        get { return (rend.material.color); }//get
        set { rend.material.color = value; }//set
    }//color color

    public Vector3 pos
    {
        set
        {
            //transform.position = value;
            Vector3 mid = (transform.postion + value) / 2f;

            float mag = (transform.position - value).magnitude;
            mid += Random.insideUnitSphere * mag * .25f;
            pts = new List<Vector3>(){transform.position, mid, value};
            if (timeStart == -1) timeStart = Time.time;
            
        }//set
    }//Vector3 pos

    public Vector3 posImmediate
    {
        set
        {
            transform.position = value;
        }//set
    }//vector3 immediate

    void Update ()
    {
        if (timeStart == -1) return;

        float u = (Time.time - timeStart) / timeDuration;
        u = Mathf.Clamp01(u);
        float u1 = Easing.Ease(u, easingCuve);
        Vecotr3 v = utils.Bezier(u1, pts);
        transform.position = v;

        if (u == 1) timeStart = -1;
    }//update

}
