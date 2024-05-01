using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    private void Start() {
        Destroy(gameObject, _delay);
    }
}
