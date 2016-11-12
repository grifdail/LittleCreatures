using UnityEngine;
using System.Collections;

public class AlignItemLink : MonoBehaviour {

    Transform _target;
    Rigidbody _rb;
    Transform _model;

	// Use this for initialization
	void Start () {
        _target = GetComponent<Joint>().connectedBody.transform;
        _rb = GetComponent<Rigidbody>();
        _model = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        _model.rotation = Quaternion.LookRotation(_target.position - transform.position);
	}
}
