using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundwin : MonoBehaviour
{
    
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.playOnAwake = false;

        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        videoPlayer.aspectRatio = UnityEngine.Video.VideoAspectRatio.Stretch;

        videoPlayer.targetCameraAlpha = 0.5F;

        videoPlayer.url = "Assets/Resources/Media/Images/winscreen.mp4"; 

        videoPlayer.frame = 100;

        videoPlayer.isLooping = true;

        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 2.0F;
    }

}
