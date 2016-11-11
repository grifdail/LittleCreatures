using UnityEngine;
using System.Collections;

public class PuppetController : MonoBehaviour {

    public float rotationSpeed = 1;

    public Transform forward;
    public Transform left;
    public Transform right;
    public Transform back;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = CircleToSquare(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 0.5f);
        forward.localPosition = new Vector3(0, dir.y > 0 ? 0 : -dir.y, 2);
        left.localPosition = new Vector3(-2, dir.x > 0 ? 0 : -dir.x, 0);
        right.localPosition = new Vector3(2, dir.x < 0 ? 0 : dir.x, 0);
        back.localPosition = new Vector3(0, dir.y < 0 ? 0 : dir.y, -2);
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
