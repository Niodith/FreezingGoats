using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
   public AudioSource honkSound;

    // Start is called before the first frame update
    void Start()
    {
        honkSound = GetComponent<AudioSource>();
        honkSound.Play();
    }

    public void Honk(bool isHonking)
    {
        if (isHonking)
        {
            honkSound.Play();
        }

    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
