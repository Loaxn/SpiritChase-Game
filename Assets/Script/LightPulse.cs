using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    private Light spotLight;
    public float minIntensity = 1f;
    public float maxIntensity = 3f;
    public float speed = 2f;

    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    void Update()
    {
        spotLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * speed, 1));
    }
}