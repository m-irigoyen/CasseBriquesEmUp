using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	public Vector3 m_initPosition;
	public float m_initWidth;
	public float m_initHeight;

	private GameObject m_lowerBoundary;
	private GameObject m_rightBoundary;
	private GameObject m_upperBoundary;

	private GameObject m_leftBoundary;

	void Start() {
		init (m_initPosition, m_initWidth, m_initHeight);
	}

	void init(Vector3 p_leftCenterPoint, float p_width, float p_height) {
		m_lowerBoundary = GameObject.CreatePrimitive (PrimitiveType.Cube);
		m_lowerBoundary.transform.position = new Vector3 (p_leftCenterPoint.x + p_width/2, p_leftCenterPoint.y - p_height - 0.5f, p_leftCenterPoint.z);
		m_lowerBoundary.transform.localScale = new Vector3 (p_width, 1, 1);
		m_lowerBoundary.transform.SetParent (this.transform);

		m_rightBoundary = GameObject.CreatePrimitive (PrimitiveType.Cube);
		m_rightBoundary.transform.SetParent (this.transform);
		m_rightBoundary.transform.position = new Vector3 (p_leftCenterPoint.x + p_width + 0.5f, p_leftCenterPoint.y, p_leftCenterPoint.z);
		m_rightBoundary.transform.localScale = new Vector3 (1, p_height*2, 1);

		m_upperBoundary = GameObject.CreatePrimitive (PrimitiveType.Cube);
		m_upperBoundary.transform.SetParent (this.transform);
		m_upperBoundary.transform.position = new Vector3 (p_leftCenterPoint.x + p_width/2, p_leftCenterPoint.y + p_height + 0.5f, p_leftCenterPoint.z);
		m_upperBoundary.transform.localScale = new Vector3 (p_width, 1, 1);
	}
}
