using Terraria.ID;
using Terraria.ModLoader;

namespace CuteNimbusMount.Items
{
    public class Nimbus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nimbus");
            Tooltip.SetDefault("Summons a fluffy nimbus.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 250000;
            item.rare = 8;
            item.expert = true;
            item.UseSound = SoundID.Item79;
            item.noMelee = true;
            item.mountType = mod.MountType("Nimbus");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(Terraria.ID.ItemID.Cloud, 100);
            recipe.AddIngredient(Terraria.ID.ItemID.SoulofFlight, 100);
            recipe.AddIngredient(Terraria.ID.ItemID.NimbusRod, 1);
            recipe.AddTile(Terraria.ID.TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}