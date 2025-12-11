using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PickupEffects _effect;

    private void Awake()
    {
        _effect = GetComponent<PickupEffects>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Tags.Player)) return;

        if (_effect != null)
        {
            _effect.OnPick(other.gameObject);
        }

        Destroy(gameObject);
    }
}
