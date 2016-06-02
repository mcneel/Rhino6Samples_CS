﻿using Eto.Drawing;
using Eto.Forms;

namespace SampleEto.Views
{
  class SampleEtoModalDialog : Dialog<DialogResult>
  {
    public SampleEtoModalDialog()
    {
      Padding = new Padding(5);
      Resizable = false;
      Result = DialogResult.Cancel;
      Title = GetType().Name;
      WindowStyle = WindowStyle.Default;

      var hello_button = new Button { Text = "Hello" };
      hello_button.Click += (sender, e) => OnHelloButton();

      DefaultButton = new Button { Text = "OK" };
      DefaultButton.Click += (sender, e) => Close(DialogResult.Ok);

      AbortButton = new Button { Text = "Cancel" };
      AbortButton.Click += (sender, e) => Close(DialogResult.Cancel);

      var button_layout = new TableLayout
      {
        Padding = new Padding(5, 10, 5, 5),
        Spacing = new Size(5, 5),
        Rows = { new TableRow(null, hello_button, null) }
      };

      var defaults_layout = new TableLayout
      {
        Padding = new Padding(5, 10, 5, 5),
        Spacing = new Size(5, 5),
        Rows = { new TableRow(null, DefaultButton, AbortButton, null) }
      };

      Content = new TableLayout
      {
        Padding = new Padding(5),
        Spacing = new Size(5, 5),
        Rows =
        {
          new TableRow(button_layout),
          new TableRow(defaults_layout)
        }
      };
    }

    protected void OnHelloButton()
    {
      MessageBox.Show(this, "Hello Rhino!", Title, MessageBoxButtons.OK);
    }
  }
}
