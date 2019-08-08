using BaseLibrary;
using BaseLibrary.UI;
using BaseLibrary.UI.Elements;
using ContainerLibrary;
using MassStorage.TileEntities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;

namespace MassStorage.UI
{
	public class BarrelPanel : BaseUIPanel<Barrel>, IItemHandlerUI
	{
		public ItemHandler Handler => Container.Handler;

		public string GetTexture(Item item) => "MassStorage/Textures/Items/Barrel";

		public override void OnInitialize()
		{
			Width = (408, 0);
			Height = (84, 0);
			this.Center();

			UIText textLabel = new UIText(Language.GetText("Mods.MassStorage.MapObject.Barrel"))
			{
				HAlign = 0.5f,
				HorizontalAlignment = HorizontalAlignment.Center
			};
			Append(textLabel);

			UITextButton buttonClose = new UITextButton("X")
			{
				Size = new Vector2(20),
				Left = (-20, 1),
				Padding = (0, 0, 0, 0),
				RenderPanel = false
			};
			buttonClose.OnClick += (evt, element) => BaseLibrary.BaseLibrary.PanelGUI.UI.CloseUI(Container);
			Append(buttonClose);

			UIContainerSlot slot = new UIContainerSlot(() => Container.Handler)
			{
				Top = (28, 0),
				HAlign = 0.5f,
				ShortStackSize = true
			};
			Append(slot);
		}
	}
}