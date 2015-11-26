using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    public Transform m_paddleAnchor;    // The anchor represents a relative origin for the paddle in the world. If it set, the max distance applies relative to the paddleAnchor's position
    public float m_maxDistance;         // The max distance represents how far the paddle can move from its relative origin
    public float m_speed;               // The speed at which the paddle moves

    // Private variables
    bool m_thinMode;    // When this is true, the paddle is rotated to present its thin side
    bool m_enableInput; // When this is true, the player can move the paddle.
    GameObject m_ball;  // Reference to the ball. When the ball is created for the first time, it is placed on the Paddle, inactive. When the player activates it, the ball is launched.

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
	    
	}

    /// <summary>
    /// Update is called once per frame. Player movement is updated here
    /// </summary>
    void Update ()
    {
        if (m_enableInput)
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

            // Setting the new ball position
            this.transform.position = newPos;

            // Launching the ball
            // If the ball reference is set
            if (m_ball != null)
            {
                m_ball.GetComponent<Ball>().setForce(new Vector3(1, 1, 0)); // Launching the ball
                m_ball.gameObject.transform.SetParent(null);                // Freeing the ball from the paddle
                m_ball = null;
            }
        }
    }

    public void setEnableInput(bool enableInput)
    {
        this.m_enableInput = enableInput;
    }

    /*	-----
		Return :
		Parameters : 
            - Gameobject ball : an inactive Ball prefab
		Function behavior : places the ball on the paddle as a child object
	*/
    public void setBall(GameObject ball)
    {
        m_ball = ball;
        m_ball.transform.SetParent(this.transform);
        m_ball.transform.position = new Vector3(0.5f, 0.5f, 0);
        //TODO: set ball inactive
    }
}
