using System;
using UnityEngine;

public interface IBallCollisionListener
{
	Action<Collision2D> OnCollisionWithBrick { get; set; }
	Action<Collision2D> OnCollisionWithDeathplane { get; set; }
}