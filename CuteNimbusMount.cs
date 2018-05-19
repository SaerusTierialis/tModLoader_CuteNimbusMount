using Terraria.ModLoader;

namespace CuteNimbusMount
{
	class CuteNimbusMount : Mod
	{
		public CuteNimbusMount()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
