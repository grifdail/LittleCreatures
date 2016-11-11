using UnityEngine;
using System.Collections;

public class RopeRenderer : MonoBehaviour {

    private LineRenderer _renderer;
    public Transform target;

	// Use this for initialization
	void Start () {
        if (target == null)
        {
            target = GetComponent<Joint>().connectedBody.transform;
        }
        
        _renderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        _renderer.SetPosition(0, transform.position);
        _renderer.SetPosition(1, target.position);
	}
}
