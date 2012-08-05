using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation;
using umbraco.presentation.LiveEditing;
using umbraco.presentation.LiveEditing.Controls;
using Ninject.Web;

namespace WebsiteKernel.Umbraco
{
    public class UmbracoMasterPageBase : MasterPageBase
    {
        protected ILiveEditingContext m_LiveEditingContext = UmbracoContext.Current.LiveEditingContext;
        protected ContentPlaceHolder ContentPlaceHolderDefault;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.AddLiveEditingSupport();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding Canvas support.", ex);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.m_LiveEditingContext.Enabled)
            {
                base.Render(writer);
            }
            else
            {
                StringWriter stringWriter = new StringWriter();
                base.Render(new HtmlTextWriter((TextWriter)stringWriter));
                string str = stringWriter.ToString().Replace("<html", "<html xmlns:umbraco=\"http://umbraco.org\"");
                writer.Write(str);
            }
        }

        protected virtual void AddLiveEditingSupport()
        {
            if (!this.m_LiveEditingContext.Enabled)
                return;
            if (this.Page.Form == null)
            {
                UmbracoContext.Current.LiveEditingContext.Enabled = false;
                throw new ApplicationException("Umbraco Canvas requires an ASP.Net form to function properly. Live editing has been turned off.");
            }
            else
            {
                if (ScriptManager.GetCurrent(this.Page) == null)
                    this.Page.Form.Controls.Add((Control)new ScriptManager());
                this.Page.Form.Controls.Add((Control)new LiveEditingManager(this.m_LiveEditingContext));
            }
        }
    }
}
