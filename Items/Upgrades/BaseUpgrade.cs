using BaseLibrary.Items;

namespace MassStorage.Items.Upgrades
{
	// todo: barrel tiers according to different metal tier in terraria, add some special upgrades (infinite, void)
	public abstract class BaseUpgrade : BaseItem
	{
	}

	//public class UpgradeBase : BaseItem
	//{
	//	public override void SetStaticDefaults()
	//	{
	//		DisplayName.SetDefault("Upgrade Base");
	//		Tooltip.SetDefault("Used to craft other ingredients");
	//	}

	//	public override void SetDefaults()
	//	{
	//		item.width = 20;
	//		item.height = 16;
	//		item.maxStack = 999;
	//		item.value = Item.sellPrice(0, 0, 10);
	//	}

	//	public override void AddRecipes()
	//	{
	//		ModRecipe recipe = new ModRecipe(mod);
	//		recipe.AddIngredient(ItemID.Cobweb, 8);
	//		recipe.AddIngredient(ItemID.Wood, 8);
	//		recipe.anyWood = true;
	//		recipe.SetResult(this);
	//		recipe.AddRecipe();
	//	}
	//}
}