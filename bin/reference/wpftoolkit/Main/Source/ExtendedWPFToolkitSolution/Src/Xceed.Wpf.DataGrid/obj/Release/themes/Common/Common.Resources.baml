   M S B A M L   `   `   `  ���� Y  UXceed.Wpf.DataGrid, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47 clr-namespace:Xceed.Wpf.DataGridXceed.Wpf.DataGrid  M+clr-namespace:Xceed.Wpf.DataGrid.ConvertersXceed.Wpf.DataGrid.Converters  C&clr-namespace:Xceed.Wpf.DataGrid.ViewsXceed.Wpf.DataGrid.Views  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089>    8Xceed.Wpf.DataGrid.Converters.StringFormatMultiConverter   stringFormatMultiConverter  invisibleThumbStyle  �� 
TargetType �� Property �� Value �� 
TargetType ! detailsExpanderButtonTemplate ��Name �� RelativeSource �� Path �� Triggers(   "Xceed.Wpf.DataGrid.DataGridControl P� Property	 P� Value
 �� 
TargetName % !groupExpanderToggleButtonTemplate  defaultGroupTemplate �� Orientation `� 	Converter ��Name �� Triggers �� Value �� Binding  stickyGroupTemplate � 	Resources  Key/   )Xceed.Wpf.DataGrid.GroupNavigationControl  groupItemContentTemplate   MainItemTemplate   Group  parentGroupTemplate K� IsItemsHost $	  detailedGroupItemContentTemplate �� DataType   Xceed.Wpf.DataGrid.Group ��Name:   4Xceed.Wpf.DataGrid.Converters.TypeToBooleanConverter   	Singleton �� 	Converter �� ConverterParameter,   &Xceed.Wpf.DataGrid.Views.TableflowView.   (Xceed.Wpf.DataGrid.GroupLevelDescription:   4Xceed.Wpf.DataGrid.Converters.NullToBooleanConverter 
 nullToBooleanConverter8   2Xceed.Wpf.DataGrid.Converters.IntAdditionConverter  intAdditionConverter6	   0Xceed.Wpf.DataGrid.Converters.ThicknessConverter  thicknessConverterA
   ;Xceed.Wpf.DataGrid.Converters.EmptyStringToBooleanConverter ! emptyStringToBooleanConverter7   1Xceed.Wpf.DataGrid.Converters.SourceDataConverter  sourceDataConverter  cellPadding u� Left
 u� Top u� Right u� Bottom ) %defaultAutoFilteringCheckBoxItemStyle d� 	IsChecked �� Mode4  .System.Windows.Automation.AutomationProperties    AutomationId  connectionStateLoadingGlyph! �� Color" g� RepeatBehavior# g� 	BeginTime$ �� 
