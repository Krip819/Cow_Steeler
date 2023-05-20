using UnityEngine;
using VLB;

public class UFOBeam : MonoBehaviour
{
    public Rigidbody2D cowRigidbody;  // Rigidbody2D коровы
    public VolumetricLightBeamSD beamLight;  // компонент Volumetric Light Beam
    public GameObject ufoShip;  // объект корабля пришельца
    public float pullStrength = 10f;  // сила притяжения

    void Update()
    {
        if (Input.GetMouseButton(0))  // если нажата левая кнопка мыши (или экран телефона)
        {
            beamLight.enabled = true;  // включаем луч
            Vector2 direction = (new Vector2(ufoShip.transform.position.x, ufoShip.transform.position.y) - cowRigidbody.position).normalized;  // направление от UFO к корове
            cowRigidbody.AddForce(direction * pullStrength);  // притягиваем корову к UFO
        }
        else
        {
            beamLight.enabled = false;  // выключаем луч
        }
    }
}
