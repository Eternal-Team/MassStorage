using BaseLibrary;
using BaseLibrary.UI;
using BaseLibrary.UI.Elements;
using ContainerLibrary;
using MassStorage.Items;
using Microsoft.Xna.Framework;
using Terraria;

namespace MassStorage.UI
{
	public class PortableHyperCubePanel : BaseUIPanel<PortableHyperCube>, IItemHandlerUI
	{
		public ItemHandler Handler => Container.Handler;

		public string GetTexture(Item item) => "MassStorage/Textures/Items/PortableHyperCube";

		public override void OnInitialize()
		{
			Width = (408, 0);
			Height = (84, 0);
			this.Center();

			UIText textLabel = new UIText(Container.DisplayName.GetTranslation())
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