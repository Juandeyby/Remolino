using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentTypeSelector
{
    private List<string> fragmentIds;

    public FragmentTypeSelector(List<string> fragmentIds)
    {
        this.fragmentIds = fragmentIds;
    }

    public string Select()
    {
        var randomTypeIndex = Random.Range(0, fragmentIds.Count);
        return fragmentIds[randomTypeIndex];
    }
}
