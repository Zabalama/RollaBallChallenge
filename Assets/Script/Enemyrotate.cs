using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyrotate : MonoBehaviour
{
      void Update()
    {
        transform.Rotate (new Vector3 (45, 30, 15) * Time.deltaTime);
    }
}
