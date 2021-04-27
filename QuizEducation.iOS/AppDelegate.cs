using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
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

            FloatingActionButtonRenderer.InitRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