TargetName% �� TargetProperty& O� KeyTime' O� Value( �� KeyTime) �� Value* �Name+ F�Name, J� RenderTransformOrigin- J� Opacity. � ToolTip/ _�Name0 N� EnterActions1 ��Name  loadingStoryboard2 N� ExitActions3 �� BeginStoryboardName  connectionStateErrorGlyph  errorStoryboard�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     *local clr-namespace:Xceed.Wpf.DataGrid  3cnv+clr-namespace:Xceed.Wpf.DataGrid.Converters  0views&clr-namespace:Xceed.Wpf.DataGrid.Views  @scm8clr-namespace:System.ComponentModel;assembly=WindowsBase  %H   &	        &	      &	 h     &	 �    &	 �    7   &	 F    7   7   7  7  7  7 	 7  (��     *, +)7  7  (��     *, +)&	
 v    &	 {    &	 �    &	 �    &	 �    &	 �    &	 �    7  &	 �    7  &	 �    7     �� "  n�.���  � ��# � y���  � ��# � z���  � �� �� " n�.R�� 
������ �� " ��.R��� $ expanderGlyphPresenter����Z� ����  �� *Self+$@ :(local:DataGridControl.DataGridContext).CollapseGroupGlyph� P�  �@ HasExpandedDetails	 .  . ��� $
 expanderGlyphPresenter�� ��  �� *Self+$> 8(local:DataGridControl.DataGridContext).ExpandGroupGlyph� � ���� " d�.R��� $ expanderGlyphPresenter����Z� ����  �� *Self+$@ :(local:DataGridControl.DataGridContext).CollapseGroupGlyph� P�  �@d�	IsChecked$	 FalseY�. ��� $
 expanderGlyphPresenter�� ��  �� *Self+$> 8(local:DataGridControl.DataGridContext).ExpandGroupGlyph� � ���� .R��� $ 
Horizontal=�$��Center=�.+��� $��Center=����� *Title+����  �� *TemplatedParent+$ DataContext.TitleTemplate�����  �� *TemplatedParent+$' !DataContext.TitleTemplateSelector��� $��: ��$��Center=��� $��Center=�����  �� *TemplatedParent+$ DataContext.ValueTemplate�����  �� *TemplatedParent+$' !DataContext.ValueTemplateSelector���`� 8   .1��� $ Value��� $# DataContext.ValueStringFormat� �� *TemplatedParent+�� $* $DataContext.ValueStringFormatCulture� �� *TemplatedParent+�� $�� (��$��Center=��� $��Center=����� *	ItemCount+�� $�� ��$��Center=��� $ 	suffixRun��$��items��$��Center=��� $��)��$��Center=� �� $ 1�� �� *	ItemCount+.a��� $
 	suffixRun�� � ��$
 item����  ���� $ detailedGroupItemContentTemplate .R��� $ 
Horizontal=�$��Center=�.+��� $
��Bold"�$��Center=�����  �� *Self+$8 2(local:GroupNavigationControl.Group).ValueTemplate�����  �� *Self+$@ :(local:GroupNavigationControl.Group).ValueTemplateSelector���`� 8   .1��� $0 *(local:GroupNavigationControl.Group).Value� �� *Self+�� $< 6(local:GroupNavigationControl.Group).ValueStringFormat� �� *Self+�� $C =(local:GroupNavigationControl.Group).ValueStringFormatCulture� �� *Self+�� $�� (��$��Center=��� $��Center=����� *	ItemCount+�� $�� ��$��Center=��� $ 	suffixRun��$��items��$��Center=��� $��)��$��Center=� �� $ 1�� �� *	ItemCount+.a��� $
 	suffixRun�� � ��$
 item���� groupItemContentTemplate .R��� ����  �� *Self+$8 2(local:GroupNavigationControl.Group).ValueTemplate�����  �� *Self+$@ :(local:GroupNavigationControl.Group).ValueTemplateSelector���`� 8  .1��� $0 *(local:GroupNavigationControl.Group).Value� �� *Self+�� $< 6(local:GroupNavigationControl.Group).ValueStringFormat� �� *Self+�� $C =(local:GroupNavigationControl.Group).ValueStringFormatCulture� �� *Self+�� parentGroupTemplate .R�  8  8��  �� .R��� $ 
Horizontal=�.+��� 8�� |�.  ���� $ ParentGroups����� .R��� $ 
Horizontal=� .   8  8��  �� �� "  .R��� $ groupContentPresenter��|�.  8��  ����  �� $
 True�� ��  �� *Self+$B <(local:DataGridControl.DataGridContext).DataGridControl.View�# Z "  .a��� 8  $
 groupContentPresenter�� � ���� "  .R��� ���� *Title+����  �� *TemplatedParent+$ DataContext.TitleTemplate�    	  
    u� $ 2Q�$ 2Q�$ 2Q�$ 2Q��� "  ��.���  � �� �� " ��.R��� #��z��#��z��#��z��._��� #��z��#��z��#��z��|�.  #��z��$��2,2,2,2q� ��  �� *TemplatedParent+$ 
IsSelected�$ TwoWay=�  ��  �� *Self+$ Content�8   ��  ���� $! Black��backgroundBrushAdoners �� loadingStoryboard $" Forever��.��U� $# 00:00:00X�$
$ path��$U% O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\��� $& 00:00:00��$' 0Q��� $& 00:00:00.5000000��$' -10.5Q�U� $# 00:00:00X�$
$ path��$U% O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $& 00:00:00��$' 0Q��� $& 00:00:00.5000000��$
' 17.5Q�U� $# 00:00:00X�$$ path2��$U% O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\��� $& 00:00:00��$' 0Q��� $& 00:00:00.5000000��$' 20.875Q�U� $# 00:00:00X�$$ path3��$U% O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\��� $& 00:00:00��$' 0Q��� $& 00:00:00.5000000��$' -17.5Q�U� $# 00:00:00X�$$ path3��$U% O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\��� $& 00:00:00��$' 0Q��� $& 00:00:00.5000000��$' -10.375Q��� $# 00:00:00X�$
$ path��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) Black���� $# 00:00:00X�$$ path2��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) Black���� $# 00:00:00X�$$ path3��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) Black��.R�� $* 
rootLayout��
������ .+��� $��27.466��$��24.066��.+��� .+�F� $
+ path��
���   �|�����k�Z2 ��k�+N ��� @�d X� @�d �@@� @�d ��� �+N ��� �Z2 Ӹ�� p� @@� X� ӈ��     �kp� �k�Z2 $, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� F� $+ path2��
���   �|����@�d �<�@�d 0�X�+N �7o�Z2 �7o�p� �7o0�X�<�     !p� x�
�Z2 x�
Ӹ+N x�
@�d  !@�d �<$, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� F� $+ path3��
���   ��������<��0�X����7oX�p�7o�@�T�7o�g>0�X�g>�<Ӹg> !@�Tx�
X�px�
ӈ��x�
� !��<$, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� . _� $/ errorToolTip��$y�	Collapsed=�.����  �� $ Visible�� �� $ 
Visibility� �� *Self+0 �� $1 
storyboard��8��  2 �� $3 
storyboard���� $3 
storyboard����  ���� $! Black��backgroundBrushAdoners �� errorStoryboard $" Forever��.���� $# 00:00:00X�$
$ path��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) 	#FF970000���� $( 00:00:00.5000000��$	) Red���� $( 00:00:01��$) 	#FF970000���� $( 00:00:01.5000000��$	) Red���� $( 00:00:02��$) 	#FF970000���� $# 00:00:00X�$$ path2��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) 	#FF970000���� $( 00:00:00.5000000��$	) Red���� $( 00:00:01��$) 	#FF970000���� $( 00:00:01.5000000��$	) Red���� $( 00:00:02��$) 	#FF970000���� $# 00:00:00X�$$ path3��$*% $(Shape.Fill).(SolidColorBrush.Color)�.g��� $( 00:00:00��$) 	#FF970000���� $( 00:00:00.5000000��$	) Red���� $( 00:00:01��$) 	#FF970000���� $( 00:00:01.5000000��$	) Red���� $( 00:00:02��$) 	#FF970000��.R�� $* 
rootLayout��
������ .+��� $��27.466��$��24.066��.+��� .+�F� $
+ path��
���   �|�����k�Z2 ��k�+N ��� @�d X� @�d �@@� @�d ��� �+N ��� �Z2 Ӹ�� p� @@� X� ӈ��     �kp� �k�Z2 $, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� F� $+ path2��
���   �|����@�d �<�@�d 0�X�+N �7o�Z2 �7o�p� �7o0�X�<�     !p� x�
�Z2 x�
Ӹ+N x�
@�d  !@�d �<$, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� F� $+ path3��
���   ��������<��0�X����7oX�p�7o�@�T�7o�g>0�X�g>�<Ӹg> !@�Tx�
X�px�
ӈ��x�
� !��<$, 0.5,0.5&�$	- 0.8Q�z�V� .~��� �� �� T� . _� $/ errorToolTip��$y�	Collapsed=�.����  �� $ Error�� �� .a��� $
 
rootLayout�� � y�$ Visible=��� $
 errorToolTip�� � y�$ Visible=��� $
 errorToolTip�� ��  �� *Self+$M G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionError� � ��0 �� $1 
storyboard��8��  2 �� $3 
storyboard���� $3 
storyboard��