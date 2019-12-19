using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Parametreler
    [SerializeField] float unitSize = 16f;
    [SerializeField] float minX = 1.17f;
    [SerializeField] float maxX = 14.83f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInScreenUnits = Input.mousePosition.x / Screen.width * unitSize;  // mouse konumunu screen unit formatına çevirdi
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // paddle'ın yeni konumunu tanımladı
        paddlePos.x = Mathf.Clamp(mousePosInScreenUnits, minX, maxX); // paddle'ın x koordinatı üstündeki minimum ve maksimum gideceği noktaları sınırladı
        transform.position = paddlePos; // paddle'ın konumunu güncelledi
    }
}
