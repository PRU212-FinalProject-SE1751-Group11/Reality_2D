using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScene : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        if (anim != null)
        {
            anim.SetTrigger("caution");
        }
    }
}
