using GTA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Timers;

namespace AuroraGSI_GTAV
{
    public class AuroraGSI : Script
    {
        private const string URI = "http://localhost:9088";
        private Timer requestTimer;
        private HttpClient http;
        private readonly GSINode node = new GSINode();
        private string last = "";

        public AuroraGSI()
        {
            Interval = 10;
            Tick += AuroraGSI_Tick;
            Logger.Log("Start");
            http = new HttpClient();
            requestTimer = new Timer(100);
            requestTimer.Enabled = true;
            requestTimer.AutoReset = true;
            requestTimer.Elapsed += (a, b) => SendGameState();
            requestTimer.Start();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Converters = new List<Newtonsoft.Json.JsonConverter>() { new Newtonsoft.Json.Converters.StringEnumConverter() }
            };
        }

        private void AuroraGSI_Tick(object sender, EventArgs e)
        {
            #region player
            node.Player.CanControlCharacter = Game.Player.CanControlCharacter;
            node.Player.CanStartMission = Game.Player.CanStartMission;
            node.Player.IsAiming = Game.Player.IsAiming;
            node.Player.IsAlive = Game.Player.IsAlive;
            node.Player.IsClimbing = Game.Player.IsClimbing;
            node.Player.IsDead = Game.Player.IsDead;
            node.Player.IsInvincible = Game.Player.IsInvincible;
            node.Player.IsPlaying = Game.Player.IsPlaying;
            node.Player.IsPressingHorn = Game.Player.IsPressingHorn;
            node.Player.IsRidingTrain = Game.Player.IsRidingTrain;
            node.Player.IsSpecialAbilityActive = Game.Player.IsSpecialAbilityActive;
            node.Player.IsSpecialAbilityEnabled = Game.Player.IsSpecialAbilityEnabled;
            node.Player.IsTargetingAnything = Game.Player.IsTargetingAnything;
            node.Player.RemainingSprintStamina = Game.Player.RemainingSprintStamina;
            node.Player.RemainingSprintTime = Game.Player.RemainingSprintTime;
            node.Player.RemainingUnderwaterTime = Game.Player.RemainingUnderwaterTime;
            node.Player.MaxArmor = Game.Player.MaxArmor;
            node.Player.Money = Game.Player.Money;
            node.Player.WantedLevel = Game.Player.WantedLevel;
            node.Player.Name = Game.Player.Name;
            #endregion
            #region weapon
            node.Player.CurrentWeapon.CanUseOnParachute = Game.Player.Character.Weapons.Current.CanUseOnParachute;
            node.Player.CurrentWeapon.IsPresent = Game.Player.Character.Weapons.Current.IsPresent;
            node.Player.CurrentWeapon.Ammo = Game.Player.Character.Weapons.Current.Ammo;
            node.Player.CurrentWeapon.AmmoInClip = Game.Player.Character.Weapons.Current.AmmoInClip;
            node.Player.CurrentWeapon.DefaultClipSize = Game.Player.Character.Weapons.Current.DefaultClipSize;
            node.Player.CurrentWeapon.MaxAmmo = Game.Player.Character.Weapons.Current.MaxAmmo;
            node.Player.CurrentWeapon.MaxAmmoInClip = Game.Player.Character.Weapons.Current.MaxAmmoInClip;
            node.Player.CurrentWeapon.DisplayName = Game.Player.Character.Weapons.Current.DisplayName;
            node.Player.CurrentWeapon.LocalizedName = Game.Player.Character.Weapons.Current.LocalizedName;
            node.Player.CurrentWeapon.Group = Game.Player.Character.Weapons.Current.Group;
            node.Player.CurrentWeapon.Hash = Game.Player.Character.Weapons.Current.Hash;
            node.Player.CurrentWeapon.Tint = Game.Player.Character.Weapons.Current.Tint;
            #endregion
            #region vehicle
            node.Player.LastVehicle.AreHighBeamsOn = Game.Player.LastVehicle.AreHighBeamsOn;
            node.Player.LastVehicle.AreLightsOn = Game.Player.LastVehicle.AreLightsOn;
            node.Player.LastVehicle.CanTiresBurst = Game.Player.LastVehicle.CanTiresBurst;
            node.Player.LastVehicle.CanWheelsBreak = Game.Player.LastVehicle.CanWheelsBreak;
            node.Player.LastVehicle.DropsMoneyOnExplosion = Game.Player.LastVehicle.DropsMoneyOnExplosion;
            node.Player.LastVehicle.HasBombBay = Game.Player.LastVehicle.HasBombBay;
            node.Player.LastVehicle.HasForks = Game.Player.LastVehicle.HasForks;
            node.Player.LastVehicle.HasRoof = Game.Player.LastVehicle.HasRoof;
            node.Player.LastVehicle.HasSiren = Game.Player.LastVehicle.HasSiren;
            node.Player.LastVehicle.HasTowArm = Game.Player.LastVehicle.HasTowArm;
            node.Player.LastVehicle.IsAlarmSet = Game.Player.LastVehicle.IsAlarmSet;
            node.Player.LastVehicle.IsAlarmSounding = Game.Player.LastVehicle.IsAlarmSounding;
            node.Player.LastVehicle.IsConvertible = Game.Player.LastVehicle.IsConvertible;
            node.Player.LastVehicle.IsDamaged = Game.Player.LastVehicle.IsDamaged;
            node.Player.LastVehicle.IsDriveable = Game.Player.LastVehicle.IsDriveable;
            node.Player.LastVehicle.IsEngineRunning = Game.Player.LastVehicle.IsEngineRunning;
            node.Player.LastVehicle.IsEngineStarting = Game.Player.LastVehicle.IsEngineStarting;
            node.Player.LastVehicle.IsFrontBumperBrokenOff = Game.Player.LastVehicle.IsFrontBumperBrokenOff;
            node.Player.LastVehicle.IsInBurnout = Game.Player.LastVehicle.IsInBurnout;
            node.Player.LastVehicle.IsInteriorLightOn = Game.Player.LastVehicle.IsInteriorLightOn;
            node.Player.LastVehicle.IsLeftHeadLightBroken = Game.Player.LastVehicle.IsLeftHeadLightBroken;
            node.Player.LastVehicle.IsOnAllWheels = Game.Player.LastVehicle.IsOnAllWheels;
            node.Player.LastVehicle.IsRearBumperBrokenOff = Game.Player.LastVehicle.IsRearBumperBrokenOff;
            node.Player.LastVehicle.IsRightHeadLightBroken = Game.Player.LastVehicle.IsRightHeadLightBroken;
            node.Player.LastVehicle.IsSearchLightOn = Game.Player.LastVehicle.IsSearchLightOn;
            node.Player.LastVehicle.IsSirenActive = Game.Player.LastVehicle.IsSirenActive;
            node.Player.LastVehicle.IsStolen = Game.Player.LastVehicle.IsStolen;
            node.Player.LastVehicle.IsStopped = Game.Player.LastVehicle.IsStopped;
            node.Player.LastVehicle.IsStoppedAtTrafficLights = Game.Player.LastVehicle.IsStoppedAtTrafficLights;
            node.Player.LastVehicle.IsTaxiLightOn = Game.Player.LastVehicle.IsTaxiLightOn;
            node.Player.LastVehicle.IsWanted = Game.Player.LastVehicle.IsWanted;
            node.Player.LastVehicle.NeedsToBeHotwired = Game.Player.LastVehicle.NeedsToBeHotwired;
            node.Player.LastVehicle.PreviouslyOwnedByPlayer = Game.Player.LastVehicle.PreviouslyOwnedByPlayer;
            node.Player.LastVehicle.ProvidesCover = Game.Player.LastVehicle.ProvidesCover;
            node.Player.LastVehicle.Acceleration = Game.Player.LastVehicle.Acceleration;
            node.Player.LastVehicle.BodyHealth = Game.Player.LastVehicle.BodyHealth;
            node.Player.LastVehicle.BrakePower = Game.Player.LastVehicle.BrakePower;
            node.Player.LastVehicle.Clutch = Game.Player.LastVehicle.Clutch;
            node.Player.LastVehicle.CurrentRPM = Game.Player.LastVehicle.CurrentRPM;
            node.Player.LastVehicle.DirtLevel = Game.Player.LastVehicle.DirtLevel;
            node.Player.LastVehicle.EngineHealth = Game.Player.LastVehicle.EngineHealth;
            node.Player.LastVehicle.EnginePowerMultiplier = Game.Player.LastVehicle.EnginePowerMultiplier;
            node.Player.LastVehicle.EngineTemperature = Game.Player.LastVehicle.EngineTemperature;
            node.Player.LastVehicle.FuelLevel = Game.Player.LastVehicle.FuelLevel;
            node.Player.LastVehicle.HeliBladesSpeed = Game.Player.LastVehicle.HeliBladesSpeed;
            node.Player.LastVehicle.HeliEngineHealth = Game.Player.LastVehicle.HeliEngineHealth;
            node.Player.LastVehicle.HeliMainRotorHealth = Game.Player.LastVehicle.HeliMainRotorHealth;
            node.Player.LastVehicle.HeliTailRotorHealth = Game.Player.LastVehicle.HeliTailRotorHealth;
            node.Player.LastVehicle.LightsMultiplier = Game.Player.LastVehicle.LightsMultiplier;
            node.Player.LastVehicle.LodMultiplier = Game.Player.LastVehicle.LodMultiplier;
            node.Player.LastVehicle.MaxBraking = Game.Player.LastVehicle.MaxBraking;
            node.Player.LastVehicle.MaxTraction = Game.Player.LastVehicle.MaxTraction;
            node.Player.LastVehicle.OilLevel = Game.Player.LastVehicle.OilLevel;
            node.Player.LastVehicle.OilVolume = Game.Player.LastVehicle.OilVolume;
            node.Player.LastVehicle.PetrolTankHealth = Game.Player.LastVehicle.PetrolTankHealth;
            node.Player.LastVehicle.PetrolTankVolume = Game.Player.LastVehicle.PetrolTankVolume;
            node.Player.LastVehicle.SteeringAngle = Game.Player.LastVehicle.SteeringAngle;
            node.Player.LastVehicle.SteeringScale = Game.Player.LastVehicle.SteeringScale;
            node.Player.LastVehicle.Throttle = Game.Player.LastVehicle.Throttle;
            node.Player.LastVehicle.ThrottlePower = Game.Player.LastVehicle.ThrottlePower;
            node.Player.LastVehicle.Turbo = Game.Player.LastVehicle.Turbo;
            node.Player.LastVehicle.WheelSpeed = Game.Player.LastVehicle.WheelSpeed;
            node.Player.LastVehicle.AlarmTimeLeft = Game.Player.LastVehicle.AlarmTimeLeft;
            node.Player.LastVehicle.CurrentGear = Game.Player.LastVehicle.CurrentGear;
            node.Player.LastVehicle.Gears = Game.Player.LastVehicle.Gears;
            node.Player.LastVehicle.HighGear = Game.Player.LastVehicle.HighGear;
            node.Player.LastVehicle.NextGear = Game.Player.LastVehicle.NextGear;
            node.Player.LastVehicle.PassengerCapacity = Game.Player.LastVehicle.PassengerCapacity;
            node.Player.LastVehicle.PassengerCount = Game.Player.LastVehicle.PassengerCount;
            node.Player.LastVehicle.ClassDisplayName = Game.Player.LastVehicle.ClassDisplayName;
            node.Player.LastVehicle.ClassLocalizedName = Game.Player.LastVehicle.ClassLocalizedName;
            node.Player.LastVehicle.DisplayName = Game.Player.LastVehicle.DisplayName;
            node.Player.LastVehicle.LocalizedName = Game.Player.LastVehicle.LocalizedName;
            node.Player.LastVehicle.ClassType = Game.Player.LastVehicle.ClassType;
            #endregion
            #region game
            node.Game.IsNightVisionActive = Game.IsNightVisionActive;
            node.Game.IsThermalVisionActive = Game.IsThermalVisionActive;
            node.Game.IsMissionActive = Game.IsMissionActive;
            node.Game.IsRandomEventActive = Game.IsRandomEventActive;
            node.Game.IsCutsceneActive = Game.IsCutsceneActive;
            node.Game.IsWaypointActive = Game.IsWaypointActive;
            node.Game.IsPaused = Game.IsPaused;
            node.Game.RadioStation = Game.RadioStation;
            node.Game.IsLoading = Game.IsLoading;
            #endregion
        }

        public async void SendGameState()
        {
            string data = JsonConvert.SerializeObject(node);
            if (data != last)
            {
                last = data;
                try
                {
                    var response = await http.PostAsync(URI, new StringContent(data, Encoding.UTF8, "application/json"));
                    if (!response.IsSuccessStatusCode)
                    {
                        Logger.Log("2");
                        requestTimer.Enabled = false;
                        //if one of these fails, restarting the mod is required.
                        //this is done for users with the mod installed and aurora closed
                    }
                    response.Dispose();
                }
                catch
                {
                    Logger.Log("1");
                    requestTimer.Enabled = false;
                }
            }
            else
            {
                //Logger.Log("same");
            }
        }
    }
}
