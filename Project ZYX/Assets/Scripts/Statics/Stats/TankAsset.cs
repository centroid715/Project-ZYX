using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Type", menuName = "ZYX Assets/Tank Type/Standard")]
public class TankAsset : ScriptableObject
{
    public string     Name      = "TANK NAME";
    public GameObject Model     = null;
    [Space(10)]
    public float Damage      = 1f;
    public float FireRate    = 0.6f;
    public float Health      = 100f;
    public float Speed       = 5f;
    public float AccelerationForce = 3;
    public float DecelerationForce = 1;
    public float RotationForce = 100;
    [Space(5)]
    public float ShakeAmplitude = 12f;
    public float ShakeFrequency = 5f;
    public float ShakeDuration  = 1f;
    [Space(5)]
    public float ChargeRate     = 0.75f;
    public float MinCharge      = 0.3f;
    public float MaxCharge      = 1f;
    [Space(10)]
    public float StartupToIdleDelay = 1.16f;
    public AudioEvent AudioIdle     = null;
    public AudioEvent AudioStartup  = null;
    public AudioEvent AudioThrottle = null;
    public AudioEvent AudioRevLow = null;
    public AudioEvent AudioRevMid = null;
    public AudioEvent AudioRevHigh = null;
    public AudioEvent ChargeAbility = null;
    [Space(10)]
    public FireEventSingleMulti FireChargeAbility;
}
