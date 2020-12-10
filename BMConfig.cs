using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;


namespace BetterMultiplayer
{
	public class BMConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static BMConfig Instance;

		[Label("Team To Join")]
		[DrawTicks]
		[OptionStrings(new string[] { "None", "Red", "Green", "Blue", "Yellow", "Pink" })]
		[DefaultValue("Red")]
		public string TeamToJoin;

		[DefaultValue(true)]
		[Label("Disable Respawning during Boss Fights")]
		public bool NoBossFightRespawn;

		[DefaultValue(true)]
		[Label("Boss Death Cam")]
		public bool DeathCam;

		[DefaultValue(true)]
		[Label("Reaver Shark Nerf")]
		public bool NerfReaverShark;

		[DefaultValue(true)]
		[Label("Witch Doctor sells Wormhole Potions")]
		public bool WitchDoctorWormhole;
	}
}
