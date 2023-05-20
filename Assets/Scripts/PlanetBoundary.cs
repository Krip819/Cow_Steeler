using UnityEngine;

public class PlanetBoundary : MonoBehaviour
{
    public CowBehavior cowBehavior; // ссылка на поведение коровы

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == cowBehavior.gameObject)
        {
            cowBehavior.StopAbduction();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == cowBehavior.gameObject)
        {
            cowBehavior.StartAbduction();
        }
    }
}
