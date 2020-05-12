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
        private readonly Timer requestTimer;
        private readonly HttpClient http;
        private readonly GSINode node = new GSINode();
        private string last = "";

        public AuroraGSI()
        {
            Interval = 10;
            Tick += AuroraGSI_Tick;
            Logger.Log("Start");
            http = new HttpClient();
            requestTimer = new Timer()
            {
                Interval = 100,
                Enabled = true
            };
            requestTimer.Elapsed += (a, b) => SendGameState();
            requestTimer.Start();
            //might want to remove this later, useful for debugging though
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>() { new Newtonsoft.Json.Converters.StringEnumConverter() }
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
            node.CurrentWeapon.CanUseOnParachute = Game.Player.Character.Weapons.Current.CanUseOnParachute;
            node.CurrentWeapon.IsPresent = Game.Player.Character.Weapons.Current.IsPresent;
            node.CurrentWeapon.Ammo = Game.Player.Character.Weapons.Current.Ammo;
            node.CurrentWeapon.AmmoInClip = Game.Player.Character.Weapons.Current.AmmoInClip;
            node.CurrentWeapon.DefaultClipSize = Game.Player.Character.Weapons.Current.DefaultClipSize;
            node.CurrentWeapon.MaxAmmo = Game.Player.Character.Weapons.Current.MaxAmmo;
            node.CurrentWeapon.MaxAmmoInClip = Game.Player.Character.Weapons.Current.MaxAmmoInClip;
            node.CurrentWeapon.DisplayName = Game.Player.Character.Weapons.Current.DisplayName;
            node.CurrentWeapon.LocalizedName = Game.Player.Character.Weapons.Current.LocalizedName;
            node.CurrentWeapon.Group = Game.Player.Character.Weapons.Current.Group;
            node.CurrentWeapon.Hash = Game.Player.Character.Weapons.Current.Hash;
            node.CurrentWeapon.Tint = Game.Player.Character.Weapons.Current.Tint;
            #endregion
            #region vehicle
            node.LastVehicle.AreHighBeamsOn = Game.Player.LastVehicle.AreHighBeamsOn;
            node.LastVehicle.AreLightsOn = Game.Player.LastVehicle.AreLightsOn;
            node.LastVehicle.CanTiresBurst = Game.Player.LastVehicle.CanTiresBurst;
            node.LastVehicle.CanWheelsBreak = Game.Player.LastVehicle.CanWheelsBreak;
            node.LastVehicle.IsAlarmSet = Game.Player.LastVehicle.IsAlarmSet;
            node.LastVehicle.IsAlarmSounding = Game.Player.LastVehicle.IsAlarmSounding;
            node.LastVehicle.IsConvertible = Game.Player.LastVehicle.IsConvertible;
            node.LastVehicle.IsDamaged = Game.Player.LastVehicle.IsDamaged;
            node.LastVehicle.IsDriveable = Game.Player.LastVehicle.IsDriveable;
            node.LastVehicle.IsEngineRunning = Game.Player.LastVehicle.IsEngineRunning;
            node.LastVehicle.IsFrontBumperBrokenOff = Game.Player.LastVehicle.IsFrontBumperBrokenOff;
            node.LastVehicle.IsInBurnout = Game.Player.LastVehicle.IsInBurnout;
            node.LastVehicle.IsInteriorLightOn = Game.Player.LastVehicle.IsInteriorLightOn;
            node.LastVehicle.IsLeftHeadLightBroken = Game.Player.LastVehicle.IsLeftHeadLightBroken;
            node.LastVehicle.IsOnAllWheels = Game.Player.LastVehicle.IsOnAllWheels;
            node.LastVehicle.IsRearBumperBrokenOff = Game.Player.LastVehicle.IsRearBumperBrokenOff;
            node.LastVehicle.IsRightHeadLightBroken = Game.Player.LastVehicle.IsRightHeadLightBroken;
            node.LastVehicle.IsSearchLightOn = Game.Player.LastVehicle.IsSearchLightOn;
            node.LastVehicle.IsSirenActive = Game.Player.LastVehicle.IsSirenActive;
            node.LastVehicle.IsStolen = Game.Player.LastVehicle.IsStolen;
            node.LastVehicle.IsStopped = Game.Player.LastVehicle.IsStopped;
            node.LastVehicle.IsStoppedAtTrafficLights = Game.Player.LastVehicle.IsStoppedAtTrafficLights;
            node.LastVehicle.IsTaxiLightOn = Game.Player.LastVehicle.IsTaxiLightOn;
            node.LastVehicle.IsWanted = Game.Player.LastVehicle.IsWanted;
            node.LastVehicle.NeedsToBeHotwired = Game.Player.LastVehicle.NeedsToBeHotwired;
            node.LastVehicle.ProvidesCover = Game.Player.LastVehicle.ProvidesCover;
            node.LastVehicle.Acceleration = Game.Player.LastVehicle.Acceleration;
            node.LastVehicle.BodyHealth = Game.Player.LastVehicle.BodyHealth;
            node.LastVehicle.BrakePower = Game.Player.LastVehicle.BrakePower;
            node.LastVehicle.Clutch = Game.Player.LastVehicle.Clutch;
            node.LastVehicle.CurrentRPM = Game.Player.LastVehicle.CurrentRPM;
            node.LastVehicle.DirtLevel = Game.Player.LastVehicle.DirtLevel;
            node.LastVehicle.EngineHealth = Game.Player.LastVehicle.EngineHealth;
            node.LastVehicle.EnginePowerMultiplier = Game.Player.LastVehicle.EnginePowerMultiplier;
            node.LastVehicle.EngineTemperature = Game.Player.LastVehicle.EngineTemperature;
            node.LastVehicle.FuelLevel = Game.Player.LastVehicle.FuelLevel;
            node.LastVehicle.HeliBladesSpeed = Game.Player.LastVehicle.HeliBladesSpeed;
            node.LastVehicle.HeliEngineHealth = Game.Player.LastVehicle.HeliEngineHealth;
            node.LastVehicle.HeliMainRotorHealth = Game.Player.LastVehicle.HeliMainRotorHealth;
            node.LastVehicle.HeliTailRotorHealth = Game.Player.LastVehicle.HeliTailRotorHealth;
            node.LastVehicle.LightsMultiplier = Game.Player.LastVehicle.LightsMultiplier;
            node.LastVehicle.LodMultiplier = Game.Player.LastVehicle.LodMultiplier;
            node.LastVehicle.MaxBraking = Game.Player.LastVehicle.MaxBraking;
            node.LastVehicle.MaxTraction = Game.Player.LastVehicle.MaxTraction;
            node.LastVehicle.OilLevel = Game.Player.LastVehicle.OilLevel;
            node.LastVehicle.OilVolume = Game.Player.LastVehicle.OilVolume;
            node.LastVehicle.PetrolTankHealth = Game.Player.LastVehicle.PetrolTankHealth;
            node.LastVehicle.PetrolTankVolume = Game.Player.LastVehicle.PetrolTankVolume;
            node.LastVehicle.SteeringAngle = Game.Player.LastVehicle.SteeringAngle;
            node.LastVehicle.SteeringScale = Game.Player.LastVehicle.SteeringScale;
            node.LastVehicle.Throttle = Game.Player.LastVehicle.Throttle;
            node.LastVehicle.ThrottlePower = Game.Player.LastVehicle.ThrottlePower;
            node.LastVehicle.Turbo = Game.Player.LastVehicle.Turbo;
            node.LastVehicle.WheelSpeed = Game.Player.LastVehicle.WheelSpeed;
            node.LastVehicle.AlarmTimeLeft = Game.Player.LastVehicle.AlarmTimeLeft;
            node.LastVehicle.CurrentGear = Game.Player.LastVehicle.CurrentGear;
            node.LastVehicle.Gears = Game.Player.LastVehicle.Gears;
            node.LastVehicle.HighGear = Game.Player.LastVehicle.HighGear;
            node.LastVehicle.NextGear = Game.Player.LastVehicle.NextGear;
            node.LastVehicle.PassengerCapacity = Game.Player.LastVehicle.PassengerCapacity;
            node.LastVehicle.PassengerCount = Game.Player.LastVehicle.PassengerCount;
            node.LastVehicle.ClassDisplayName = Game.Player.LastVehicle.ClassDisplayName;
            node.LastVehicle.ClassLocalizedName = Game.Player.LastVehicle.ClassLocalizedName;
            node.LastVehicle.DisplayName = Game.Player.LastVehicle.DisplayName;
            node.LastVehicle.LocalizedName = Game.Player.LastVehicle.LocalizedName;
            node.LastVehicle.ClassType = Game.Player.LastVehicle.ClassType;
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
