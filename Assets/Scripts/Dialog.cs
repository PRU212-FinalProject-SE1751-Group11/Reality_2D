using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] string name;
    [SerializeField] List<string> lines;
    [SerializeField] DialogCondition condition;

    public List<string> Lines => lines;
    public string Name => name;
    public DialogCondition Condition => condition;
}
