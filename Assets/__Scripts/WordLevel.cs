using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class WordLevel : MonoBehaviour {
    public int levelNum;
    public int longWordIndex;
    public string word;

    public Dictionary<char, int> charDict;
    public List<string> subWords;

    static public Dictionary<char, int> MakeCharDict(string w)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        char c;
        for(int i=0; i<w.Length; i++)
        {
            c = w[i];
            if(dict.ContainsKey(c))
            {
                dict[c]++;
            }//if
            else
            {
                dict.Add(c, 1);
            }//else
        }//for
        return (dict);
    }//static Dictionary

    public static bool CheckWordInLevel (string str, WordLevel level)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();
        for (int i=0; i<str.Length; i++)
        {
            char c = str[i];
            if (level.charDict.ContainsKey(c))
            {
                if (!counts.ContainsKey(c))
                {
                    counts.Add(c, 1);
                }//if
                else
                {
                    counts[c]++;
                }//else
                if (counts[c] > level.charDict[c])
                {
                    return (false);
                }//if
            }//if
            else
            {
                return (false);
            }//else

        }//for    
            return (true);
        
    }//static bool

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
