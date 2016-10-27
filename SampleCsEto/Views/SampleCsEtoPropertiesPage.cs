﻿using System.Diagnostics;
using Eto.Drawing;
using Eto.Forms;
using Rhino.DocObjects;
using Rhino.UI;

namespace SampleCsEto.Views
{
  class SampleCsEtoPropertiesPage : ObjectPropertiesPage
  {
    private SampleCsEtoPropertiesPageControl m_page_control;

    public override string EnglishPageTitle
    {
      get { return "Sample"; }
    }

    public override System.Drawing.Icon Icon
    {
      get { return Properties.Resources.SampleCsEtoPanel; }
    }

    public override object PageControl
    {
      get
      {
        return (m_page_control ?? (m_page_control = new SampleCsEtoPropertiesPageControl()));
      }
    }

    public override bool ShouldDisplay(RhinoObject rhObj)
    {
      Debug.WriteLine("SampleCsEtoPropertiesPage.ShouldDisplay(" + rhObj + ")");
      return true;
    }

    public override void InitializeControls(RhinoObject rhObj)
    {
      if (m_page_control != null)
        m_page_control.InitializeControls(rhObj);
    }
  }

  class SampleCsEtoPropertiesPageControl : Panel
  {
    public SampleCsEtoPropertiesPageControl()
    {
      var hello_button = new Button { Text = "Hello..." };
      hello_button.Click += (sender, e) => OnHelloButton();

      var child_button = new Button { Text = "Child Dialog..." };
      child_button.Click += (sender, e) => OnChildButton();

      var layout = new DynamicLayout { DefaultSpacing = new Size(5, 5), Padding = new Padding(10) };
      layout.AddSeparateRow(hello_button, null);
      layout.AddSeparateRow(child_button, null);
      layout.Add(null);
      Content = layout;
    }

    public void InitializeControls(RhinoObject rhObj)
    {
      Debug.WriteLine("SampleCsEtoPropertiesPage.InitializeControls(" + rhObj + ")");
    }

    /// <summary>
    /// Example of proper way to display a message box
    /// </summary>
    protected void OnHelloButton()
    {
      // Use the Rhino common message box and NOT the Eto MessageBox,
      // the Eto version expects a top level Eto Window as the owner for
      // the MessageBox and will cause problems when running on the Mac.
      // Since this panel is a child of some Rhino container it does not
      // have a top level Eto Window.
      Dialogs.ShowMessage("Hello Rhino!", "Sample");
    }

    /// <summary>
    /// Sample of how to display a child Eto dialog
    /// </summary>
    protected void OnChildButton()
    {
      var dialog = new SampleCsEtoHelloWorld();
      dialog.ShowModal(this);
    }
  }
}
