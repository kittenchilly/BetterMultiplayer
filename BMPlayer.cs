using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BetterMultiplayer
{
	public class BMPlayer : ModPlayer
	{
		public string teamChosen = GetInstance<BMConfig>().TeamToJoin;
		public int team = 0;
		public override void OnEnterWorld()
		{
			team = teamChosen switch
			{
				"None" => 0,
				"Red" => 1,
				"Green" => 2,
				"Blue" => 3,
				"Yellow" => 4,
				"Pink" => 5,
				_ => 0,
			};
		}

		public override void CopyClientState(ModPlayer clientClone)
		{
			clientClone.Player.team = team;
		}

		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			if (clientPlayer.Player.team != team)
			{
				Main.player[Main.myPlayer].team = team;
				NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer);
			}
		}


		public override void UpdateDead() //no boss fight respawn
		{
			if (BMConfig.Instance.NoBossFightRespawn)
			{
				if (Main.npc.Any(n => n.whoAmI < Main.maxNPCs && n.active && n.boss))
				{
					Player.respawnTimer = 5;
				}
			}
		}
	}
}
