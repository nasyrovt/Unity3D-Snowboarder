using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float ReloadSceneDelay = 0;
    [SerializeField] ParticleSystem FinishEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", ReloadSceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
