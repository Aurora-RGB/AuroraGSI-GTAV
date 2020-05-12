using GTA;
using System;

namespace AuroraGSI_GTAV
{
    public class GSINode
    {
        public readonly ProviderNode Provider = new ProviderNode();
        public readonly PlayerNode Player = new PlayerNode();
        public readonly GameNode Game = new GameNode();
        public readonly VehicleNode LastVehicle = new VehicleNode();
        public readonly WeaponNode CurrentWeapon = new WeaponNode();
    }

    public class ProviderNode
    {
        public readonly string name = "gtav";
        public readonly int appid = 271590;
    }

    public class PlayerNode
    {
        public bool CanControlCharacter;
        public bool CanStartMission;
        public bool IsAiming;
        public bool IsAlive;
        public bool IsClimbing;
        public bool IsDead;
        public bool IsInvincible;
        public bool IsPlaying;
        public bool IsPressingHorn;
        public bool IsRidingTrain;
        public bool IsSpecialAbilityActive;
        public bool IsSpecialAbilityEnabled;
        public bool IsTargetingAnything;
        public float RemainingSprintStamina;
        public float RemainingSprintTime;
        public float RemainingUnderwaterTime;
        public int MaxArmor;
        public int Money;
        public int WantedLevel;
        public string Name;
    }

    public class GameNode
    {
        public bool IsNightVisionActive;
        public bool IsThermalVisionActive;
        public bool IsMissionActive;
        public bool IsRandomEventActive;
        public bool IsCutsceneActive;
        public bool IsWaypointActive;
        public bool IsPaused;
        public RadioStation RadioStation;
        public bool IsLoading;
    }

    public class VehicleNode
    {
        public bool AreHighBeamsOn;
        public bool AreLightsOn;
        public bool CanTiresBurst;
        public bool CanWheelsBreak;
        public bool HasSiren;
        public bool IsAlarmSet;
        public bool IsAlarmSounding;
        public bool IsConvertible;
        public bool IsDamaged;
        public bool IsDriveable;
        public bool IsEngineRunning;
        public bool IsFrontBumperBrokenOff;
        public bool IsInBurnout;
        public bool IsInteriorLightOn;
        public bool IsLeftHeadLightBroken;
        public bool IsOnAllWheels;
        public bool IsRearBumperBrokenOff;
        public bool IsRightHeadLightBroken;
        public bool IsSearchLightOn;
        public bool IsSirenActive;
        public bool IsStolen;
        public bool IsStopped;
        public bool IsStoppedAtTrafficLights;
        public bool IsTaxiLightOn;
        public bool IsWanted;
        public bool NeedsToBeHotwired;
        public bool ProvidesCover;
        public float Acceleration;
        public float BodyHealth;
        public float BrakePower;
        public float Clutch;
        public float CurrentRPM;
        public float DirtLevel;
        public float EngineHealth;
        public float EnginePowerMultiplier;
        public float EngineTemperature;
        public float FuelLevel;
        public float HeliBladesSpeed;
        public float HeliEngineHealth;
        public float HeliMainRotorHealth;
        public float HeliTailRotorHealth;
        public float LightsMultiplier;
        public float LodMultiplier;
        public float MaxBraking;
        public float MaxTraction;
        public float OilLevel;
        public float OilVolume;
        public float PetrolTankHealth;
        public float PetrolTankVolume;
        public float SteeringAngle;
        public float SteeringScale;
        public float Throttle;
        public float ThrottlePower;
        public float Turbo;
        public float WheelSpeed;
        public int AlarmTimeLeft;
        public int CurrentGear;
        public int Gears;
        public int HighGear;
        public int NextGear;
        public int PassengerCapacity;
        public int PassengerCount;
        public RadioStation RadioStation;
        public string ClassDisplayName;
        public string ClassLocalizedName;
        public string DisplayName;
        public string LocalizedName;
        public VehicleClass ClassType;
    }

    public class WeaponNode
    {
        public bool CanUseOnParachute;
        public bool IsPresent;
        public int Ammo;
        public int AmmoInClip;
        public int DefaultClipSize;
        public int MaxAmmo;
        public int MaxAmmoInClip;
        public string DisplayName;
        public string LocalizedName;
        public WeaponGroup Group;
        public WeaponHash Hash;
        public WeaponTint Tint;
    }
}