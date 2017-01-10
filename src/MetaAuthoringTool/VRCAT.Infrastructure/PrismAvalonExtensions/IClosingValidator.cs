using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRCAT.Infrastructure.PrismAvalonExtensions
{
  public interface IClosingValidator
  {
    /// <summary>
    /// CloseValidator Interface
    /// </summary>
    bool OnClosing();
    bool IsDirty { get; }
  }
}
