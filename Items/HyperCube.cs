using BaseLibrary.Items;
using Terraria;

namespace MassStorage.Items
{
	public class HyperCube : BaseItem
	{
		public override string Texture => "MassStorage/Textures/Items/HyperCube";

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
			item.createTile = mod.TileType<Tiles.HyperCube>();
			item.value = Item.sellPrice(0, 0, 5);
		}
	}
}