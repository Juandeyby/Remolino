using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentFactory : MonoBehaviour
{
    [SerializeField] private Fragment[] _fragments;
    private Dictionary<string, Fragment> _idToFragments = new Dictionary<string, Fragment>();

    private void Awake()
    {
        foreach (var fragment in _fragments)
        {
            _idToFragments.Add(fragment.id, fragment);
        }
    }

    public Fragment Create(string fragmentId, Transform parent)
    {
        if (!_idToFragments.TryGetValue(fragmentId, out var fragmentToSpawn))
        {
            throw new ArgumentOutOfRangeException();
        }
        return Instantiate(fragmentToSpawn, parent);
    }
}
