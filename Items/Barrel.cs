using BaseLibrary.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MassStorage.Items
{
	public class Barrel : BaseItem
	{
		public override string Texture => "MassStorage/Textures/Items/Barrel";

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType<Tiles.Barrel>();
			item.value = Item.sellPrice(0, 0, 5);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}