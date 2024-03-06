
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicBG;
    
    void Start()
    {
        musicBG = GetComponent<AudioSource>();
    }

}
