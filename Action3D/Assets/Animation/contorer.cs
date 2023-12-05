using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class contorer : MonoBehaviour
{
    Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
