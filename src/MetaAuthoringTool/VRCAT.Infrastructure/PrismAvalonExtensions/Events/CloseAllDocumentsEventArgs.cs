﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRCAT.Infrastructure.PrismAvalonExtensions.Events
{
  public class CloseAllDocumentsEventArgs
  {
    public CloseAllDocumentsEventArgs()
    {
    }

    public CloseAllDocumentsEventArgs(bool allowSaveDialog)
    {
      _allowSaveDialog = allowSaveDialog;
    }

    bool _allowSaveDialog = true;
    public bool AllowSaveDialog
    {
      get { return _allowSaveDialog; }
    }

    bool _cancel = false;
    public bool Cancel
    {
      get { return _cancel; }
      set { _cancel = value; }
    }
  }
}
