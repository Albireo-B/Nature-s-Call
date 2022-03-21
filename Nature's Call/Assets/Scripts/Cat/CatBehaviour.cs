using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{

    private AudioSource catAudioSource;

    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {

        camera.SetReplacementShader(Shader.Find("CatVision"), "RenderType");

        catAudioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayMeow());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayMeow()
    {
        yield return new WaitForSeconds(3);

        catAudioSource.Play();

        StartCoroutine(PlayMeow());
    }
}
