using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StoryTrigger : MonoBehaviour {

    public AudioClip storyClip;

    bool canPlay = true;

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
                AudioSource source = GetComponentInParent<AudioSource>();
                if (source != null)
                {
                    source.PlayOneShot(storyClip);
                    canPlay = false;
                    Invoke("EnableAgain", storyClip.length);
                }

                PlayableDirector dir = GetComponentInParent<PlayableDirector>();
                if (dir != null)
                {
                    dir.Play();
                }
            }
        }
    }

    public void EnableAgain()
    {
        canPlay = true;

        PlayableDirector dir = GetComponentInParent<PlayableDirector>();
        if (dir != null)
        {
            dir.Stop();
        }
    }
}
