using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveParts : MonoBehaviour
{
    public List<RepairDetails> partIDNeeded;
    public bool repaired;
    Highlightable highlight;
    private void Start()
    {
        TryGetComponent(out highlight);
        if(repaired)
        {
            SetRepaired();
        }

        int length = partIDNeeded.Count;
        for (int i = 0; i < length; i++)
        {
            if(partIDNeeded[i].isRepaired)
            {
                RecivePart(partIDNeeded[i].partId);
            }
        }

    }

    public bool RecivePart(int id)
    {
        bool didRepair = false;
        bool totallyRepaired = true;
        if (!repaired)
        {
            int length = partIDNeeded.Count;

            for (int i = 0; i < length; i++)
            {
                if (partIDNeeded[i].partId == id)
                {
                    RepairDetails details= partIDNeeded[i];
                    details.isRepaired=true;
                    details.part.Repaired(true);
                    didRepair = true;
                    partIDNeeded[i] = details;
                }

                if(!partIDNeeded[i].isRepaired)
                {
                    totallyRepaired = false;
                }
            }
        }
        if(totallyRepaired)
        {
            repaired = true;
        }
       

        return didRepair;
    }

    public void SetRepaired()
    {
        int length = partIDNeeded.Count;

        for (int i = 0; i < length; i++)
        {
            RepairDetails details = partIDNeeded[i];
            details.isRepaired = true;
            details.part.Repaired(true);
            partIDNeeded[i] = details;
        }
        repaired = true;
        }
}
[Serializable]
public struct RepairDetails
{
    public int partId;
    public bool isRepaired;
    public BrokenSubpartObj part;



}
