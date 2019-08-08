using BaseLibrary;
using BaseLibrary.Tiles.TileEntites;
using BaseLibrary.UI;
using ContainerLibrary;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace MassStorage.TileEntities
{
	public class Barrel : BaseTE, IItemHandler, IHasUI
	{
		public override Type TileType => typeof(Tiles.Barrel);

		public ItemHandler Handler { get; set; }
		public Guid UUID { get; set; }
		public BaseUIPanel UI { get; set; }
		public LegacySoundStyle CloseSound => SoundID.Item1;
		public LegacySoundStyle OpenSound => SoundID.Item1;

		public Barrel()
		{
			Handler = new ItemHandler();
			Handler.OnContentsChanged += slot => { };
			Handler.GetSlotLimit += slot => 2048;
			Handler.IsItemValid += (slot, item) => item.maxStack > 1;
		}

		public override void OnKill()
		{
			Handler.DropItems(new Rectangle(Position.X * 16, Position.Y * 16, 32, 32));
		}

		public override TagCompound Save() => new TagCompound
		{
			["UUID"] = UUID,
			["Items"] = Handler.Save()
		};

		public override void Load(TagCompound tag)
		{
			UUID = tag.Get<Guid>("UUID");
			Handler.Load(tag.GetCompound("Items"));
		}

		public override void NetSend(BinaryWriter writer, bool lightSend)
		{
			writer.Write(UUID);
			Handler.Write(writer);
		}

		public override void NetReceive(BinaryReader reader, bool lightReceive)
		{
			UUID = reader.ReadGUID();
			Handler.Read(reader);
		}
	}
}