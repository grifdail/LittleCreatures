using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputRecoder : MonoBehaviour {

    public class InputState
    {
        public Vector2 axis;
        public float time;

        public InputState(Vector2 axis,float time)
        {
            this.axis = axis;
            this.time = time;
        }
    }

    public Vector2 axis;
    public List<InputState> record;

    public IEnumerator currentlyDoing;

	// Use this for initialization
	void Start () {
	   
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (currentlyDoing == null)
        {
            axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        };
    }

    public void Play(List<InputState> record = null)
    {
        if (record == null)
        {
            record = this.record;
        }
        StopCurrentCoroutine();
        currentlyDoing = PlayCoroutine(record);
        StartCoroutine(currentlyDoing);
        
    }

    public void PlayLoop(List<InputState> record = null)
    {
        if (record == null)
        {
            record = this.record;
        }
        StopCurrentCoroutine();
        currentlyDoing = PlayLoopCoroutine(record);
        StartCoroutine(currentlyDoing);

    }

    void StopCurrentCoroutine()
    {
        if (currentlyDoing != null)
        {
            StopCoroutine(currentlyDoing);
            currentlyDoing = null;
        }
    }

    public void Record()
    {
        StopCurrentCoroutine();
        currentlyDoing = RecordCoroutine();
        StartCoroutine(currentlyDoing);
    }

    public void Force(Vector2 axis)
    {
        StopCurrentCoroutine();
        currentlyDoing = ForceCoroutine(axis);
        StartCoroutine(currentlyDoing);
    }

    public List<InputState> Stop()
    {
        StopCurrentCoroutine();
        return record;
    }
         
    IEnumerator RecordCoroutine ()
    {
        record = new List<InputState>();
        float time = 0;
        while (true)
        {
            time += Time.deltaTime;
            axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            record.Add(new InputState(axis, time));
            yield return true;
        }
    }
    IEnumerator ForceCoroutine(Vector2 axis)
    {
        while(true)
        {
            this.axis = axis;
            yield return true;
        }
    }
    

    IEnumerator PlayCoroutine(List<InputState> record)
    {
        foreach(InputState state in record)
        {
            axis = state.axis;
            yield return true;
        }
        currentlyDoing = null;
    }
    IEnumerator PlayLoopCoroutine(List<InputState> record)
    {
        while (true)
        {
            yield return PlayCoroutine(record);
        }
    }
}
