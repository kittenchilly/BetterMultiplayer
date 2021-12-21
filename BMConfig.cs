using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;

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
		[Label("Witch Doctor sells Wormhole Potions")]
		public bool WitchDoctorWormhole;

		// Code created by Jopojelly, taken from CheatSheet
		private bool IsPlayerLocalServerOwner(Player player)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();
			}
			for (int plr = 0; plr < Main.maxPlayers; plr++)
			{
				RemoteClient NetPlayer = Netplay.Clients[plr];
				if (NetPlayer.State == 10 && Main.player[plr] == player && NetPlayer.Socket.GetRemoteAddress().IsLocalHost())
				{
					return true;
				}
			}
			return false;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			if (!IsPlayerLocalServerOwner(Main.player[whoAmI]))
			{
				message = "Only the host is allowed to change this config.";
				return false;
			}
			return true;
		}
	}
}
