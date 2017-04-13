using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

namespace XAFTest.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public class SwitchToEditModeDetailViewController : ViewController<DetailView>, IModelExtender
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            if (View.ViewEditMode == ViewEditMode.View)
            {
                View.ViewEditMode = ((IModelClassDefaultViewEditMode)View.Model).DefaultViewEditMode;
            }
            // Perform various tasks depending on the target View.
        }

        void IModelExtender.ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            extenders.Add<IModelClass, IModelClassDefaultViewEditMode>();
            extenders.Add<IModelObjectView, IModelViewDefaultViewEditMode>();
        }
        public interface IModelClassDefaultViewEditMode
        {
            [Category("Behavior")]
            [Description("Sets the Default Edit Mode")]
            [DefaultValue(ViewEditMode.View)]
            ViewEditMode DefaultViewEditMode { get; set; }
        }
        [ModelInterfaceImplementor(typeof(IModelClassDefaultViewEditMode), "ModelClass")]
        public interface IModelViewDefaultViewEditMode : IModelClassDefaultViewEditMode
        {
        }
    }
}
