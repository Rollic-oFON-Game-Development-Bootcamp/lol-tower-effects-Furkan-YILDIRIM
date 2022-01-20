using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFactory : MonoBehaviour
{
    [SerializeField] private Minion minionPrefab;

    private float minionSpawnCooldown => SettingsManager.GameSettings.MinionSpawnCooldown;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return SpawnRoutine();
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var minion = Instantiate(minionPrefab);
            minion.transform.position = transform.position;
            yield return new WaitForSeconds(minionSpawnCooldown);
        }
    }
}
