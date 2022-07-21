using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private Dictionary<string, bool> dictionary;

    void Start()
    {
        dictionary = new Dictionary<string, bool>();
        dictionary.Add("grounded", false);
        dictionary.Add("charging", false);
    }
    public bool GetValue(string name) { return dictionary[name]; }

    public void SetValue(string name, bool value)
    {
        dictionary[name] = value;
    }
}
