using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CuteNimbusMount.Mounts
{
    public class Nimbus : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = mod.DustType("NimbusDust");
            mountData.buff = mod.BuffType("NimbusMount");
            mountData.usesHover = true;
            mountData.heightBoost = 20;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 13f;
            mountData.dashSpeed = 8f;
            mountData.flightTimeMax = 100;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 5;
            mountData.acceleration = 1f; // 0.19f;
            mountData.jumpSpeed = 5f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 1;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 13;
            mountData.bodyFrame = 0;
            mountData.yOffset = 20;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 24;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 1;
            mountData.runningFrameDelay = 24;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 1;
            mountData.flyingFrameDelay = 24;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 24;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 24;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }

        public override void UpdateEffects(Player player)
        {
            int w = this.mountData.textureWidth;
            int h = this.mountData.textureHeight;
            float x = player.position.X - (w / 2) + this.mountData.xOffset + (w * 0.1f);
            float y = player.position.Y + (h / 2) + this.mountData.yOffset - this.mountData.heightBoost + (h * 0.1f);

            if (Math.Abs(player.velocity.X) > 4f || Math.Abs(player.velocity.Y) > 4f)
            {
                Dust.NewDust(new Vector2(x, y), (int)(w * 0.8), (int)(h * 0.8), this.mountData.spawnDust);
            }

            if (Main.rand.Next(25) == 0)
            {
                x += (w * 0.9f * (Main.rand.Next(20) / 20f));
                Projectile.NewProjectile(x, y +h, player.velocity.X/2, 2, Terraria.ID.ProjectileID.LostSoulFriendly, 30, 0, player.whoAmI);
            }
        }
    }
}