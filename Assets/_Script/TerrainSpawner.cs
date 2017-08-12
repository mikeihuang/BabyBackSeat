using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainSpawner : MonoBehaviour {

	public Vector3 speed = new Vector3 (0f, 0f, -1f);

	//public Vector3 TreeSpawnBasePosition = new Vector3 ();
	public Vector2 TreeSpawnOffsetMinMax = new Vector2();

	public List<GameObject> TerrainPrefabs = new List<GameObject>();

	public List<GameObject> TerrainPool = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		InstantiatePrefabs ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTerrain ();	
	}

	void UpdateTerrain () {
		foreach (GameObject t in TerrainPool) {
			t.transform.position += speed * Time.deltaTime;
			if (t.transform.position.z < -750) {
				t.transform.position += Vector3.forward * 1000;
			}
		}
	}

	void InstantiatePrefabs() {
		Debug.Log ("InstantiatePrefabs()");
		Vector3 SpawnPosition = new Vector3 (0f, -1.5f, -500f);
		for (int i = 0; i < 20; i++) {
			foreach (GameObject prefab in TerrainPrefabs) {
				//Debug.Log ("Spawning a " + prefab.name);
				GameObject spawned = (GameObject)Instantiate (prefab, SpawnPosition, Quaternion.identity);
				float xoffset = Random.Range(TreeSpawnOffsetMinMax.x, TreeSpawnOffsetMinMax.y);
				if (Random.value > 0.5f)
					xoffset *= -1;
				spawned.transform.position += new Vector3(xoffset, 0, 0);
				spawned.transform.RotateAround (spawned.transform.position, Vector3.up, 90 * Mathf.Round (Random.Range (0, 3)));
				TerrainPool.Add (spawned);

				spawned.transform.parent = this.transform;

				SpawnPosition.z += Random.Range (5f, 15f);
			}
		}
	}
}
