   M S B A M L   `   `   `  ���� b  ^Xceed.Wpf.AvalonDock.Themes.DarkConcept, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Xceed.Wpf.AvalonDock.ThemesXceed.Wpf.AvalonDock.Themes  O KXceed.Wpf.AvalonDock, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null_Cclr-namespace:Microsoft.Windows.Shell;assembly=Xceed.Wpf.AvalonDockMicrosoft.Windows.Shell Y@clr-namespace:Xceed.Wpf.AvalonDock;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock gGclr-namespace:Xceed.Wpf.AvalonDock.Layout;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Layout kIclr-namespace:Xceed.Wpf.AvalonDock.Controls;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Controls oKclr-namespace:Xceed.Wpf.AvalonDock.Converters;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Converters oKclr-namespace:Xceed.Wpf.AvalonDock.Properties;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Properties \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source?   9Xceed.Wpf.AvalonDock.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterF  @Xceed.Wpf.AvalonDock.Converters.InverseBoolToVisibilityConverter $  InverseBoolToVisibilityConverterF  @Xceed.Wpf.AvalonDock.Converters.AnchorSideToOrientationConverter $  AnchorSideToOrientationConverter@  :Xceed.Wpf.AvalonDock.Converters.AnchorSideToAngleConverter  AnchorSideToAngleConverter>  8Xceed.Wpf.AvalonDock.Converters.NullToDoNothingConverter  NullToDoNothingConverterH  BXceed.Wpf.AvalonDock.Converters.LayoutItemFromLayoutModelConverter & "LayoutItemFromLayoutModelConverterW  QXceed.Wpf.AvalonDock.Converters.ActivateCommandLayoutItemFromLayoutModelConverter 5 1ActivateCommandLayoutItemFromLayoutModelConverter * &AvalonDock_DarkConcept_ToolButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType & "AvalonDock_DarkConcept_ButtonStyle 5	 1AvalonDock_DarkConcept_AnchorablePaneControlStyle?  9Xceed.Wpf.AvalonDock.Controls.LayoutAnchorablePaneControl 
 DarkTheme_MainColor J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   TabNavigation � RowDefinitions	 ��Name * &DarkTheme_DockingLayoutBackgroundColor
   DirectionalNavigation   TabIndex ��Name:	  4Xceed.Wpf.AvalonDock.Controls.AnchorablePaneTabPanel 	 Name K� IsItemsHost K� ZIndex �� Triggers P� Property P� Value �� Value �� Binding �� RelativeSource �� 
TargetName * &DarkTheme_ITemContainerBackgroundColor �� Mode  DarkTheme_LightGray �� Padding �� AncestorType  DarkTheme_LayoutSelectColor ]� 
Conditions �� Property �� Value  DarkTheme_BaseColor4 �� Triggers �� Mode �� Path;
  5Xceed.Wpf.AvalonDock.Controls.LayoutAnchorableTabItem  
  Model;  5Xceed.Wpf.AvalonDock.Controls.LayoutAnchorableControl!   Model 3 /AvalonDock_DarkConcept_DocumentPaneControlStyle=  7Xceed.Wpf.AvalonDock.Controls.LayoutDocumentPaneControl" � ColumnDefinitions8  2Xceed.Wpf.AvalonDock.Controls.DocumentPaneTabPanel#  Name2  ,Xceed.Wpf.AvalonDock.Controls.DropDownButton$  Name%   DropDownContextMenu1  +Xceed.Wpf.AvalonDock.Controls.ContextMenuEx.  (Xceed.Wpf.AvalonDock.Controls.MenuItemEx& �� BasedOn' �� 	Converter( P� 
SourceName) �� CornerRadius  DarkTheme_PanelBorderBrush  DarkTheme_Gray9  3Xceed.Wpf.AvalonDock.Controls.LayoutDocumentTabItem*   Model9  3Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl+   Model)  #Xceed.Wpf.AvalonDock.DockingManager,   LayoutRootPanel-   RightSidePanel.   LeftSidePanel/   TopSidePanel0   BottomSidePanel1   AutoHideWindow7  1Xceed.Wpf.AvalonDock.Controls.AnchorablePaneTitle2   Model3 ^� 
Conditions4 �� Binding<  6Xceed.Wpf.AvalonDock.Controls.LayoutGridResizerControl5 �� ShowsPreview  DarkTheme_MainSpliter7  1Xceed.Wpf.AvalonDock.Controls.DropDownControlArea6   DropDownContextMenu%7   DropDownContextMenuDataContext  DarkTheme_White/  )Xceed.Wpf.AvalonDock.Properties.Resources8   Anchorable_CxMenu_Hint9 � ToolTip%:   DropDownContextMenuDataContext; ��Name< ��Name"=   Anchorable_BtnAutoHide_Hint>   Anchorable_BtnClose_Hint? �� Angle@   Document_Close 0 ,AvalonDock_DarkConcept_DocumentTitleTemplate 2 .AvalonDock_DarkConcept_AnchorableTitleTemplate 1 -AvalonDock_DarkConcept_DocumentHeaderTemplate�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     9localThemes)clr-namespace:Xceed.Wpf.AvalonDock.Themes  MshellCclr-namespace:Microsoft.Windows.Shell;assembly=Xceed.Wpf.AvalonDock  O
avalonDock@clr-namespace:Xceed.Wpf.AvalonDock;assembly=Xceed.Wpf.AvalonDock  \avalonDockLayoutGclr-namespace:Xceed.Wpf.AvalonDock.Layout;assembly=Xceed.Wpf.AvalonDock  `avalonDockControlsIclr-namespace:Xceed.Wpf.AvalonDock.Controls;assembly=Xceed.Wpf.AvalonDock  davalonDockConvertersKclr-namespace:Xceed.Wpf.AvalonDock.Converters;assembly=Xceed.Wpf.AvalonDock  davalonDockPropertiesKclr-namespace:Xceed.Wpf.AvalonDock.Properties;assembly=Xceed.Wpf.AvalonDock    �� $ Brushes.xaml?�%~%  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 �     &		 q    &	 	    7  7m�7  '  �    7  7 	 '      '  o    '  �    7  7  7   7  7   '  !    7 �&	 o#    &	 �#    &	 Q$                   �� " d�.���  � ��
 ���� ��  � ��$ 1q���  � ��
 ���� ��  � ��$ 0q���  � �� �� " d�.R��� #��z��#��z��#��z��._��� �� " ��.���  � ��
 ���� ��  � ��$ 1q���  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��#��z��._��� �� "  .���  �@��TabStripPlacement$ Bottom=���  � ��$ 0q���  � ��$ 0q���  � ��# � 
 ��  � ��# � 
 ��  � �� �� "  .R�� }�.  . $ Local=�$��5q� �� $��* ��� $
