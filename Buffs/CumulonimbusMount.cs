using Terraria;
using Terraria.ModLoader;

namespace CuteNimbusMount.Buffs
{
    public class CumulonimbusMount : ModBuff
    {
        static float stable_y = -0.0001f;

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cumulonimbus");
            Description.SetDefault("Somewhat less cute.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.raining)
            {
                player.mount.SetMount(mod.MountType<Mounts.Cumulonimbus>(), player);
            }
            else
            {
                player.mount.SetMount(mod.MountType<Mounts.Nimbus>(), player);
            }
            player.buffTime[buffIndex] = 10;
            player.noFallDmg = true;
            player.mount._flyTime = 100;

            float v = player.velocity.X;
            if (v > 100) v = 100;
            if (v < -100) v = -100;
            if (v > 0 && v < 5) v -= .1f;
            if (v < 0 && v > -5) v += .1f;
            if (v < .5 && v > -.5) v = 0;
            player.velocity.X = v;

            v = player.velocity.Y;
            if (v > 7) v += .1f;
            if (v > 15) v = 15;
            if (v < -15) v = -15;
            if (v != 0 && v > stable_y && v < 5) v -= .1f;
            if (v != 0 && v < stable_y && v > -5) v += .1f;
            if (v != 0 && v < (stable_y + 0.5f) && v > (stable_y - 0.5f)) v = stable_y;
            player.velocity.Y = v;
        }
    }
}
