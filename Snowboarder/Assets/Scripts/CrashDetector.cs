using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float ReloadSceneDelay = 0;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = true;
            //GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", ReloadSceneDelay);

        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
