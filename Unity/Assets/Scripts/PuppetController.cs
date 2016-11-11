using UnityEngine;
using System.Collections;

public class PuppetController : MonoBehaviour {

    public float rotationSpeed = 1;

    public InputRecoder input;

    public enum Axis {X, Y };

    [System.Serializable]
    public class PuppetString
    {
        public Transform handle;
        public float scale = 1;
        public Axis axis = Axis.X;
        public bool positive = true;
        public Vector3 location;
        public Vector3 direction = Vector3.up;
        public Vector3 influence = Vector3.zero;
        public AudioSource audio;
        public Vector3 angle;
    }

    public PuppetString[] strings;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = CircleToSquare(input.axis, 0.5f);
        foreach (PuppetString str in strings)
        {
            float value = str.axis == Axis.X ? dir.x : dir.y;
            bool isActivated = str.positive ? value > 0 : value < 0;
            float influenceValue = str.axis == Axis.X ? dir.y : dir.x;
            str.handle.localPosition = str.location + (isActivated ? Mathf.Abs(value) * str.scale * str.direction.normalized + influenceValue * str.influence : Vector3.zero);
            str.audio.volume = isActivated ? Mathf.Abs(value) : 0;
        }
    }

    static Vector2 CircleToSquare(Vector2 point)
    {
        return CircleToSquare(point, 0);
    }
    static Vector2 CircleToSquare(Vector2 point, float innerRoundness)
    {
        const float PiOverFour = Mathf.PI / 4;

        // Determine the theta angle
        float angle = Mathf.Atan2(point.y, point.x) + Mathf.PI;

        Vector2 squared = point;
        // Scale according to which wall we're clamping to
        // X+ wall
        if (angle <= PiOverFour || angle > 7 * PiOverFour)
        {

            squared = point * (float)(1 / Mathf.Cos(angle));
        }
        // Y+ wall
        else if (angle > PiOverFour && angle <= 3 * PiOverFour)
        {
            squared = point * (float)(1 / Mathf.Sin(angle));
        }
        // X- wall
        else if (angle > 3 * PiOverFour && angle <= 5 * PiOverFour)
        {
            squared = point * (float)(-1 / Mathf.Cos(angle));
        }
        // Y- wall
        else if (angle > 5 * PiOverFour && angle <= 7 * PiOverFour)
        {
            squared = point * (float)(-1 / Mathf.Sin(angle));
        }

        // Early-out for a perfect square output
        if (innerRoundness == 0)
            return squared;

        // Find the inner-roundness scaling factor and LERP
        var length = point.magnitude;
        var factor = (float)Mathf.Pow(length, innerRoundness);
        return Vector2.Lerp(point, squared, factor);
    }
}
