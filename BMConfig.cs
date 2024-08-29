using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace BetterMultiplayer
{
	public class BMConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static BMConfig Instance;

		[DrawTicks]
		[OptionStrings(new string[] { "None", "Red", "Green", "Blue", "Yellow", "Pink" })]
		[DefaultValue("Red")]
		public string TeamToJoin;

		[DefaultValue(true)]
		public bool NoBossFightRespawn;

		[DefaultValue(true)]
		public bool WitchDoctorWormhole;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message)
		{
			if (!NetMessage.DoesPlayerSlotCountAsAHost(whoAmI))
			{
                message = NetworkText.FromKey("tModLoader.ModConfigRejectChangesNotHost");
				return false;
			}

			return true;
		}
	}
}
