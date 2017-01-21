using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class param : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool useBuffer;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (useBuffer == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
    }
}
