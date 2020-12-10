using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BetterMultiplayer
{
	public class BMGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity => true;

		public override void SetDefaults(Item item)
		{
			if (BMConfig.Instance.NerfReaverShark)
			{
				if (item.type == ItemID.ReaverShark)
				{
					item.pick = 64;
				}
			}
		}
	}
}
