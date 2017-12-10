using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour {

    public AudioClip storyClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            if (storyClip != null)
            {
                AudioSource source = GetComponent<AudioSource>();
                source.PlayOneShot(storyClip);
            }
        }
    }
}
