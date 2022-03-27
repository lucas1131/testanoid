using System;
using UnityEngine;

public interface IPlayerInputListener
{
    Action<Vector2> OnMovementDirectionChanged { get; set; }
}