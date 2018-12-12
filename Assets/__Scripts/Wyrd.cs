using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wyrd {

    public string str;
    public List<Letter> letters = new List<Letter>();
    public bool found = false;

    public bool visible
    {
        get
        {
            if (letters.Count == 0) return (false);
            return (letters[0].visible);
        }//get
        set
        {
            foreach (Letter l in letters) {
                l.visible = value;
            }//foreach
        }//set
    }//bool visible

    public Color color
    {
        get
        {
            if (letters.Count == 0) return (Color.black);
            return (letters[0].color);
        }//get
        set
        {
            foreach (letter l in letters)
            {
                l.color = value;
            }//foreach
        }//set
    }//color color

    public void Add(Letter l)
    {
        letters.Add(l);
        str += l.c.ToString();
    }//Add



}//class
