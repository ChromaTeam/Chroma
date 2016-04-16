using UnityEngine;
using System.Collections;

public class FallIntoPit : MonoBehaviour {

	public void OnPitTriggerEnter(Collider2D trigger)
	{
		if (trigger.CompareTag("Pit"))
		{
			RespawnZone RZScript = trigger.GetComponent<RespawnZone>();
			
			if(RZScript) {
				GameObject respawnZoneObject = RZScript.Zone;
				
				if(respawnZoneObject) {
					transform.position = respawnZoneObject.transform.position;
				}
				else
				{
					Debug.Log("No RespawnZone");
				}
			}
			else
			{
				Debug.Log("No RespawnZoneScript");
			}
		}
	}
}
