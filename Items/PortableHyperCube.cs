using BaseLibrary;
using BaseLibrary.Items;
using BaseLibrary.UI;
using ContainerLibrary;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MassStorage.Items
{
	public class PortableHyperCube : BaseItem, IItemHandler, IHasUI, ICraftingStorage
	{
		public override bool CloneNewInstances => true;

		public ItemHandler Handler { get; set; }
		public Guid UUID { get; set; }
		public BaseUIPanel UI { get; set; }
		public LegacySoundStyle CloseSound => SoundID.Item1;
		public LegacySoundStyle OpenSound => SoundID.Item1;
		public ItemHandler CraftingHandler => Handler;

		public PortableHyperCube()
		{
			Handler = new ItemHandler();
			Handler.OnContentsChanged += slot => { };
			Handler.GetSlotLimit += slot => int.MaxValue;
			Handler.IsItemValid += (slot, item) => item.maxStack > 1;
		}

		public override ModItem Clone(Item item)
		{
			PortableHyperCube clone = (PortableHyperCube)base.Clone();
			clone.UUID = UUID;
			clone.Handler = Handler.Clone();
			return clone;
		}

		public override void SetDefaults()
		{
			UUID = Guid.NewGuid();
			item.width = 32;
			item.height = 34;
			item.useTime = 5;
			item.useAnimation = 5;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.value = 10000;
			item.rare = 1;
		}

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == Main.LocalPlayer.whoAmI) BaseLibrary.BaseLibrary.PanelGUI.UI.HandleUI(this);

			return true;
		}

		public override bool ConsumeItem(Player player) => false;

		public override bool CanRightClick() => true;

		public override void RightClick(Player player)
		{
			if (player.whoAmI == Main.LocalPlayer.whoAmI) BaseLibrary.BaseLibrary.PanelGUI.UI.HandleUI(this);
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

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(UUID);
			Handler.Write(writer);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			UUID = reader.ReadGUID();
			Handler.Read(reader);
		}
	}
}