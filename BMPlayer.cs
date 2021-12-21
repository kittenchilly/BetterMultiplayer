using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BetterMultiplayer
{
	public class BMPlayer : ModPlayer
	{
		public bool teamLoaded = false;
		public string teamChosen = GetInstance<BMConfig>().TeamToJoin;
		public int team;
		public override void OnEnterWorld(Player player)
		{
			base.OnEnterWorld(player);
			if (teamChosen != "None")
			{
				switch (teamChosen)
				{
					case "Red":
						team = 1;
						break;
					case "Green":
						team = 2;
						break;
					case "Blue":
						team = 3;
						break;
					case "Yellow":
						team = 4;
						break;
					case "Pink":
						team = 5;
						break;
					default:
						team = 1;
						break;
				}

				if (player.team != team)
				{
					player.team = team;
				}
			}
		}

		public override void UpdateDead() //no boss fight respawn
		{
			if (BMConfig.Instance.NoBossFightRespawn)
			{
				bool flag = false;
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.active && (npc.boss || npc.type == NPCID.EaterofWorldsHead))
					{
						Player bosstarget = Main.player[npc.target];
						if (!bosstarget.active || bosstarget.dead)
						{
							break;
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return;
				}
				Player.respawnTimer++;
			}
		}

		public override void SendClientChanges(ModPlayer localPlayer)
		{
			if (teamChosen != "None")
			{
				if (!teamLoaded)
				{
					if (Main.player[Main.myPlayer].team > 0)
					{
						NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
					}
					teamLoaded = true;
				}
				base.SendClientChanges(localPlayer);
			}
		}
	}
}
