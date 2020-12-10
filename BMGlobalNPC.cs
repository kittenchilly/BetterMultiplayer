using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BetterMultiplayer
{
	public class BMGlobalNPC : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (BMConfig.Instance.WitchDoctorWormhole)
			{
				if (type == NPCID.WitchDoctor)
				{
					shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
					nextSlot++;
				}
			}
		}
	}
}
