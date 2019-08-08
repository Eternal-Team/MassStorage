using BaseLibrary;
using BaseLibrary.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.UI.Chat;

namespace MassStorage.Tiles
{
	public class Barrel : BaseTile
	{
		public override string Texture => "MassStorage/Textures/Tiles/Barrel";

		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidBottom, 0, 0);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(mod.GetTileEntity<TileEntities.Barrel>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.addTile(Type);
			disableSmartCursor = true;

			ModTranslation name = CreateMapEntryName();
			AddMapEntry(Color.Brown, name);
		}

		//public override void LeftClick(int i, int j)
		//{
		//	int ID = mod.GetID<TEBarrel>(i, j);
		//	if (ID == -1) return;

		//	Main.LocalPlayer.noThrow = 2;

		//	TEBarrel barrel = (TEBarrel)TileEntity.ByID[ID];

		//	if (!barrel.Items[0].IsAir)
		//	{
		//		if (Main.keyState.IsKeyDown(Keys.RightShift))
		//		{
		//			int count = Math.Min(barrel.Items[0].stack, barrel.Items[0].maxStack);
		//			Item.NewItem(barrel.Position.ToVector2() * 16, new Vector2(32), barrel.Items[0].type, count);
		//			barrel.Items[0].stack -= count;
		//			if (barrel.Items[0].stack <= 0) barrel.Items[0].TurnToAir();
		//		}
		//		else
		//		{
		//			Item.NewItem(barrel.Position.ToVector2() * 16, new Vector2(32), barrel.Items[0].type);
		//			barrel.Items[0].stack--;
		//			if (barrel.Items[0].stack <= 0) barrel.Items[0].TurnToAir();
		//		}

		//		//barrel.SendUpdate();
		//	}
		//}

		//public override void RightClick(int i, int j)
		//{
		//	int ID = mod.GetID<TEBarrel>(i, j);
		//	if (ID == -1) return;

		//	Main.LocalPlayer.noThrow = 2;

		//	TEBarrel barrel = (TEBarrel)TileEntity.ByID[ID];

		//	if (Main.inputText.IsKeyDown(Keys.RightShift))
		//	{
		//		if (Main.LocalPlayer.HasItem(barrel.Items[0].type))
		//		{
		//			int count = Math.Min(barrel.maxStoredItems - barrel.Items[0].stack, Main.LocalPlayer.CountItem(barrel.Items[0].type));
		//			Main.LocalPlayer.ConsumeItem(barrel.Items[0].type, count);
		//			barrel.Items[0].stack += count;
		//		}
		//		else mod.HandleUI<BarrelUI>(ID);
		//	}
		//	else
		//	{
		//		Item item = Utility.HeldItem;
		//		if (!item.IsAir)
		//		{
		//			if (barrel.Items[0].IsAir)
		//			{
		//				barrel.Items[0] = item.Clone();
		//				int count = Math.Min(item.stack, barrel.maxStoredItems);
		//				if (barrel.Items.Where((x, index) => index > 0 && index < barrel.Items.Count).Any(x => x.type == mod.ItemType<VoidUpgrade>())) item.TurnToAir();
		//				else
		//				{
		//					item.stack -= count;
		//					if (item.stack <= 0) item.TurnToAir();
		//				}

		//				barrel.Items[0].stack = count;
		//			}
		//			else
		//			{
		//				if (barrel.Items[0].type == item.type)
		//				{
		//					int count = Math.Min(item.stack, barrel.maxStoredItems - barrel.Items[0].stack);
		//					if (barrel.Items.Where((x, index) => index > 0 && index < barrel.Items.Count).Any(x => x.type == mod.ItemType<VoidUpgrade>())) item.TurnToAir();
		//					else
		//					{
		//						item.stack -= count;
		//						if (item.stack <= 0) item.TurnToAir();
		//					}

		//					barrel.Items[0].stack += count;
		//				}
		//			}
		//		}
		//		else mod.HandleUI<BarrelUI>(ID);
		//	}

		//	//barrel.SendUpdate();
		//}

		public override void RightClick(int i, int j)
		{
			TileEntities.Barrel barrel = Utility.GetTileEntity<TileEntities.Barrel>(i, j);
			if (barrel == null) return;

			BaseLibrary.BaseLibrary.PanelGUI.UI.HandleUI(barrel);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			TileEntities.Barrel barrel = Utility.GetTileEntity<TileEntities.Barrel>(i, j);
			BaseLibrary.BaseLibrary.PanelGUI.UI.CloseUI(barrel);

			Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType<Items.Barrel>());
			barrel.Kill(i, j);
		}

		public override void DrawEffects(int i, int j, SpriteBatch batch, ref Color color, ref int nextSpecialDrawIndex)
		{
			Main.specX[nextSpecialDrawIndex] = i;
			Main.specY[nextSpecialDrawIndex] = j;
			nextSpecialDrawIndex++;
		}

		public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
		{
			TileEntities.Barrel barrel = Utility.GetTileEntity<TileEntities.Barrel>(i, j);
			if (barrel == null) return;

			Tile tile = Main.tile[i, j];
			if (!tile.IsTopLeft()) return;

			Item item = barrel.Handler.GetItemInSlot(0);
			if (item.IsAir) return;

			Vector2 position = new Point16(i + 1, j + 1).ToScreenCoordinates();
			spriteBatch.DrawItemInWorld(item, position + new Vector2(0, 2), new Vector2(16f));

			string text = item.stack < 1000 ? item.stack.ToString() : item.stack.ToSI("N0");
			Vector2 size = Main.fontMouseText.MeasureString(text);
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, text, position - new Vector2(0, 4f), Color.White, 0f, size * 0.5f, new Vector2(0.6f));
		}
	}
}