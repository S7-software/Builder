using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollapse : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagsOfGO.PlayerCube.ToString()))
        {

            GameManager.instantiate.Finish();
        }
    }
}
