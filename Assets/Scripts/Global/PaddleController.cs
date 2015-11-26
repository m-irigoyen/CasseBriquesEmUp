using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    public Transform m_paddleAnchor;    // The anchor represents a relative origin for the paddle in the world. If it set, the max distance applies relative to the paddleAnchor's position
    public float m_maxDistance;         // The max distance represents how far the paddle can move from its relative origin
    public float m_speed;               // The speed at which the paddle moves

	public float m_boundAngle;			// The max rebound angle of the ball at the extremity of the paddle 
	public float m_paddleHeight;
	public float m_paddleWidth;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Compute new position for the ball
        Vector3 newPos = new Vector3(0, this.transform.position.y + Input.GetAxis("Vertical") * m_speed * Time.deltaTime, 0);

        // If paddleAnchor is set, check boundaries relative to it
        if (m_paddleAnchor != null)
        {
            if (newPos.y > (m_paddleAnchor.position.y + m_maxDistance))
                newPos.y = m_maxDistance;
            else if (newPos.y < (m_paddleAnchor.position.y - m_maxDistance))
                newPos.y = -m_maxDistance;
        }
        // If it isn't set, just check relative to origin
        else
        {
            if (newPos.y > m_maxDistance)
                newPos.y = m_maxDistance;
            else if (newPos.y < -m_maxDistance)
                newPos.y = -m_maxDistance;
        }

        this.transform.position = newPos;

        //TODO: Manage collisions with the ball
    }

	void OnCollisionEnter (Collision collider)
	{
		if (collider.gameObject.tag == Tags.m_ball) {

			float paddleWidth=this.transform.lossyScale.y;	//TODO: find better code for that
			float ballPosition=this.transform.position.y - collider.gameObject.transform.position.y;	//The difference between the paddle and the ball vertical coordinates, ie the relative distance between the ball collision point and the center of the paddle surface

			float exitAngle=m_boundAngle*2*ballPosition/paddleWidth;									//The exit angle of the ball
			Vector3 exitVector=new Vector3(Mathf.Cos (exitAngle), Mathf.Sin (exitAngle), 0);			

			collider.gameObject.GetComponent<Ball>().setForce(exitVector);
		
		}
	}


}
