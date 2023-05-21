using UnityEngine;
using VLB;
using System.Collections.Generic;  // Для работы со списками

public class UFOBeam : MonoBehaviour
{
    public List<Rigidbody2D> cowsRigidbodies;  // список Rigidbody2D коров
    public VolumetricLightBeamSD beamLight;  // компонент Volumetric Light Beam
    public GameObject ufoShip;  // объект корабля пришельца
    public float pullStrength = 10f;  // сила притяжения

    void Update()
    {
        if (Input.GetMouseButton(0))  // если нажата левая кнопка мыши (или экран телефона)
        {
            beamLight.enabled = true;  // включаем луч
            
            // применяем притяжение ко всем коровам в списке
            foreach (Rigidbody2D cowRigidbody in cowsRigidbodies)
            {
                Vector2 direction = (new Vector2(ufoShip.transform.position.x, ufoShip.transform.position.y) - cowRigidbody.position).normalized;  // направление от UFO к корове
                cowRigidbody.AddForce(direction * pullStrength);  // притягиваем корову к UFO
            }
        }
        else
        {
            beamLight.enabled = false;  // выключаем луч
        }
    }
}
