using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class param : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool useBuffer;
	public bool planet;
	public Color lerpedColor = Color.white;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
	{
		if (useBuffer == true) {
			lerpedColor = Color.Lerp(Color.blue, Color.red, Mathf.PingPong(Time.time, 1));
			Renderer rend = GetComponent<Renderer>();
			rend.material.shader = Shader.Find("Standard");
			rend.material.SetColor("_EmissionColor", lerpedColor);
			transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._bandBuffer [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (transform.localScale.x, (AudioPeer._freqBand [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
		}

		if (planet == true) {
			transform.localScale = new Vector3 ((AudioPeer._bandBuffer [_band] * _scaleMultiplier) + _startScale, 
				(AudioPeer._bandBuffer [_band] * _scaleMultiplier) + _startScale,
				(AudioPeer._bandBuffer [_band] * _scaleMultiplier) + _startScale);
		}
	}
}
