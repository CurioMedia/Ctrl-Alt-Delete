using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer vP; 
    public UnityEngine.Video.VideoClip[] videoClips = new UnityEngine.Video.VideoClip[0];
    int ClipCount = 0;

    void start()
    {
        var vP = this.GetComponent<UnityEngine.Video.VideoPlayer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.buttClick == true)
        {
            GameManager.Instance.buttClick=false;
            PlayVideo(ClipCount);
            if(ClipCount<(videoClips.Length-1)){ClipCount++;}
            else ClipCount = 0;
            

        }
    }

    public void PlayVideo(int id)
    {
        var vP = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        // To be safe, let's bounds-check the ID 
        // and throw a descriptive error to catch bugs.
        if(id < 0 || id >= videoClips.Length) 
        {
            Debug.LogErrorFormat(
               "Cannot play video #{0}. The array contains {1} video(s)",
                                   id,                 videoClips.Length);
            return;
        }
    // If we get here, we know the ID is safe.
        // So we assign the (id+1)th entry of the vids array as our clip.
        vP.clip = videoClips[id];

        vP.Play();
    }
}
