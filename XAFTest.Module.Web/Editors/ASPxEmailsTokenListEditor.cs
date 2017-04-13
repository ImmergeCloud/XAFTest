using System;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;

namespace XAFTest.Module.Web.Editors
{
    //https://www.devexpress.com/Support/Center/Question/Details/T377132
    [PropertyEditor(typeof(string), "ASPxEmailsTokenListEditor", false)]
    public class ASPxEmailsTokenListEditor : ASPxPropertyEditor
    {
        private const string TokenValidationExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        private const string TokenValidationText = "No Spaces allowed. Must be valid email addresses";

        public ASPxEmailsTokenListEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        { }

        private ASPxTokenBox _control;

        protected override WebControl CreateEditModeControlCore()
        {
            _control = new ASPxTokenBox();
            _control.ID = "ASPxTokenBox_control";

            _control.TextSeparator = ';';
            _control.ValueSeparator = ';';

            _control.TextField = PropertyName;//this.ObjectTypeInfo.DefaultMember.Name;
            _control.ValueField = PropertyName; //this.ObjectTypeInfo.KeyMember.Name;
            _control.ShowDropDownOnFocus = ShowDropDownOnFocusMode.Never;//.Always;
            _control.AllowCustomTokens = true;
            _control.ValueChanged += EditValueChangedHandler;

            _control.ValidationSettings.ValidateOnLeave = true;
            _control.ValidationSettings.RegularExpression.ValidationExpression = TokenValidationExpression;
            _control.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Top;
            _control.ValidationSettings.RegularExpression.ErrorText = TokenValidationText;

            return _control;
        }

        protected override WebControl CreateViewModeControlCore()
        {
            _control = new ASPxTokenBox();
            _control.ClientEnabled = false;
            _control.ReadOnly = true;

            _control.ID = "ASPxTokenBox_control";
            _control.TextSeparator = ';';
            _control.ValueSeparator = ';';
            _control.TextField = PropertyName; //this.ObjectTypeInfo.DefaultMember.Name;
            _control.ValueField = PropertyName; //this.ObjectTypeInfo.KeyMember.Name;
            _control.ShowDropDownOnFocus = ShowDropDownOnFocusMode.Never; //.Always;
            _control.AllowCustomTokens = true;
            _control.Width = new Unit("100%");

            return _control;
        }

        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            _control.DataBind();
            if (this.ViewEditMode == ViewEditMode.View)
            {
                _control.Value = PropertyValue;
            }
        }

        protected override void WriteValueCore()
        {
            if (_control != null)
            {
                if (!_control.IsValid)
                    return;
            }

            base.WriteValueCore();
        }

        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (_control != null)
                _control.ValueChanged -= EditValueChangedHandler;

            base.BreakLinksToControl(unwireEventsOnly);
        }
    }
}
