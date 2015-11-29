using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
		public float delayTime;
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
		public static int spwanMaxCount = 100;

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            //InvokeRepeating ("Spawn", spawnTime, spawnTime);
			delayTime = Random.Range (1, 10);
			//InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }

		void Update() 
		{

			if (delayTime <= 0) {
				Invoke("Spawn", 0);
				delayTime = Random.Range (3, 15);
				return;
			}

			delayTime -= Time.deltaTime;
		}

        void Spawn ()
        {
            // If the player has no health left...
            //if(playerHealth.currentHealth <= 0f)
            //{
                // ... exit the function.
            //    return;
            //}

			if (spwanMaxCount <= 0)
				return;

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Vector3 randomPos = Vector3.zero;
			randomPos.x = Random.Range (-5, 5);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (enemy, spawnPoints[spawnPointIndex].position + randomPos, spawnPoints[spawnPointIndex].rotation);
			--spwanMaxCount;
        }
    }
}