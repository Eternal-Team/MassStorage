using MassStorage.Items.Upgrades;
using Terraria.ID;
using Terraria.ModLoader;

namespace MassStorage.Items
{
	public class Tier1Upgrade : BaseUpgrade
	{
		public override int Capacity => 4096;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 1 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		}

	public class Tier2Upgrade : BaseUpgrade
	{
		public override int Capacity => 8192;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 2 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier3Upgrade : BaseUpgrade
	{
		public override int Capacity => 16384;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 3 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier4Upgrade : BaseUpgrade
	{
		public override int Capacity => 32768;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 4 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier5Upgrade : BaseUpgrade
	{
		public override int Capacity => 65536;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 5 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier6Upgrade : BaseUpgrade
	{
		public override int Capacity => 131072;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 6 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier7Upgrade : BaseUpgrade
	{
		public override int Capacity => 262144;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 7 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier8Upgrade : BaseUpgrade
	{
		public override int Capacity => 524288;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 8 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier9Upgrade : BaseUpgrade
	{
		public override int Capacity => 1048576;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 9 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier10Upgrade : BaseUpgrade
	{
		public override int Capacity => 2097152;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 10 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumOre, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier11Upgrade : BaseUpgrade
	{
		public override int Capacity => 4194304;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 11 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier12Upgrade : BaseUpgrade
	{
		public override int Capacity => 8388608;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 12 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Tier13Upgrade : BaseUpgrade
	{
		public override int Capacity => 16777216;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tier 13 Upgrade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}