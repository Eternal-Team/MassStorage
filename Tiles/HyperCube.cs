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
	public class HyperCube : BaseTile
	{
		public override string Texture => "MassStorage/Textures/Tiles/HyperCube";

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
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(mod.GetTileEntity<TileEntities.HyperCube>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.addTile(Type);
			disableSmartCursor = true;

			ModTranslation name = CreateMapEntryName();
			AddMapEntry(Color.Purple, name);
		}

		public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
		{
			Main.specX[nextSpecialDrawIndex] = i;
			Main.specY[nextSpecialDrawIndex] = j;
			nextSpecialDrawIndex++;
		}

		public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
		{
			TileEntities.HyperCube hyperCube = Utility.GetTileEntity<TileEntities.HyperCube>(i, j);
			if (hyperCube == null) return;

			Tile tile = Main.tile[i, j];
			if (!tile.IsTopLeft()) return;

			Item item = hyperCube.Handler.GetItemInSlot(0);
			if (item.IsAir) return;

			Vector2 position = new Point16(i + 1, j + 1).ToScreenCoordinates();
			spriteBatch.DrawItemInWorld(item, position + new Vector2(0, 2), new Vector2(16f));

			string text = item.stack < 1000 ? item.stack.ToString() : item.stack.ToSI("N0");
			Vector2 size = Main.fontMouseText.MeasureString(text);
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, text, position - new Vector2(0, 4f), Color.White, 0f, size * 0.5f, new Vector2(0.6f));
		}

		public override void RightClick(int i, int j)
		{
			TileEntities.HyperCube hyperCube = Utility.GetTileEntity<TileEntities.HyperCube>(i, j);
			if (hyperCube == null) return;

			BaseLibrary.BaseLibrary.PanelGUI.UI.HandleUI(hyperCube);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			TileEntities.HyperCube hyperCube = Utility.GetTileEntity<TileEntities.HyperCube>(i, j);
			BaseLibrary.BaseLibrary.PanelGUI.UI.CloseUI(hyperCube);

			Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType<Items.HyperCube>());
			hyperCube.Kill(i, j);
		}
	}
}