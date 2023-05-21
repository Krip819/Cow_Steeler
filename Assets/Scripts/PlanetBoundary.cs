using UnityEngine;
using System.Collections.Generic;

public class PlanetBoundary : MonoBehaviour
{
    public List<CowBehavior> cowBehaviors; // ссылка на поведения коров

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (CowBehavior cowBehavior in cowBehaviors)
        {
            if (other.gameObject == cowBehavior.gameObject)
            {
                cowBehavior.StopAbduction();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        foreach (CowBehavior cowBehavior in cowBehaviors)
        {
            if (other.gameObject == cowBehavior.gameObject)
            {
                cowBehavior.StartAbduction();
            }
        }
    }
}
