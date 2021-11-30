using Terraria.ModLoader;


namespace BetterMultiplayer
{
	public class BetterMultiplayer : Mod
	{
        public Mod herosmod;
        public static BetterMultiplayer instance;
        public const string heropermission = "BetterMultiplayer";
        public const string heropermissiondisplayname = "Better Multiplayer Config";
        public bool hasPermission;

        public BetterMultiplayer()
		{

		}

        public override void Load()
        {
            instance = this;
            herosmod = ModLoader.GetMod("HEROsMod");
        }
        public override void Unload()
        {
            instance = null;
        }

        public override void PostAddRecipes()
        {
            SetupHerosMod();
        }

        public void SetupHerosMod()
        {
            if (herosmod != null)
            {
                herosmod.Call(
                    // Special string
                    "AddPermission",
                    // Permission Name
                    heropermission,
                    // Permission Display Name
                    heropermissiondisplayname);
            }
        }
    }
}
