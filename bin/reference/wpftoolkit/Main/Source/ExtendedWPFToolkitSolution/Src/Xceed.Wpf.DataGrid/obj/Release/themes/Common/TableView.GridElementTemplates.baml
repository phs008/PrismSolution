   M S B A M L   `   `   `  ���� Y  UXceed.Wpf.DataGrid, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47 clr-namespace:Xceed.Wpf.DataGridXceed.Wpf.DataGrid  E'clr-namespace:Xceed.Wpf.DataGrid.MarkupXceed.Wpf.DataGrid.Markup  M+clr-namespace:Xceed.Wpf.DataGrid.ConvertersXceed.Wpf.DataGrid.Converters  C&clr-namespace:Xceed.Wpf.DataGrid.ViewsXceed.Wpf.DataGrid.Views  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries?    9Xceed.Wpf.DataGrid.Markup.DataGridThemeResourceDictionary8   2Xceed.Wpf.DataGrid.Markup.SharedResourceDictionary   Source    tableViewRowFocusVisualStyle �� 
TargetType+  %System.Windows.IFrameworkInputElement �� 	Resources6   0Xceed.Wpf.DataGrid.Converters.ThicknessConverter  Key �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels �� RelativeSource	 �� AncestorType
 �� Path  thicknessConverter �� 	Converter �� ConverterParameter:   4Xceed.Wpf.DataGrid.Converters.NullToBooleanConverter  nullToBooleanConverter  inverseThicknessConverter   InverseValue $  tableViewDataGridControlTemplate �� 
TargetType(   "Xceed.Wpf.DataGrid.DataGridControl ��Name4   .Xceed.Wpf.DataGrid.Views.TableViewScrollViewer  Name   ShowRowSelectorPane   RowSelectorPaneWidth1   +Xceed.Wpf.DataGrid.Views.TableViewItemsHost �Name ��Name   ConnectionState �� Triggers �� Value �� Binding �� 
TargetName   tableViewRowSelectorTemplate$   Xceed.Wpf.DataGrid.RowSelector �� Padding n�Name  invisibleThumbStyle  tableViewRowTemplate	   Xceed.Wpf.DataGrid.Row � 	Resources:
   4Xceed.Wpf.DataGrid.Converters.TypeToBooleanConverter � ColumnDefinitions ��Name(   "Xceed.Wpf.DataGrid.Views.TableView   CanScrollHorizontally<   6Xceed.Wpf.DataGrid.HierarchicalGroupLevelIndicatorPane0   *Xceed.Wpf.DataGrid.GroupLevelIndicatorPane   Name! ��Name !	 detailsExpanderButtonTemplate)   #Xceed.Wpf.DataGrid.DataGridCommands"   ToggleDetailExpansion# � OverridesDefaultStyle-   'Xceed.Wpf.DataGrid.Views.FixedCellPanel$  Name%   ColumnStretchMinWidth&   ColumnStretchMode'   FixedCellCount( �� Mode)   FixedColumnDropMarkPen* ^� 
Conditions+ �� Binding, �� Value 
 typeToBooleanConverter    Xceed.Wpf.DataGrid.DataRow % !tableViewColumnManagerRowTemplate)   #Xceed.Wpf.DataGrid.ColumnManagerRow- {�Name  tableViewCellTemplate   Xceed.Wpf.DataGrid.Cell-   'Xceed.Wpf.DataGrid.CellContentPresenter.  Name/ ]� 
Conditions0 �� PropertyF   @Xceed.Wpf.DataGrid.Converters.SortingDirectionToBooleanConverter & "SortingDirectionToBooleanConverter & "tableViewColumnManagerCellTemplate*   $Xceed.Wpf.DataGrid.ColumnManagerCell1 d�Name2 J� Opacity3 ��Name4 �� Orientation5 P� 
SourceName6 P� Property7 P� Value # tableViewGroupByControlTemplate'   !Xceed.Wpf.DataGrid.GroupByControl8   NoGroupContent   tableViewGroupByItemTemplate$   Xceed.Wpf.DataGrid.GroupByItem8   2Xceed.Wpf.DataGrid.Converters.IntAdditionConverter ) %groupHeaderControlGroupLevelConverter ' #tableViewGroupHeaderControlTemplate+   %Xceed.Wpf.DataGrid.GroupHeaderControl5   /Xceed.Wpf.DataGrid.Views.PassiveLayoutDecorator9   Axis:   Indented;   
GroupLevel< � FocusVisualStyle= J� InputBindings>   ToggleGroupExpansion? �� Command
@ �� KeyA   ExpandGroupB   CollapseGroupC d� MouseAction % !groupExpanderToggleButtonTemplateD d� 	IsChecked ( $tableViewGroupLevelIndicatorTemplate,   &Xceed.Wpf.DataGrid.GroupLevelIndicator $  tableViewDetailIndicatorTemplate(   "Xceed.Wpf.DataGrid.DetailIndicator , (tableViewGroupLevelIndicatorPaneTemplate'   !Xceed.Wpf.DataGrid.Views.ViewBase 8 4tableViewHierarchicalGroupLevelIndicatorPaneTemplate  dataGridContextTemplateE �� DataType(   "Xceed.Wpf.DataGrid.DataGridContextF �� ItemsSource7   1Xceed.Wpf.DataGrid.HierarchicalGroupByControlNodeG  NameH   TitleI �� Triggers  detailConfigurationTemplate,   &Xceed.Wpf.DataGrid.DetailConfiguration=!   7Xceed.Wpf.DataGrid.Converters.TypeToVisibilityConverter  notDetailConfigConverterJ !  
VisibilityK !  SetVisibilityWhenTrue   booleanToVisibilityConverter / +hierarchicalGroupByControlTreeViewItemStyleL � RowDefinitions 5 1tableViewCommonHierarchicalGroupByControlTemplate3"   -Xceed.Wpf.DataGrid.HierarchicalGroupByControlM R�NameN Q� 
IsExpandedO "  NoGroupContent F BtableViewCommonHierarchicalGroupByControlOldGroupByControlTemplate P "  AllowGroupingModification Q   AllowGroupingModificationR "  	AllowSortS   	AllowSortT "  ConnectionLinePenU   ConnectionLinePen 3 /tableViewHierarchicalGroupByControlNodeTemplateV ��Name ,  (tableViewHierarchicalGroupByItemTemplate0#   *Xceed.Wpf.DataGrid.HierarchicalGroupByItem ! tableViewScrollTipTemplate"$   Xceed.Wpf.DataGrid.ScrollTip�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     *local clr-namespace:Xceed.Wpf.DataGrid  2markup'clr-namespace:Xceed.Wpf.DataGrid.Markup  4conv+clr-namespace:Xceed.Wpf.DataGrid.Converters  0views&clr-namespace:Xceed.Wpf.DataGrid.Views       $ Common.Resources.xaml?�%/G  &	        7  &	 �     &	 �     &	 �     &	 B	    7  &	 �	    7 	 7 
 7 
 &	 f    7 	 &	 �    &	 �    &	 �    7  7  &	 �'    &	 �(    &	 Y+    &	 ^+    7  7  &	 �-    &	 ".    &	 P.    7  7  7  7  &	 T2    &	 �2    &	 �3    &	 \4    &	 v4    &	 {4    7  7  &	 *6    7  7  7  7  7  7  7  &	 4<    7  7  7  &	 _@    &	  �@    &	! oE    �� "   ��  thicknessConverter .���  � �� �� .R��� ���	#FF000000$��1��$	 1 2R� . ����  �� "	 ��$
 HorizontalOffset�8   $
 Left��     . �� "  .R�� .+��� #��z��#��z��#��z��._��� $# PART_DragDropAdornerDecorator��.u�  $ PART_ScrollViewer��#��z�� ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).ShowRowSelectorPane� ��  �� *Self+$B
 <(local:DataGridControl.DataGridContext).RowSelectorPaneWidth�.��  � $ connectionStateGrid��$��Right=�$��Bottom=�$��	0,0,25,25q�$��30��$��30��.+��� $, &connectionStateLoadingContentPresenter��#��z $y�	Collapsed=�����  �� *Self+$I
 C(local:DataGridControl.DataGridContext).ConnectionStateLoadingGlyph��� $/ )connectionStateCommittingContentPresenter��#��z $y�	Collapsed=�����  �� *Self+$L
 F(local:DataGridControl.DataGridContext).ConnectionStateCommittingGlyph��� $* $connectionStateErrorContentPresenter��#��z $y�	Collapsed=�����  �� *Self+$G
 A(local:DataGridControl.DataGridContext).ConnectionStateErrorGlyph� �� $ False�� ��  �� *Self+$K
 E(local:DataGridControl.DataGridContext).IsConnectionStateGlyphEnabled�.a��� $ connectionStateGrid�� � y�$ 	Collapsed=��� $ Loading�� ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a��� $, &connectionStateLoadingContentPresenter�� � y�$ Visible=��� $* $connectionStateErrorContentPresenter�� � y�$ 	Collapsed=��� $/ )connectionStateCommittingContentPresenter�� � y�$ 	Collapsed=��� $ 
Committing�� ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a��� $, &connectionStateLoadingContentPresenter�� � y�$ 	Collapsed=��� $* $connectionStateErrorContentPresenter�� � y�$ 	Collapsed=��� $/ )connectionStateCommittingContentPresenter�� � y�$ Visible=��� $ Error�� ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a��� $, &connectionStateLoadingContentPresenter�� � y�$ 	Collapsed=��� $* $connectionStateErrorContentPresenter�� � y�$ Visible=��� $/ )connectionStateCommittingContentPresenter�� � y�$ 	Collapsed=��� "  .R�� .+��� #��z��#��z��#��z��# z��._��� $ contentPresenter��#��z��#��z��#��z��#��z��#��z��n� $ PART_RowResizerThumb��8��  $��Bottom=��� " 	  ��
  typeToBooleanConverter .R�� $ rootGrid�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
rootBorder��$��2��$��2�� .  #��z��#��z��#��z��# z��  $��0�� .    $  groupLevelIndicatorPane�� .  $��1���� $! detailsToggle��8��  $	��Top=�$��2��$��2,4,2,0q�#��Z" # . |�.  $y�	Collapsed=� .  �� $�� ��$y�Hidden=�$��3��#��z��  $$ PART_CellsHost��$��3��#��z��% ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).ColumnStretchMinWidth�& ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).ColumnStretchMode�' ��  �� *Self+$>
 8(local:DataGridControl.DataGridContext).FixedColumnCount�$( TwoWay=�) ��  �� *Self+$D
 >(local:DataGridControl.DataGridContext).FixedColumnDropMarkPen� ^� * �� + ��  �� *Self+$
 
IsSelected�, True�� + ��  �� *Self+$S
 M(local:DataGridControl.DataGridContext).DataGridControl.IsKeyboardFocusWithin�, True.0��� $ 
rootBorder�� ��  �� *TemplatedParent+$
 SelectionBackground� � ���� $ rootGrid�� ��  �� *TemplatedParent+$
 SelectionForeground� � ��^� * �� + ��  �� *Self+$
 
IsSelected�, True�� + ��  �� *Self+$S
 M(local:DataGridControl.DataGridContext).DataGridControl.IsKeyboardFocusWithin�	, False�� + ��  �� *Self+$K
 E(local:DataGridControl.DataGridContext).DataGridControl.HideSelection�	, False.0��� $ 
rootBorder�� ��  �� *TemplatedParent+$!
 InactiveSelectionBackground� � ���� $ rootGrid�� ��  �� *TemplatedParent+$!
 InactiveSelectionForeground� � ��^� * �� + ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True�� + ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True�� + ��  �� *Self+$
 .�$( OneWay=�8  "  , True.0��� $ detailsToggle�� � y�$ Visible=�^� * �� + ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True�� + ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True�� + ��  �� *Self+$
 .�$( OneWay=�8  "  	, False.0��� $ detailsToggle�� � y�$ Hidden=��� "   ��  thicknessConverter  . .R�� $ rootGrid�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
rootBorder��$��1��$��3�� .  #��z��#��z��#��z��# z��   .  $��0��#��z��  $  groupLevelIndicatorPane�� .  $��1��#��z���� $! detailsToggle��8��  $	��Top=�$��2��$��2,4,2,0q�#��Z" # . |�.  $y�	Collapsed=� .  {� $- indentationDecorator��$��3��._�  $$ PART_CellsHost��#��z��% ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).ColumnStretchMinWidth�& ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).ColumnStretchMode�' ��  �� *Self+$>
 8(local:DataGridControl.DataGridContext).FixedColumnCount�$( TwoWay=�) ��  �� *Self+$D
 >(local:DataGridControl.DataGridContext).FixedColumnDropMarkPen� ^� * �� + ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True�� + ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True.0��� $ detailsToggle�� � y�$ Hidden=��� "  .R��� $ 
rootBorder��#��z��#��z��#��z��# z��._�  $. PART_CellContentPresenter��#��z��#��z�� ]� / �� 0 �@ 	IsCurrent, . �� 0 �@ HasValidationError, .  ./��� $ 
rootBorder�� ��  �� *TemplatedParent+$
 CurrentBackground� � ���� $ 
rootBorder�� ��  �� *TemplatedParent+$
 CurrentForeground� � ��]� / �� 0 �@ 	IsCurrent, . �� 0 �@ HasValidationError, . �� , Z� 0 �@ CellErrorStyle./��� $ 
rootBorder�� ��  �� *TemplatedParent+$
 CurrentBackground� � ���� $ 
rootBorder�� ��  �� *TemplatedParent+$
 CurrentForeground� � ��^� * �� + ��  �� *Self+$
 
IsSelected�, True�� + ��  �� *Self+$k
 e(local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).IsKeyboardFocusWithin�, True.0��� $ 
rootBorder�� ��  �� *TemplatedParent+$
 SelectionBackground� � ���� $ 
rootBorder�� ��  �� *TemplatedParent+$
 SelectionForeground� � ��^� * �� + ��  �� *Self+$
 
IsSelected�, True�� + ��  �� *Self+$k
 e(local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).IsKeyboardFocusWithin�	, False�� + ��  �� *Self+$c
 ](local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).HideSelection�	, False.0��� $ 
rootBorder�� ��  �� *TemplatedParent+$!
 InactiveSelectionBackground� � ���� $ 
rootBorder�� ��  �� *TemplatedParent+$!
 InactiveSelectionForeground� � ���� $ False�� ��  �� *Self+$
 ParentColumn.Visible�.a���  � y�$ 	Collapsed=�  �� "  .R��� #��z��#��z��._�� .+��� #��� ��$
��Left=�$��Stretch=�$��1��$��0,2,0,2q��� #��� ��$��Right=�$��Stretch=�$��1��$��0,2,0,2q�]� .+��� $! thumbToggleBackgroundBorder��$��Right=�._�� .+��� $ toggleDelimeterBorder��#��� ��$��1,0,0,0q�$��0,4,0,4q�
������ $y�	Collapsed=�._��� $ toggleDelimeterBorder2��#��� ��$��1,0,0,0q�$��0,0,0,0q�
������ $y�	Collapsed=�d� $1 toggleButton��|�.  $��Stretch=�$y�	Collapsed=�$��2,0,0,0q�$	2 0.5Q��� #��z��._�� .+��� # z��._��� $3 contentPanel��$4 
Horizontal=�.+�  #��z��#��z���� $ sortGlyphPresenter����Z� ��Z� n� $! PART_ColumnResizerThumbLeft��8��  $��6��$
��Left=�n� $ PART_ColumnResizerThumb��8�� $��6��$��Right=� P� $5 toggleButton��6 �@J�IsMouseOver7 . . ��� $ toggleButton�� �@J�Opacity$ 1Q�P� 6 �@ 	IsPressed7 . . ��� $ contentPanel�� � ��$ 	1,1,-1,-1q��� $ 	Ascending�� ��  �� *Self+$ 
 ParentColumn.SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� $ sortGlyphPresenter�� � ��$ 6,0,0,0q��� $ 
Descending�� ��  �� *Self+$ 
 ParentColumn.SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� $ sortGlyphPresenter�� � ��$ 6,0,0,0q�^� * �� + ��  �� *Self+$ 
 ParentColumn.HasFixedWidth�, True�� + ��  �� *Self+$L
 F(local:DataGridControl.DataGridContext).RemoveColumnStretchingOnResize�	, False.0��� $ PART_ColumnResizerThumb�� � {� .  ^� * �� + ��  �� *Self+$6
 0ParentColumn.PreviousVisibleColumn.HasFixedWidth�, True�� + ��  �� *Self+$L
 F(local:DataGridControl.DataGridContext).RemoveColumnStretchingOnResize�	, False.0��� $! PART_ColumnResizerThumbLeft�� � {� .  �� $ False�� ��  �� *Self+$!
 ParentRow.AllowColumnResize�.a��� $ PART_ColumnResizerThumb�� � {� .  �� $! PART_ColumnResizerThumbLeft�� � {� .  �� $ False�� ��  �� *Self+$
 ParentColumn.Visible�.a���  � y�$ 	Collapsed=��� "  .R��� #��z��#��z��#��z��# z��._�� .+��� $ noGroupContentPresenter��#��z8 $��Center=�$y�	Collapsed=���  P� 6 �@��HasItems7 .  . ��� $ noGroupContentPresenter�� � y�$ Visible=��� "  .R��� #��z��#��z��#��z��# z��._��� $4 
Horizontal=�.+��� #��z��#��z��#��z��#��z��#��z���� $ sortGlyphPresenter����Z� ��Z�  �� $ 	Ascending�� ��  �� *Self+$
 SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� $ sortGlyphPresenter�� � ��$ 6,0,0,0q��� $ 
Descending�� ��  �� *Self+$
 SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� $ sortGlyphPresenter�� � ��$ 6,0,0,0q�  �� "  .R�  $9 
Horizontal=�._�]� .+�  $
��Left=�  $
��Left=�: .  ; ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�8   $ -1���� $ 
mainBorder��#��z��#��z��#��z��# z��|�. #< z< = �� #? Z> $@ Space���� #? ZA $@ Right���� #? ZA $	@ Add���� #? ZB $
@ Left���� #? ZB $@ Subtract��d� #? Z> $C LeftDoubleClicke�._��� $4 
Horizontal=�.+�d� 8�� # . #��z��|�.  D ��  �� *TemplatedParent+$
 Group.IsExpanded��� $��3,0,0,0q�#��z��#��z��#��z��#��z�� P� 6 �@ NavigationBehavior$
7 None=�. ��� $ 
mainBorder�� � |� .  �� "  .R��� #��z��#��z��#��z��# z���� "  .R��� #��z��#��z��#��z��# z���� "  .R�� .+��� $ horizontalBorder��#��z��#��z������  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top���� $ verticalBorder��#��z��# z������  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $
 Left��._��� $"3 PART_GroupLevelIndicatorHost��$4 
Horizontal=� ]� / �� 0 �@ IsLeaf, . �� 0 �@ 
IsLastItem, . �� 0 �@ HasExpandedDetails, .  ./��� $ horizontalBorder�� ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8  $ Top, Bottom�� � ���� $ verticalBorder�� ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8  $ Bottom�� � ��]� / �� 0 �@ CurrentIndicatorCount$, 0���� 0 �@ IsLeaf, .  ./��� $ verticalBorder�� � ��$ 0q�P� 6 �@ ShowVerticalBorder7 .  . ��� $ verticalBorder�� � ��$ 0q��� "  .R��� #��z��#��z��._��� $"3 PART_GroupLevelIndicatorHost��$4 
Horizontal=��� "E  F �� $
 DetailConfigurations�.R�  $G groupByControlNode������ $
 GroupLevelDescriptions�H �� $%
 SourceDetailConfiguration.Title�I ��  �� $
 SourceDetailConfiguration� Z� .a��� $ groupByControlNode�� �@ Title �� $%
 DataGridControl.ItemsSourceName��� "E   F �� $
 DetailConfigurations�.R�  ���� $
 GroupLevelDescriptions�H �� *Title+!  $J Visible=�K .  �� �� " Q�.���  �@Q�
IsExpanded . ��  � |� .  ��  � y� � .&��� $
 .�8   "   �� $
 Visible�8  ��  � �� �� " Q�.R��  �� $��19 ��� $
��Auto ��� $��* �L �� $
��Auto ��� .+��� $��treeViewItemBorder��#��z��# z��#��z��#��z�� . $��1��._��� $��PART_Header��#��z��#��z��$��Header��#��z��# z �� $��	ItemsHost��$��1��$��1��$��2���� " "  ���� 'R�       " R�.R�� $ rootGrid�� �� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
rootBorder��$��1��$��2��#��z��# z������  �� *Self+$E
 ?(local:DataGridControl.DataGridContext).HorizontalGridLineBrush�����  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top���� $ verticalGridLineBorder��$��1��$��2������  �� *Self+$C
 =(local:DataGridControl.DataGridContext).VerticalGridLineBrush�����  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right��  $��0��  $  groupLevelIndicatorPane��$��1���� $��2��$4 
Horizontal=�.+�R� $-M 'PART_HierarchicalGroupByControlTreeView��8�� 
������ 
������ |�.  .@�Q� 8�� 8�� 8�� N . ����  �� *Self+$-
 '(local:DataGridControl.DataGridContext)�����  �� *Self+$B
 <(local:DataGridControl.DataGridContext).DetailConfigurations��� $ noGroupContentPresenter��#��zO $��Center=�$y�	Collapsed=�$��5,0,0,0q� �� $
 True�� ��  �� *Self+$
 	HasGroups�.a��� $ noGroupContentPresenter�� � y�$ Visible=��� $ -1�� ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�.a��� $ groupLevelIndicatorPane�� � y�$ 	Collapsed=��� $ verticalGridLineBorder�� ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right, Left�� � ���� " " .R�� $ rootGrid�� �� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
rootBorder��$��1��$��2��#��z��# z������  �� *Self+$E
 ?(local:DataGridControl.DataGridContext).HorizontalGridLineBrush�����  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top���� $ verticalGridLineBorder��$��1��$��2������  �� *Self+$C
 =(local:DataGridControl.DataGridContext).VerticalGridLineBrush�����  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right��  $��0��  $  groupLevelIndicatorPane��$��1��  $��2��#��z��#��z��#��z��#Q zP #S zR #U zT #8 zO  .  �� $ -1�� ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�.a��� $ groupLevelIndicatorPane�� � y�$ 	Collapsed=��� $ verticalGridLineBorder�� ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right, Left�� � ���� "  .R��� $4 
Horizontal=�#��z��.+��� $V titleTextBlock��#��zH $��0,0,10,0q��� $��0,0,0,10q��� " # .R��� $ outerBorder��#��� ��#��� ��$��0,0,1,1q�$ 1,1,0,0q�._��� $ innerBorder��#��� ��$��0,0,1,1q�$��1,1,0,0q�#��z��# z��._��� $3 contentPanel��$4 
Horizontal=�.+��� #��z��#��z��#��z��#��z��#��z���� $ sortGlyphPresenter��$��6,0,0,0q�$y�Hidden=���Z� ����  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� P� 6 � ��7 . . ��� $ outerBorder��# � �� � ���� $ outerBorder�� � ��$ 1q��� $ outerBorder�� �@��Padding$ 0q��� $ innerBorder�� � ��$ 1q��� $ innerBorder�� � ��$ 0q��� $ contentPanel�� � ��$ 	1,1,-1,-1q��� $ 	Ascending�� ��  �� *Self+$
 SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� $ sortGlyphPresenter�� � y�$ Visible=��� $ 
Descending�� ��  �� *Self+$
 SortDirection�.a��� $ sortGlyphPresenter�� ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� $ sortGlyphPresenter�� � y�$ Visible=��� " $ .R��� $��Center=�$��Right=�#��z��#��z��#��z��