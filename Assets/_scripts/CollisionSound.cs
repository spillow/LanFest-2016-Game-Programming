using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour
{
    public string otherTag;
    public AudioClip m_ClipToPlay;
    private AudioSource m_AudioSource;

    // Use this for initialization
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == otherTag)
        {
            m_AudioSource.clip = m_ClipToPlay;
            m_AudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
