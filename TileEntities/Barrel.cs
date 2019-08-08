using BaseLibrary;
using BaseLibrary.Tiles.TileEntites;
using BaseLibrary.UI;
using ContainerLibrary;
using MassStorage.Items.Upgrades;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace MassStorage.TileEntities
{
	public class Barrel : BaseTE, IItemHandler, IHasUI
	{
		public override Type TileType => typeof(Tiles.Barrel);

		public ItemHandler Handler { get; set; }
		public Item UpgradeItem;

		public Guid UUID { get; set; }
		public BaseUIPanel UI { get; set; }
		public LegacySoundStyle CloseSound => SoundID.Item1;
		public LegacySoundStyle OpenSound => SoundID.Item1;

		public Barrel()
		{
			Handler = new ItemHandler();
			Handler.OnContentsChanged += slot => { };
			Handler.GetSlotLimit += slot => UpgradeItem.IsAir ? 2048 : ((BaseUpgrade)UpgradeItem.modItem).Capacity;
			Handler.IsItemValid += (slot, item) => item.maxStack > 1;

			UpgradeItem = new Item();
		}

		public override void OnKill()
		{
			Rectangle hitbox = new Rectangle(Position.X * 16, Position.Y * 16, 32, 32);
			Handler.DropItems(hitbox);
			Item.NewItem(hitbox, UpgradeItem.type);
		}

		public override TagCompound Save() => new TagCompound
		{
			["UUID"] = UUID,
			["Items"] = Handler.Save(),
			["UpgradeItem"] = UpgradeItem
		};

		public override void Load(TagCompound tag)
		{
			UUID = tag.Get<Guid>("UUID");
			Handler.Load(tag.GetCompound("Items"));
			UpgradeItem = tag.Get<Item>("UpgradeItem");
		}

		public override void NetSend(BinaryWriter writer, bool lightSend)
		{
			writer.Write(UUID);
			Handler.Write(writer);
			writer.WriteItem(UpgradeItem, true);
		}

		public override void NetReceive(BinaryReader reader, bool lightReceive)
		{
			UUID = reader.ReadGUID();
			Handler.Read(reader);
			UpgradeItem = reader.ReadItem(true);
		}
	}
}