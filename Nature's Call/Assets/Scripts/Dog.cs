using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public bool m_isRunning = false;
    public Animator m_animator;
    public bool m_isActive;
    public AudioSource m_audioSource;
    public GameObject m_filterView;


    // Start is called before the first frame update
    void Start()
    {
        m_isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            m_audioSource.Play();
        }
        
        if (m_isRunning)
        {
            m_animator.SetBool("isRunning", true);
        }
        else
        {
            m_animator.SetBool("isRunning", false);
        }

        if (m_isActive)
        {
            m_filterView.SetActive(true);
        }
        else
        {
            m_filterView.SetActive(false);
        }
    }
}
