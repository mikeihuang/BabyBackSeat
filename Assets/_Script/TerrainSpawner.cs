using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TerrainSpawner : MonoBehaviour
{

    public Vector3 speed = new Vector3(0f, 0f, -1f);

    //public Vector3 TreeSpawnBasePosition = new Vector3 ();
    public Vector2 TreeSpawnOffsetMinMax = new Vector2();

    public List<GameObject> TerrainPrefabs = new List<GameObject>();

    public List<Transform> TerrainPool = new List<Transform>();

    public float GoalSpawnTimeRemaining = 50;
    public Vector3 GoalSpawnPosition;

    public Transform GoalPrefab;

    private bool spawnedGoal;

    // Use this for initialization
    void Start()
    {
        InstantiatePrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTerrain();
    }

    void UpdateTerrain()
    {

        if (GameStateManager.Instance.GameTime <= GoalSpawnTimeRemaining && !spawnedGoal)
        {
            Transform goal = Instantiate<Transform>(GoalPrefab);
            goal.position = GoalSpawnPosition;
            TerrainPool.Add(goal);
            spawnedGoal = true;
        }
        foreach (Transform t in TerrainPool)
        {
            t.position += speed * Time.deltaTime * (0.2f + 0.8f * GameStateManager.Instance.satActual);
            if (t.position.z < -750)
            {
                t.position += Vector3.forward * 1000;
                Exploder e = t.GetComponent<Exploder>();
                if (e)
                {
                    e.Reset();
                }
            }
        }
    }

    void InstantiatePrefabs()
    {
        Debug.Log("InstantiatePrefabs()");
        Vector3 SpawnPosition = new Vector3(0f, -1.5f, -500f);
        for (int i = 0; i < 20; i++)
        {
            foreach (GameObject prefab in TerrainPrefabs)
            {
                //Debug.Log ("Spawning a " + prefab.name);
                GameObject spawned = Instantiate<GameObject>(prefab, SpawnPosition, Quaternion.identity);
                Transform spawnedTransform = spawned.GetComponent<Transform>();
                float xoffset = Random.Range(TreeSpawnOffsetMinMax.x, TreeSpawnOffsetMinMax.y);
                if (Random.value > 0.5f)
                    xoffset *= -1;
                spawnedTransform.position += new Vector3(xoffset, 0, 0);
                spawnedTransform.RotateAround(spawnedTransform.position, Vector3.up, 90 * Mathf.Round(Random.Range(0, 3)));
                TerrainPool.Add(spawnedTransform);

                spawnedTransform.parent = this.transform;

                SpawnPosition.z += Random.Range(5f, 15f);
            }
        }
    }
}