��Auto �.+��� 
������ $��2���� $	 ContentPanel��#��z��#��z��#���  $��0��$
 	Contained=�$��0��$ 2��$ Cycle=�._��� $ PART_SelectedContentHost��$��SelectedContent��#��z��# z 	  $ HeaderPanel��$��0,0,0,2q� . $��1��$ 1��$ 1�� P�  � {� .  . ��� # � �� � ���� $ 1�� �� *Items.Count+ �� *Self+.a��� $ HeaderPanel�� � ��$ 0q���  � �� �� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��# �  ��  �@��
IsSelected �� *
IsSelected+$ TwoWay=���  �@�ToolTip �� *	ToolTip+��  � �� �� " ��.R��  . .+��� $	 Bd��$��1,0,0,0q�#���  $ 6,0,6,0q�._��� $ Content��$��Header��$��5q���. # z ���� *HorizontalContentAlignment+ �� " ������ *VerticalContentAlignment+ �� " �� P�  �@��
IsSelected . . ��� # �   � ����  �@K�ZIndex$ 1��P�  �@��
IsSelected . . ��� $ Bd��# �   � ���� $
 True�� �� *
IsActive+.a��� # �   � ��]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected .  ./��� # �   � ����  �@K�ZIndex$ 0��P�  � {� .  . ��� # � �� � �� ��  ��  �� $ FindAncestor=�" ��$ Items.Count� 1.a���  � y�$ 	Collapsed=���  � �� �� .R�
    �� ��  �@��ContentTemplate �� .R�  ! �� �� "  .���  � �� Z� ��  � �� �� "  .R�� }�.  . $ Local=�$��5q� �� $
