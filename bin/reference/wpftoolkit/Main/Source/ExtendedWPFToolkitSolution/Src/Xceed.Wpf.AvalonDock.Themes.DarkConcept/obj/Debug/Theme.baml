   M S B A M L   `   `   `  ����b  ^Xceed.Wpf.AvalonDock.Themes.DarkConcept, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Xceed.Wpf.AvalonDock.ThemesXceed.Wpf.AvalonDock.Themes  5      O KXceed.Wpf.AvalonDock, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null_Cclr-namespace:Microsoft.Windows.Shell;assembly=Xceed.Wpf.AvalonDockMicrosoft.Windows.Shell 5      Y@clr-namespace:Xceed.Wpf.AvalonDock;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock 5      gGclr-namespace:Xceed.Wpf.AvalonDock.Layout;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Layout 5      kIclr-namespace:Xceed.Wpf.AvalonDock.Controls;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Controls 5      oKclr-namespace:Xceed.Wpf.AvalonDock.Converters;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Converters 5	      oKclr-namespace:Xceed.Wpf.AvalonDock.Properties;assembly=Xceed.Wpf.AvalonDockXceed.Wpf.AvalonDock.Properties 5
      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source?   9Xceed.Wpf.AvalonDock.Converters.BoolToVisibilityConverter   BoolToVisibilityConverterF  @Xceed.Wpf.AvalonDock.Converters.InverseBoolToVisibilityConverter $  InverseBoolToVisibilityConverterF  @Xceed.Wpf.AvalonDock.Converters.AnchorSideToOrientationConverter $  AnchorSideToOrientationConverter@  :Xceed.Wpf.AvalonDock.Converters.AnchorSideToAngleConverter  AnchorSideToAngleConverter>  8Xceed.Wpf.AvalonDock.Converters.NullToDoNothingConverter  NullToDoNothingConverterH  BXceed.Wpf.AvalonDock.Converters.LayoutItemFromLayoutModelConverter & "LayoutItemFromLayoutModelConverterW  QXceed.Wpf.AvalonDock.Converters.ActivateCommandLayoutItemFromLayoutModelConverter 5 1ActivateCommandLayoutItemFromLayoutModelConverter * &AvalonDock_DarkConcept_ToolButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType & "AvalonDock_DarkConcept_ButtonStyle 5	 1AvalonDock_DarkConcept_AnchorablePaneControlStyle?  9Xceed.Wpf.AvalonDock.Controls.LayoutAnchorablePaneControl 
 DarkTheme_MainColor J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   TabNavigation � RowDefinitions	 ��Name * &DarkTheme_DockingLayoutBackgroundColor
   DirectionalNavigation   TabIndex ��Name:	  4Xceed.Wpf.AvalonDock.Controls.AnchorablePaneTabPanel 	 Name K� IsItemsHost K� ZIndex �� Triggers P� Property P� Value �� Value �� Binding �� RelativeSource �� 
TargetName * &DarkTheme_ITemContainerBackgroundColor �� Mode  DarkTheme_LightGray �� Padding �� AncestorType  DarkTheme_LayoutSelectColor ]� 
Conditions �� Property �� Value  DarkTheme_BaseColor4 �� Triggers �� Mode �� Path;
  5Xceed.Wpf.AvalonDock.Controls.LayoutAnchorableTabItem  
  Model;  5Xceed.Wpf.AvalonDock.Controls.LayoutAnchorableControl!   Model 3 /AvalonDock_DarkConcept_DocumentPaneControlStyle=  7Xceed.Wpf.AvalonDock.Controls.LayoutDocumentPaneControl" � ColumnDefinitions8  2Xceed.Wpf.AvalonDock.Controls.DocumentPaneTabPanel#  Name2  ,Xceed.Wpf.AvalonDock.Controls.DropDownButton$  Name%   DropDownContextMenu1  +Xceed.Wpf.AvalonDock.Controls.ContextMenuEx.  (Xceed.Wpf.AvalonDock.Controls.MenuItemEx& �� BasedOn' �� 	Converter( P� 
SourceName) �� CornerRadius  DarkTheme_PanelBorderBrush  DarkTheme_Gray9  3Xceed.Wpf.AvalonDock.Controls.LayoutDocumentTabItem*   Model9  3Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl+   Model)  #Xceed.Wpf.AvalonDock.DockingManager,   LayoutRootPanel-   RightSidePanel.   LeftSidePanel/   TopSidePanel0   BottomSidePanel1   AutoHideWindow7  1Xceed.Wpf.AvalonDock.Controls.AnchorablePaneTitle2   Model3 ^� 
Conditions4 �� Binding<  6Xceed.Wpf.AvalonDock.Controls.LayoutGridResizerControl5 �� ShowsPreview  DarkTheme_MainSpliter7  1Xceed.Wpf.AvalonDock.Controls.DropDownControlArea6   DropDownContextMenu%7   DropDownContextMenuDataContext  DarkTheme_White/  )Xceed.Wpf.AvalonDock.Properties.Resources8   Anchorable_CxMenu_Hint9 � ToolTip%:   DropDownContextMenuDataContext; ��Name< ��Name"=   Anchorable_BtnAutoHide_Hint>   Anchorable_BtnClose_Hint? �� Angle@   Document_Close 0 ,AvalonDock_DarkConcept_DocumentTitleTemplate 2 .AvalonDock_DarkConcept_AnchorableTitleTemplate 1 -AvalonDock_DarkConcept_DocumentHeaderTemplate�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      9localThemes)clr-namespace:Xceed.Wpf.AvalonDock.Themes  5      MshellCclr-namespace:Microsoft.Windows.Shell;assembly=Xceed.Wpf.AvalonDock  5      O
avalonDock@clr-namespace:Xceed.Wpf.AvalonDock;assembly=Xceed.Wpf.AvalonDock  5      \avalonDockLayoutGclr-namespace:Xceed.Wpf.AvalonDock.Layout;assembly=Xceed.Wpf.AvalonDock  5      `avalonDockControlsIclr-namespace:Xceed.Wpf.AvalonDock.Controls;assembly=Xceed.Wpf.AvalonDock  5      davalonDockConvertersKclr-namespace:Xceed.Wpf.AvalonDock.Converters;assembly=Xceed.Wpf.AvalonDock  5	      davalonDockPropertiesKclr-namespace:Xceed.Wpf.AvalonDock.Properties;assembly=Xceed.Wpf.AvalonDock  5
        5      �� 5      $ Brushes.xaml?�6   %�<  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �    &		 9    &	 �    7  7m�7  '  �    7  7 	 '  �"    '  �&    '  �'    7  7  7   7  7   '  �3    7 �&	 �9    &	 �:    &	 R;       5      62     5      69     5      69     5      63     5      61     5      6;     5      6J   �� 5      " d�68   .�5      ��  � ��
 ���� 6!   �� 5       � ��$ 1q�6&   �� 5       � ��
 ���� 6"   �� 5       � ��$ 0q�6   �� 5       � �� 5      �� 5      " d�6   .R�5       �� #��z��6   #��z��5!      #��z��5"      ._�5#      �� 5$      5%      5'      5(      �� 5*      " ��64   .�5+      ��  � ��
 ���� 6!   �� 5,       � ��$ 1q�6&   �� 5-       � ��
 ���� 6"   �� 5.       � ��$ 0q�6   �� 5/       � �� 50      �� 51      " ��6   .R�52      �� #��z��6   #��z��53      #��z��54      ._�55      �� 56      57      59      5:      �� 5<      "  6C   .�5=      ��  �@��TabStripPlacement$ Bottom=�6(   �� 5>       � ��$ 0q�6   �� 5?       � ��$ 0q�6&   �� 5B       � ��# � 
 6!   �� 5C       � ��# � 
 6!   �� 5D       � �� 5E      �� 5F      "  6   .R�5G      � }�.  . $ Local=�6;   $��5q�6d    5H      �� 5I   	   $��* �6   �� 5J   	   $
