using System;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using Sharpnado.MaterialFrame.iOS;
using SuaveControls.FloatingActionButton.iOS.Renderers;
using UIKit;

namespace QuizEducation.iOS
{

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Firebase.Core.App.Configure(); //Firebase

            FloatingActionButtonRenderer.InitRenderer(); //FloatingActionButton
            iOSMaterialFrameRenderer.Init(); //Sharpnado.MaterialFrame
            CarouselViewRenderer.Init(); //CarouselView.Plugin

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
