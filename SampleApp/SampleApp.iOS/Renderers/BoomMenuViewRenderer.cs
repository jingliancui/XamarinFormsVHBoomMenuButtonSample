using System;
using CoreGraphics;
using SampleApp.Controls;
using SampleApp.iOS.Renderers;
using UIKit;
using VHBoomMenuButton_Api;
using VHBoomMenuButton_Structs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BoomMenuView), typeof(BoomMenuViewRenderer))]
namespace SampleApp.iOS.Renderers
{
    public class BoomMenuViewRenderer:ViewRenderer<BoomMenuView, VHBoomMenuButton>
    {
        private VHBoomMenuButton ctrl;

        protected override void OnElementChanged(ElementChangedEventArgs<BoomMenuView> e)
        {
            base.OnElementChanged(e);

            if (ctrl==null)
            {
                ctrl = new VHBoomMenuButton()
                {
                    Frame = new CGRect(0,0,60,60),
                    ButtonEnum= VHButtonEnum.SimpleCircle,
                    PiecePlaceEnum= VHPiecePlaceEnum.Dot91,
                    ButtonPlaceEnum= VHButtonPlaceEnum.Sc91
                };
                var num = ctrl.GetPieceNumber;
                for (int i = 0; i < num; i++)
                {
                    var builder = new VHSimpleCircleButtonBuilder();
                    builder.NormalImageName = "bee";
                    builder.ClickedBlock = new BoomButtonDidClickBlock(index =>
                    {
                        MessagingCenter.Send(new object(), MainPage.BoomIndex, index);
                    });
                    ctrl.AddBuilder(builder);
                }
            }

            SetNativeControl(ctrl);
        }
    }
}
