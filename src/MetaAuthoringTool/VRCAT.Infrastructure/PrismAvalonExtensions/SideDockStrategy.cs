﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace VRCAT.Infrastructure.PrismAvalonExtensions
{
    /// <summary>
    /// SideDock Position
    /// </summary>
    public enum DockSide
    {
        Left,
        Right,
        Top,
        Bottom
    }
    /// <summary>
    /// [사용안함]
    /// SideDockPosition Class
    /// </summary>
    /// <remarks>Side Dock 은 아직 미지원</remarks>
    public class SideDockStrategy : DockStrategy
    {
        public SideDockStrategy(DockSide side)
        {
            _side = side;
        }

        public SideDockStrategy(DockSide side, GridLength size)
        {
            _side = side;
            _size = size;
        }

        DockSide _side;
        public DockSide Side
        {
            get { return _side; }
            private set { _side = value; }
        }

        GridLength _size = new GridLength();
        public GridLength Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
