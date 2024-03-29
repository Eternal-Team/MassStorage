﻿using BaseLibrary;
using BaseLibrary.Tiles;
using MassStorage.Items.Upgrades;
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

		public override void RightClick(int i, int j)
		{
			TileEntities.Barrel barrel = Utility.GetTileEntity<TileEntities.Barrel>(i, j);
			if (barrel == null) return;

			ref Item heldItem = ref Main.LocalPlayer.GetHeldItem();

			if (heldItem.modItem is BaseUpgrade upgrade && heldItem.type != barrel.UpgradeItem.type && barrel.Handler.GetItemInSlot(0).stack <= upgrade.Capacity)
			{
				if (!barrel.UpgradeItem.IsAir) Item.NewItem(i * 16, j * 16, 32, 32, barrel.UpgradeItem.type);

				barrel.UpgradeItem.SetDefaults(heldItem.type);
				if (--heldItem.stack <= 0) heldItem.TurnToAir();
			}
			else BaseLibrary.BaseLibrary.PanelGUI.UI.HandleUI(barrel);
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

		// todo: draw the outline according to barrel tier
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