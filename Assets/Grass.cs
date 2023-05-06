using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Terrain
{
    [SerializeField] List<GameObject> treePrefabList;
    [SerializeField, Range(0,1)] float treeProbability;

    public void SetTreePercentange(float newProbability)
    {
        this.treeProbability = Mathf.Clamp01(newProbability);
    }

    public override void Generate(int size)
    {
        base.Generate(size);

        var limit = Mathf.FloorToInt((float) size / 2);
        var treeCount = Mathf.FloorToInt((float) size * treeProbability);

        //membuat daftar posisi yang kosong
        List<int> emptyPosition = new List<int>();
        for (int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(i);
        }

        for (int i = 0; i < treeCount; i++)
        {
            // mengambil posisi random dari daftar posisi yang kosong
            var randomIndex = Random.Range(0, emptyPosition.Count);
            var pos = emptyPosition[randomIndex];
            
            // menghapus posisi yang sudah dipakai
            emptyPosition.RemoveAt(randomIndex);

            SpawnRandomTree(pos);
        }

        // selalu spawn tree di ujung
        SpawnRandomTree(-limit - 1);
        SpawnRandomTree(limit + 1);
    }

    private void SpawnRandomTree(int xPos)
    {
        // pilih prefab tree secara random
        var randomIndex = Random.Range(0, treePrefabList.Count);
        var prefab = treePrefabList[randomIndex];

        // set tree di posisi yang sudah dipilih
        var tree = Instantiate(
            prefab, 
            new Vector3(xPos, 0, this.transform.position.z),
            Quaternion.identity,
            transform
        );
    }
}
