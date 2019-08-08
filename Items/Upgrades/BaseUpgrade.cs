using BaseLibrary.Items;
using Terraria;

namespace MassStorage.Items.Upgrades
{
	public abstract class BaseUpgrade : BaseItem
	{
		public abstract int Capacity { get; }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 16;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 10);
		}
	}
}