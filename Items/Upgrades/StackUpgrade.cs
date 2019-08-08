//using MassStorage.TileEntities;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.ModLoader.IO;

//namespace MassStorage.Items
//{
//	public class StackUpgrade : BaseUpgrade
//	{
//		public static Dictionary<short, int> stackIncTable = new Dictionary<short, int>
//		{
//			{ ItemID.CopperBar, 2 },
//			{ ItemID.TinBar, 2 },
//			{ ItemID.IronBar, 2 },
//			{ ItemID.LeadBar, 2 },
//			{ ItemID.SilverBar, 2 },
//			{ ItemID.TungstenBar, 2 },
//			{ ItemID.GoldBar, 3 },
//			{ ItemID.PlatinumBar, 3 },
//			{ ItemID.DemoniteBar, 4 },
//			{ ItemID.CrimtaneBar, 4 },
//			{ ItemID.MeteoriteBar, 5 },
//			{ ItemID.HellstoneBar, 5 },
//			{ ItemID.CobaltBar, 6 },
//			{ ItemID.PalladiumBar, 6},
//			{ ItemID.MythrilBar, 7 },
//			{ ItemID.OrichalcumBar, 7},
//			{ ItemID.AdamantiteBar, 8},
//			{ ItemID.TitaniumBar, 8 },
//			{ ItemID.ChlorophyteBar, 10 },
//			{ ItemID.SpectreBar, 11 },
//			{ ItemID.HallowedBar, 9 },
//			{ ItemID.ShroomiteBar, 12 },
//			{ ItemID.LunarBar, 13 }
//		};

//		public override bool CloneNewInstances => false;

//		public override ModItem Clone(Item item)
//		{
//			StackUpgrade clone = (StackUpgrade)base.Clone(item);
//			clone.stackInc = stackInc;
//			return clone;
//		}

//		public int stackInc = 1;

//		public override void SetStaticDefaults()
//		{
//			DisplayName.SetDefault("Stack Upgrade");
//			Tooltip.SetDefault("TOOLTIP");
//		}

//		public override void SetDefaults()
//		{
//			item.width = 20;
//			item.height = 16;
//			item.maxStack = 1;
//			item.value = Item.sellPrice(0, 0, 10);
//		}

//		public override void ModifyTooltips(List<TooltipLine> tooltips)
//		{
//			tooltips.FirstOrDefault(x => x.mod == "Terraria" && x.Name == "ItemName")?.ModifyText($"Stack Upgrade (x{stackInc})");
//			tooltips.FirstOrDefault(x => x.mod == "Terraria" && x.Name == "Tooltip0")?.ModifyText($"Increases barrel's storage {stackInc} times ({(TEBarrel.BaseMax * stackInc).ToString("N0", CultureInfo.InvariantCulture)} items)");
//		}

//		public override TagCompound Save() => new TagCompound
//		{
//			["StackInc"] = stackInc
//		};

//		public override void Load(TagCompound tag)
//		{
//			stackInc = tag.GetInt("StackInc");
//		}

//		public override void NetSend(BinaryWriter writer) => TagIO.Write(Save(), writer);

//		public override void NetRecieve(BinaryReader reader) => Load(TagIO.Read(reader));

//		public override void AddRecipes()
//		{
//			foreach (var kvp in stackIncTable)
//			{
//				ModRecipe recipe = new ModRecipe(mod);
//				recipe.AddIngredient(kvp.Key, 4);
//				recipe.AddIngredient(mod.ItemType<UpgradeBase>());
//				recipe.SetResult(this);
//				recipe.AddRecipe();
//			}
//		}

//		public override void OnCraft(Recipe recipe)
//		{
//			stackInc = stackIncTable[(short)recipe.requiredItem[0].type];
//		}
//	}
//}

namespace MassStorage.Items.Upgrades
{
}