��Auto ��� $��* �.+�� $ 1��" �� �� $
��Auto �.+�  $# HeaderPanel��$��0�� . $��0��$ 1��  $$ MenuDropDownButton��8��  |�.  $��Center=�$��1��%   ���� *Model.ChildrenSorted+ �� *TemplatedParent+���� "  8&  .���  � �� �� $5 /Root.Manager.DocumentPaneMenuItemHeaderTemplate���  � �� �� $= 7Root.Manager.DocumentPaneMenuItemHeaderTemplateSelector���  �@ IconTemplate �� $&  Root.Manager.IconContentTemplate���  �@ IconTemplateSelector �� $. (Root.Manager.IconContentTemplateSelector���  �@m�Command �� $ .�8'  .���� $��Images/PinDocMenu.png���� $	 ContentPanel��$��Stretch=�$��Stretch=�#��z��#��z�����	#FF595959$��0��$
 	Contained=�$��1��$ 2��$ Cycle=�._��� $ PART_SelectedContentHost��$��SelectedContent��$��0q�# z  P� $( MenuDropDownButton�� �@J�IsMouseOver . . ��� $ MenuDropDownButton�� � �� �� $��Images/PinDocMenu.png��P� $( MenuDropDownButton�� �@d�	IsChecked$
 TrueY�. ��� $ MenuDropDownButton�� � �� �� $��Images/PinDocMenu.png��P�  � {� .  . ��� # � �� � ���� $ 0�� ��  �� $
 Self=�$ Model.ChildrenCount�.a��� $ MenuDropDownButton�� � y�$ 	Collapsed=���  � �� �� " ��.���  �@��
IsSelected �� *
IsSelected+$ TwoWay=���  � ��
 ���� ��  � ��
 ���� ��  � ��# �  ��  �@�ToolTip �� *	ToolTip+��  � ��$ 0q���  � ��$ 1,0,1,0q���  � �� �� " ��.R��  . $��0q�.+��� $	 Bd��$) 5,5,0,0��#���  #���  $��1q�$	��130���� $ Content��$��2q�$��Header��$
��Left=���. # z ���� *VerticalContentAlignment+ �� " �� P�  �@��
IsSelected . . ���  � �� �#969146��  �@K�ZIndex$ 1����  � ��
 ��� ��� $
 True�� �� *
IsActive+.a���  � �� �#311008�� # �   � ����  �@K�ZIndex$ 1��P�  �@��
IsSelected . . ��� $ Bd��# �   � ��]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected .  ./���  � �� �#000000�� # �   � ����  �@K�ZIndex$ 0��P�  � {� .  . ��� # � �� � ����  � �� �� .R�  * �� ��  �@��ContentTemplate �� .R�  + �� �� "  .���  � ��# � 
 ��   �@ DocumentPaneControlStyle8   �� " �@ AnchorablePaneControlStyle8  ��  �@ GridSplitterWidth$ 5Q���  �@ GridSplitterHeight$ 5Q���  � �� �� "  .R��� #��z��#��z��#��z��._��  �� $
��Auto ��� $��* ��� $
��Auto �" �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��z, $��1��$��1���� #��z- $��2��$��1���� #��z. $��0��$��1���� #��z/ $��1��$��0���� #��z0 $��1��$��2���� $ PART_AutoHideArea��#��z1 #��z��#��z��$��1��$��1���� "  .���  � �� �� "  .R��� $	 Bd��
������ #��z��#��z��._��  �� $
��Auto ��� $��* �.+��� $	 Header��$	��200��$
��Left=�#���  $��1,1,1,0q�$) 5,5,0,0��#���  ._�  2 �� *Model+ �� *TemplatedParent+�� $	 Content��$��1��#���  #���  $��1q�._��� #��z������ *LayoutItem.View+ �� *TemplatedParent+ ^� 3 �� 4 ��  �� *Self+$ Model.IsFloating� True�� 4 ��  �� *Self+$3 -Model.Parent.IsDirectlyHostedInFloatingWindow� True.0��� $ Header�� � y�$ 	Collapsed=��� "  .���  � ��
 �������  � �� �� "  .R��� $��Stretch=�$��Stretch=�5 . #���  �� "  .���  � �� �� .R��� #��z��#��z��#��z��$) 5,5,0,0��$ 1q�._�� " �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�  6 �� **(Model.Root.Manager.AnchorableContextMenu+ �� *TemplatedParent+7 �� $ 
LayoutItem� �� *TemplatedParent+.���� $ Header��$��5,0,0,0q�#���  $��Center=�$
��Left=����� *Model+ �� *TemplatedParent+���� *,*Model.Root.Manager.AnchorableTitleTemplate+ �� *TemplatedParent+���� *42Model.Root.Manager.AnchorableTitleTemplateSelector+ �� *TemplatedParent+  $$ MenuDropDownButton��$��Center=�8��  |�.  $��1��#9 Z8 % �� **(Model.Root.Manager.AnchorableContextMenu+ �� *TemplatedParent+: �� $ 
LayoutItem� �� *TemplatedParent+.���� $; PART_ImgMenuPin��$��Images/PinMenu.png���� $< PART_AutoHidePin��$��2��|�.  8�� $��Center=�$��Center=�#9 Z= ���� $  LayoutItem.AutoHideCommand� �� *TemplatedParent+y��� $ 	IsEnabled� �� *Self+$ OneWay=�8'  .���� $; PART_ImgAutoHidePin��$��Images/PinAutoHide.png���� $< PART_HidePin��$��3��|�.  8�� $��Center=�$��Center=�#9 Z> ���� $ LayoutItem.HideCommand� �� *TemplatedParent+y��� $ 	IsEnabled� �� *Self+$ OneWay=�8'  .���� $; PART_ImgHidePin��$��Images/PinClose.png�� �� $
 True�� �� *Model.IsAutoHidden+ �� $
 Self=�.a��� $ PART_AutoHidePin�� �@�LayoutTransform �� $? 90Q��� $
 True�� �� *Model.IsActive+ �� $
 Self=�.a��� # �   � ��P� $( MenuDropDownButton�� �@J�IsMouseOver . . ��� $ PART_ImgMenuPin�� � ��$ Images/PinMenu.png��P� $( MenuDropDownButton�� �@d�	IsChecked$
 TrueY�. ��� $ PART_ImgMenuPin�� � ��$ Images/PinMenu.png��P� $( PART_AutoHidePin�� �@J�IsMouseOver . . ��� $ PART_ImgAutoHidePin�� � ��$ Images/PinAutoHide.png��P� $( PART_HidePin�� �@J�IsMouseOver . . ��� $ PART_ImgHidePin�� � ��$ Images/PinClose.png���� "  .���  � �� �� "  .R�  6 �� *" Root.Manager.DocumentContextMenu+7 �� *
LayoutItem+ �� *TemplatedParent+.���� 
������ #��z��._�� " �� $��* ��� $
��Auto �.+��� $��2��
������ �� #���  $��90��$��5,0,0,0q�$��Center=�$��Center=����� *Model+ �� *TemplatedParent+���� *DocumentHeaderTemplate+$ OneWay=� �� "  $ FindAncestor=����� * DocumentHeaderTemplateSelector+$ OneWay=� �� "  $ FindAncestor=��� $< DocumentCloseButton��8��  $��1��$��5,0,0,0q�$y�Hidden=�#9 Z@ ���� $ LayoutItem.CloseCommand� �� *TemplatedParent+.���� $H��B/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinClose.png�� �� $
 true�� �� $ 
IsSelected�.a��� $ DocumentCloseButton�� � y�$ Visible=�P�  �@J�IsMouseOver . . ��� $ DocumentCloseButton�� � y�$ Visible=��� $ false�� �� $ CanClose�.a��� $ DocumentCloseButton�� � y�$ 	Collapsed=��� $
 True�� �� *Model.IsActive+ �� $
 Self=��� .R��� $��CharacterEllipsis=�$��Center=�$��15(�$
��Bold"�$��Center=�
���   ����� *Title+�� .R��� $��CharacterEllipsis=�$��Center=�$��15(�$
��Bold"�$��Center=�
���   ����� *Title+�� .R��� $��CharacterEllipsis=�
����������� *Title+