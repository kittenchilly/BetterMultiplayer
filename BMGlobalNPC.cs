using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterMultiplayer
{
	public class BMGlobalNPC : GlobalNPC
	{
        public override void ModifyShop(NPCShop shop)
        {
            if (BMConfig.Instance.WitchDoctorWormhole)
            {
                if (shop.NpcType == NPCID.WitchDoctor)
                {
                    shop.Add(ItemID.WormholePotion);
                }
            }
        }
	}
}
