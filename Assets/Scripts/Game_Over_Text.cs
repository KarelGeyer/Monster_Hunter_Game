using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_Text : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Animate", true);
        Invoke("StopAnimation", 1);
        print(anim);
    }

    void StopAnimation()
    {
        anim.SetBool("Animate", false);
    }
}
