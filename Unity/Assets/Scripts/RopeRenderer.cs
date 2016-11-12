using UnityEngine;

public class RopeRenderer : MonoBehaviour {

    private LineRenderer _renderer;
    public Transform[] targets;

	void Start ()
    {      
        _renderer = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        for (int i = 0; i < targets.Length - 1; i++)
        {
            _renderer.SetPosition(i, targets[i + 1].position);
        }

        //_renderer.SetPosition(0, transform.position);
        //_renderer.SetPosition(1, target.position);
	}
}