��Auto �6   .+�5M      �� 
������ $��2��6(   �� 5N      $	 ContentPanel��6   #��z��5O   !   #��z��5P   !   #���  5Q   !   $��0��5R   !   $
 	Contained=�5S   !   $��0��5T   !   $ 2��5U   !   $ Cycle=�5V   !   ._�5W   	   �� $ PART_SelectedContentHost��6   $��SelectedContent��5X   /   #��z��5Y   /   # z 5Z   /   5[   	   	  5\      $ HeaderPanel��62   $��0,0,0,2q�6G    . $��1��6k   $ 1��6x   $ 1��6�   5]       5^      P� 5_       � {� .  . �5`   	   �� # � ��6&    � ��5a   	   �� 5b      $ 1��6Z    6   �� *Items.Count+ �� *Self+.a�5c   	   �� $ HeaderPanel��6,    � ��$ 0q�6"   6,   5d   	   5f      5h      �� 5j       � �� 5k      �� 5l      " ��6   .�5m      ��  � ��
 ���� 6$   �� 5n       � ��
 ���� 6%   �� 5o       � ��# �  6$   �� 5p       �@��
IsSelected 6$   �� *
IsSelected+$ TwoWay=��� 5q       �@�ToolTip 6!   �� *	ToolTip+�� 5r       � �� 5s      �� 5t   	   " ��6   .R�5u   
   �  . .+�5v      �� $	 Bd��6   $��1,0,0,0q�5w   +   #���  5x      $ 6,0,6,0q�5y      ._�5z      �� $ Content��5{      $��Header��5|      $��5q�5}   -   ��. # z 5�   -   ��5~   -   �� *HorizontalContentAlignment+ �� " ����5   -   �� *VerticalContentAlignment+ �� " ��5�   -   5�      5�       5�   
   P� 5�       �@��
IsSelected . . �5�      �� # �  5�       � ���� 5�       �@K�ZIndex$ 1��5�   -   5�      P� 5�   &    �@��
IsSelected . . �5�   *   �� $ Bd��61   # �  6W    � ��5�   '   �� 5�      $
 True��64    6   �� *
IsActive+.a�5�      �� # �  5�       � ��5�      ]� 5�       5�      �� 5�       �@J�IsMouseOver . 6.   �� 5�       �@��
IsSelected .  66   ./�5�      �� # �  6*    � ���� 5�       �@K�ZIndex$ 0��6+   5�      P� 5�       � {� .  . �5�      �� # � ��6)    � ��5�      5�   
   5�       5�      �� 5�       6   ��  �� $ FindAncestor=�" ��$ Items.Count� 16�   .a�5�   	   ��  � y�$ 	Collapsed=�6&   5�   	   5�      5�      �� 5�       � �� 5�      �� 5�      .R�5�      
    62   �� 5�      5�      �� 5�       �@��ContentTemplate 5�      �� 5�      .R�5�        ! 62   �� 5�      5�      5�      �� 5�      "  6D   .�5�   
   ��  � �� 6(   Z� �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � }�.  . $ Local=�6J   $��5q�6s    5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      � $ 1��6    " 5�      �� 5�   "   �� 5�   "   $
��Auto �63   .+�5�        $# HeaderPanel��6F   $��0��6[    . $��0��6~   $ 1��6�     5�      $$ MenuDropDownButton��5�   !   8��  |�.  $��Center=�5�   !   $��1��5�   !   % 5�   "     5�   &   ��5�   )   �� *Model.ChildrenSorted+ �� *TemplatedParent+��5�   *   �� 5�   .   "  64   8&  .�5�   2   ��  � �� 6S   �� $5 /Root.Manager.DocumentPaneMenuItemHeaderTemplate��� 5�   2    � �� 6[   �� $= 7Root.Manager.DocumentPaneMenuItemHeaderTemplateSelector��� 5�   2    �@ IconTemplate 6Q   �� $&  Root.Manager.IconContentTemplate��� 5�   2    �@ IconTemplateSelector 6Y   �� $. (Root.Manager.IconContentTemplateSelector��� 5�   2    �@m�Command 6L   �� $ .�8'  5�   /   5�   '   .��5�   "   �� $��Images/PinDocMenu.png��6(   5�      5�      �� 5�      $	 ContentPanel��6!   $��Stretch=�5�   !   $��Stretch=�5�   !   #��z��5�   !   #��z��5�   !   ���	#FF595959$��0��5�   !   $
 	Contained=�5�   !   $��1��5�   !   $ 2��5�   !   $ Cycle=�5�   !   ._�5�      �� $ PART_SelectedContentHost��6/   $��SelectedContent��5�   /   $��0q�5�   /   # z 5�   /   5�      5�       5�      P� 5�      $( MenuDropDownButton��69    �@J�IsMouseOver . . �5�      �� $ MenuDropDownButton��68    � �� 5�   "   �� 5   &   $��Images/PinDocMenu.png��6,   5     5     P� 5     $( MenuDropDownButton��67    �@d�	IsChecked$
 TrueY�6W   . �5     �� $ MenuDropDownButton��68    � �� 5  "   �� 5  &   $��Images/PinDocMenu.png��6,   5	     5
     P� 5      � {� .  . �5     �� # � ��6;    � ��5     �� 5     $ 0��6~    6&   ��  �� $
 Self=�$ Model.ChildrenCount�.a�5     �� $ MenuDropDownButton��6M    � y�$ 	Collapsed=�6;   6M   5     5     5     �� 5  
    � �� 5     �� 5     " ��6   .�5     ��  �@��
IsSelected 63   �� *
IsSelected+$ TwoWay=��� 5      � ��
 ���� 63   �� 5      � ��
 ���� 64   �� 5      � ��# �  63   �� 5      �@�ToolTip 60   �� *	ToolTip+�� 5      � ��$ 0q�60   �� 5      � ��$ 1,0,1,0q�6/   �� 5      � �� 5      �� 5!     " ��6.   .R�5"  "   �  . $��0q�5#  (   .+�5$  &   �� $	 Bd��6-   $) 5,5,0,0��5%     #���  5&  +   #���  5'  +   $��1q�5(  "   $	��130��5)  +   5+  '   �� 5,  &   $ Content��5-     $��2q�5.  -   $��Header��5/     $
��Left=�50  -   ��. # z 53  -   ��51  -   �� *VerticalContentAlignment+ �� " ��53  -   54  #    55  "   P� 56  &    �@��
IsSelected . . �58  *   ��  � �� �#96914659     �� 5:  *    �@K�ZIndex$ 1��5;  -   �� 5<  *    � ��
 ��� �5=  1   5>  '   �� 5@  &   $
 True��6O    62   �� *
IsActive+.a�5A  *   ��  � �� �#3110086H   �� 5B  *   # �  6G    � ���� 5C  *    �@K�ZIndex$ 1��5D  -   5E  '   P� 5F  &    �@��
IsSelected . . �5G  *   �� $ Bd��61   # �  6W    � ��5H  '   ]� 5I  &    5J  *   �� 5K  .    �@J�IsMouseOver . 6O   �� 5L  .    �@��
IsSelected .  6W   ./�5N  *   ��  � �� �#0000006H   �� 5O  *   # �  6G    � ���� 5P  *    �@K�ZIndex$ 0��6I   5Q  '   P� 5R  &    � {� .  . �5S  *   �� # � ��6G    � ��5T  '   5V     5X     5Y     5[     �� 5\  
    � �� 5]     �� 5^     .R�5_       * 6?   �� 5`     5b     �� 5d  
    �@��ContentTemplate 5e     �� 5f     .R�5g       + 6?   �� 5h     5j     5k     �� 5m     "  67   .�5n     ��  � ��# � 
 6!   �� 5o       �@ DocumentPaneControlStyle8   6/   �� 5p     " �@ AnchorablePaneControlStyle8  61   �� 5|      �@ GridSplitterWidth$ 5Q�6(   �� 5}      �@ GridSplitterHeight$ 5Q�6)   �� 5~      � �� 5     �� 5�     "  6   .R�5�     �� #��z��6   #��z��5�     #��z��5�     ._�5�     �  5�  	   �� 5�  
   $
��Auto �6   �� 5�  
   $��* �6   �� 5�  
   $
��Auto �6   " 5�  	   �� 5�  
   $
��Auto �6   �� 5�  
   $��* �6   �� 5�  
   $
��Auto �6   .+�5�  	   �� #��z, 6   $��1��6F   $��1��6V   �� 5�  	   #��z- 6   $��2��6E   $��1��6U   �� 5�  	   #��z. 6   $��0��6D   $��1��6T   �� 5�  	   #��z/ 6   $��1��6C   $��0��6S   �� 5�  	   #��z0 6   $��1��6F   $��2��6V   �� 5�  	   $ PART_AutoHideArea��5�  !   #��z1 5�  !   #��z��5�  !   #��z��5�  !   $��1��5�  !   $��1��61   5�  	   5�     5�     5�     5�     �� 5�     "  6	   .�5�     ��  � �� 5�     �� 5�     "  6   .R�5�     �� $	 Bd��5�     
������ #��z��5�     #��z��5�     ._�5�     �  5�  	   �� 5�  
   $
��Auto �6   �� 5�  
   $��* �6   .+�5�  	   �� $	 Header��6   $	��200��5�  %   $
��Left=�61   #���  6L   $��1,1,1,0q�6�   $) 5,5,0,0��6�   #���  5�  !   ._�5�  
     2 5�  %   �� *Model+ �� *TemplatedParent+5�  
   �� 5�     $	 Content��6   $��1��6(   #���  65   #���  6c   $��1q�6�   ._�5�  	   �� #��z��5�  !   ��5�  !   �� *LayoutItem.View+ �� *TemplatedParent+5�     5�  	   5�      5�     ^� 5�     3 5�  	   �� 5�  
   4 6   ��  �� *Self+$ Model.IsFloating� True6d   �� 5�  
   4 6   ��  �� *Self+$3 -Model.Parent.IsDirectlyHostedInFloatingWindow� True6�   .0�5�  	   �� $ Header��68    � y�$ 	Collapsed=�6&   68   5�  	   5�     5�     5�     �� 5�     "  6F   .�5�     ��  � ��
 �����6!   �� 5�      � �� 5�     �� 5�     "  6   .R�5�     �� $��Stretch=�6#   $��Stretch=�6A   5 . #���  6q   5�     5�     5�     �� 5�     "  6	   .�5�     ��  � �� 5�     �� 5�     .R�5�     �� #��z��6   #��z��5�     #��z��5�     $) 5,5,0,0��5�     $ 1q�5�     ._�5�     � " 5�  	   �� 5�  
   $��* �6   �� 5�  
   $
��Auto �6   �� 5�  
   $
��Auto �6   �� 5�  
   $
��Auto �6   .+�5�  	     6 5�  !   �� **(Model.Root.Manager.AnchorableContextMenu+ �� *TemplatedParent+7 5�  !   �� $ 
LayoutItem� �� *TemplatedParent+.��5�  
   �� $ Header��5�  %   $��5,0,0,0q�5�  %   #���  5�  %   $��Center=�5�  %   $
��Left=�5�  %   ��5�  %   �� *Model+ �� *TemplatedParent+��5�  %   �� *,*Model.Root.Manager.AnchorableTitleTemplate+ �� *TemplatedParent+��5�  %   �� *42Model.Root.Manager.AnchorableTitleTemplateSelector+ �� *TemplatedParent+5�  
     5�  	   $$ MenuDropDownButton��5�  !   $��Center=�5�  !   8��  |�.  $��1��5  !   #9 Z8 5  !   % 5  !   �� **(Model.Root.Manager.AnchorableContextMenu+ �� *TemplatedParent+: 5  !   �� $ 
LayoutItem� �� *TemplatedParent+.��5  
   �� $; PART_ImgMenuPin��6   $��Images/PinMenu.png��6)   5  
   �� 5	  	   $< PART_AutoHidePin��6   $��2��5
  !   |�.  8�� $��Center=�5  !   $��Center=�5  !   #9 Z= 5  !   ��5  !   �� $  LayoutItem.AutoHideCommand� �� *TemplatedParent+y�5  !   �� $ 	IsEnabled� �� *Self+$ OneWay=�8'  .��5  
   �� $; PART_ImgAutoHidePin��6   $��Images/PinAutoHide.png��6-   5  
   �� 5  	   $< PART_HidePin��6   $��3��5  !   |�.  8�� $��Center=�5  !   $��Center=�5  !   #9 Z> 5  !   ��5  !   �� $ LayoutItem.HideCommand� �� *TemplatedParent+y�5  !   �� $ 	IsEnabled� �� *Self+$ OneWay=�8'  .��5  
   �� $; PART_ImgHidePin��6   $��Images/PinClose.png��6)   5   
   5"  	   5#      5$     �� 5%     $
 True��6f    6   �� *Model.IsAutoHidden+ �� $
 Self=�.a�5&  	   �� $ PART_AutoHidePin��6+    �@�LayoutTransform 5'  
   �� 5(     $? 90Q�6   5*  
   5+  	   �� 5,     $
 True��6b    6   �� *Model.IsActive+ �� $
 Self=�.a�5-     �� # �  6;    � ��5/  	   P� 55     $( MenuDropDownButton��6'    �@J�IsMouseOver . . �56  	   �� $ PART_ImgMenuPin��6"    � ��$ Images/PinMenu.png��6?   57  	   P� 58     $( MenuDropDownButton��6%    �@d�	IsChecked$
 TrueY�6E   . �59  	   �� $ PART_ImgMenuPin��6"    � ��$ Images/PinMenu.png��6?   5:  	   P� 5;     $( PART_AutoHidePin��6'    �@J�IsMouseOver . . �5<  	   �� $ PART_ImgAutoHidePin��6"    � ��$ Images/PinAutoHide.png��6C   5=  	   P� 5>     $( PART_HidePin��6'    �@J�IsMouseOver . . �5?  	   �� $ PART_ImgHidePin��6"    � ��$ Images/PinClose.png��6?   5@  	   5B     5D     5E     �� 5G     "  6
   .�5H     ��  � �� 5I     �� 5J  
   "  6   .R�5K       6 5L     �� *" Root.Manager.DocumentContextMenu+7 5M     �� *
LayoutItem+ �� *TemplatedParent+.��5N     �� 
������ #��z��5O     ._�5Q     � " 5R     �� 5S     $��* �6%   �� 5T     $
��Auto �6%   .+�5V     �� $��2��6   
������ 6-   �� 5W     #���  5X  #   $��90��5Y  #   $��5,0,0,0q�5Z  #   $��Center=�5[  #   $��Center=�5\  #   ��5W  #   �� *Model+ �� *TemplatedParent+��5]  #   �� *DocumentHeaderTemplate+$ OneWay=� �� "  $ FindAncestor=���5^  #   �� * DocumentHeaderTemplateSelector+$ OneWay=� �� "  $ FindAncestor=��� 5`     $< DocumentCloseButton��6   8��  $��1��6q   $��5,0,0,0q�6�   $y�Hidden=�6�   #9 Z@ 5b  )   ��5a  )   �� $ LayoutItem.CloseCommand� �� *TemplatedParent+.��5c     �� $H��B/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinClose.png��6   5d     5e     5f     5g      5h     �� 5i     $
 true��6>    6   �� $ 
IsSelected�.a�5j     �� $ DocumentCloseButton��6=    � y�$ Visible=�6-   6=   5k     P� 5l      �@J�IsMouseOver . . �5m     �� $ DocumentCloseButton��6=    � y�$ Visible=�6-   6=   5n     �� 5o     $ false��6<    6   �� $ CanClose�.a�5p     �� $ DocumentCloseButton��6?    � y�$ 	Collapsed=�6-   6?   5q     �� 5r     $
 True��6h    6   �� *Model.IsActive+ �� $
 Self=�5t     5v     5x     5y     �� 5{     .R�5|     �� $��CharacterEllipsis=�6%   $��Center=�6F   $��15(�6a   $
��Bold"�6o   $��Center=�6�   
���   ���6   �� *Title+6�   5}     �� 5     .R�5�     �� $��CharacterEllipsis=�6%   $��Center=�6F   $��15(�6a   $
��Bold"�6o   $��Center=�6�   
���   ���6   �� *Title+6�   5�     �� 5�     .R�5�     �� $��CharacterEllipsis=�6%   
���������6   �� *Title+6F   5�     5�     