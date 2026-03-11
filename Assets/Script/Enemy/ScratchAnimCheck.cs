using System.Xml.Serialization;
using UnityEngine;

public class ScratchAnimCheck : MonoBehaviour
{
    EnemyAI eAI;

    private void Awake()
    {
        eAI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (eAI != null)
        {

        }
    }
}
