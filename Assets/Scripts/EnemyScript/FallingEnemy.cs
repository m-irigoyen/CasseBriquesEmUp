using UnityEngine;
using System.Collections;

public class FallingEnemy : CommonEnemy {

	void Update()
	{

		if (m_healthPoints <= 1) {
			m_speed = 2;
		}


		if (m_healthPoints <= 0) {
			//Call GameMode and give the amount of points earned by destroying the enemy
			Destroy (gameObject);
		}

}
}