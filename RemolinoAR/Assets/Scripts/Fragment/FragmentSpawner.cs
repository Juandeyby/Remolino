using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSpawner : MonoBehaviour
{
    [SerializeField] private List<string> _fragmentIds;
    [SerializeField] private FragmentFactory _fragmentFactory;

    private FragmentTypeSelector _fragmentTypeSelector;

    private void Start()
    {
        _fragmentTypeSelector = new FragmentTypeSelector(_fragmentIds);
    }

    private void SpawnRandomEnemy()
    {
        var fragmentTypeToSpawn = _fragmentTypeSelector.Select();
        _fragmentFactory.Create(fragmentTypeToSpawn);
    }
}
