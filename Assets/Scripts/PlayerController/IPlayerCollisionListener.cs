using System;
using UnityEngine;

public interface IPlayerCollisionListener
{
    Action<Collision2D> OnPlayerCollisionEnter { get; set; }
}