   M S B A M L   `   `   `  ����Y  UXceed.Wpf.DataGrid, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47 clr-namespace:Xceed.Wpf.DataGridXceed.Wpf.DataGrid  5      E'clr-namespace:Xceed.Wpf.DataGrid.MarkupXceed.Wpf.DataGrid.Markup  5      M+clr-namespace:Xceed.Wpf.DataGrid.ConvertersXceed.Wpf.DataGrid.Converters  5      C&clr-namespace:Xceed.Wpf.DataGrid.ViewsXceed.Wpf.DataGrid.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries?    9Xceed.Wpf.DataGrid.Markup.DataGridThemeResourceDictionary8   2Xceed.Wpf.DataGrid.Markup.SharedResourceDictionary   Source    tableViewRowFocusVisualStyle �� 
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
IsExpandedO "  NoGroupContent F BtableViewCommonHierarchicalGroupByControlOldGroupByControlTemplate P "  AllowGroupingModification Q   AllowGroupingModificationR "  	AllowSortS   	AllowSortT "  ConnectionLinePenU   ConnectionLinePen 3 /tableViewHierarchicalGroupByControlNodeTemplateV ��Name ,  (tableViewHierarchicalGroupByItemTemplate0#   *Xceed.Wpf.DataGrid.HierarchicalGroupByItem ! tableViewScrollTipTemplate"$   Xceed.Wpf.DataGrid.ScrollTip�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Xceed.Wpf.DataGrid  5      2markup'clr-namespace:Xceed.Wpf.DataGrid.Markup  5      4conv+clr-namespace:Xceed.Wpf.DataGrid.Converters  5      0views&clr-namespace:Xceed.Wpf.DataGrid.Views  5        5         5      $ Common.Resources.xaml?�6/   %�i  &	        7  &	 M    &	 `    &	 ~    &	 �    7  &	 S    7 	 7 
 7 
 &	 �    7 	 &	 7"    &	 �+    &	 �+    7  7  &	 �9    &	 Q;    &	 V?    &	 i?    7  7  &	 �C    &	 PD    &	 �D    7  7  7  7  &	 lJ    &	 K    &	 �L    &	 �M    &	 �M    &	 �M    7  7  &	 tQ    7  7  7  7  7  7  7  &	 �Y    7  7  7  &	 �_    &	  �`    &	! �g    �� 5      "  5       5      ��  5      thicknessConverter 6#   5    	   .�5"      ��  � �� 5#      �� 5$      .R�5%      �� ���	#FF000000$��1��5&      $	 1 2R�5'       . ��5(      ��  �� "	 ��$
 HorizontalOffset�8   $
 Left��5)      5*      5,   	   5-        5/      6!     50       . 51      �� 56      "  57      .R�58      � .+�59      �� #��z��6   #��z��5:      #��z��5;      ._�5>      �� $# PART_DragDropAdornerDecorator��6   .u�5A        $ PART_ScrollViewer��6-   #��z��5D   -    5B   -   ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).ShowRowSelectorPane� 5C   -   ��  �� *Self+$B
 <(local:DataGridControl.DataGridContext).RowSelectorPaneWidth�.��5F        5G      5H      5I      � 5J      $ connectionStateGrid��6   $��Right=�5K      $��Bottom=�5L      $��	0,0,25,25q�5M      $��30��5N      $��30��5O      .+�5P      �� $, &connectionStateLoadingContentPresenter��6   #��z 5R      $y�	Collapsed=�5S      ��5Q      ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).ConnectionStateLoadingGlyph�5S      �� 5T      $/ )connectionStateCommittingContentPresenter��6   #��z 5V      $y�	Collapsed=�5W      ��5U      ��  �� *Self+$L
 F(local:DataGridControl.DataGridContext).ConnectionStateCommittingGlyph�5W      �� 5X      $* $connectionStateErrorContentPresenter��6   #��z 5Z      $y�	Collapsed=�5[      ��5Y      ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).ConnectionStateErrorGlyph�5[      5\      5]   	    5^      �� 5_      $ False��5`       5_      ��  �� *Self+$K
 E(local:DataGridControl.DataGridContext).IsConnectionStateGlyphEnabled�.a�5a      �� $ connectionStateGrid��6    � y�$ 	Collapsed=�5c      5d      �� 5e      $ Loading��5f       5e      ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a�5g      �� $, &connectionStateLoadingContentPresenter��6    � y�$ Visible=�5i      �� 5j      $* $connectionStateErrorContentPresenter��6    � y�$ 	Collapsed=�5l      �� 5m      $/ )connectionStateCommittingContentPresenter��6    � y�$ 	Collapsed=�5o      5p      �� 5q      $ 
Committing��5r       5q      ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a�5s      �� $, &connectionStateLoadingContentPresenter��6    � y�$ 	Collapsed=�5u      �� 5v      $* $connectionStateErrorContentPresenter��6    � y�$ 	Collapsed=�5x      �� 5y      $/ )connectionStateCommittingContentPresenter��6    � y�$ Visible=�5{      5|      �� 5}      $ Error��5~       5}      ��  �� *Self+$M
 G(local:DataGridControl.DataGridContext).DataGridControl.ConnectionState�.a�5      �� $, &connectionStateLoadingContentPresenter��6    � y�$ 	Collapsed=�5�      �� 5�      $* $connectionStateErrorContentPresenter��6    � y�$ Visible=�5�      �� 5�      $/ )connectionStateCommittingContentPresenter��6    � y�$ 	Collapsed=�5�      5�      5�      �� 5�      "  5�      .R�5�      � .+�5�      �� #��z��6   #��z��5�      #��z��5�      # z��5�      ._�5�      �� $ contentPresenter��6   #��z��5�      #��z��5�      #��z��5�      #��z��5�      #��z��5�      5�      n� 5�      $ PART_RowResizerThumb��6   8��  $��Bottom=�5�      5�   	   5�      �� 5�      " 	 5�       5�      ��
  5�      typeToBooleanConverter 6'   5�   	   .R�5�      � $ rootGrid��6    5�      �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $��* �6   .+�5�      �� $ 
rootBorder��6   $��2��5�      $��2��5�       .  #��z��5�      #��z��5�      #��z��5�      # z��5�        5�      $��0��65    .  5�   5     5�      $  groupLevelIndicatorPane��6)    .  $��1��5�   )   �� 5�      $! detailsToggle��6   8��  $	��Top=�5�      $��2��5�      $��2,4,2,0q�5�      #��Z" 5�      # . |�.  $y�	Collapsed=�5�       .  5�      �� 5�      $�� ��6   $y�Hidden=�5�      $��3��5�      #��z��5�        5�      $$ PART_CellsHost��6    $��3��5�       #��z��5�       % 5�       ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).ColumnStretchMinWidth�& 5�       ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).ColumnStretchMode�' 5�       ��  �� *Self+$>
 8(local:DataGridControl.DataGridContext).FixedColumnCount�$( TwoWay=�) 5�       ��  �� *Self+$D
 >(local:DataGridControl.DataGridContext).FixedColumnDropMarkPen�5�       5�   	    5�      ^� 5      * 5     �� 5     + 6   ��  �� *Self+$
 
IsSelected�, True5     �� 5     + 6   ��  �� *Self+$S
 M(local:DataGridControl.DataGridContext).DataGridControl.IsKeyboardFocusWithin�, True5     .0�5     �� $ 
rootBorder��6    5     ��  �� *TemplatedParent+$
 SelectionBackground� � ���� 5     $ rootGrid��6    5     ��  �� *TemplatedParent+$
 SelectionForeground� � ��5     ^� 5     * 5     �� 5     + 6   ��  �� *Self+$
 
IsSelected�, True5     �� 5     + 6   ��  �� *Self+$S
 M(local:DataGridControl.DataGridContext).DataGridControl.IsKeyboardFocusWithin�	, False5     �� 5      + 6   ��  �� *Self+$K
 E(local:DataGridControl.DataGridContext).DataGridControl.HideSelection�	, False5!     .0�5%     �� $ 
rootBorder��6    5'     ��  �� *TemplatedParent+$!
 InactiveSelectionBackground� � ���� 5)     $ rootGrid��6    5+     ��  �� *TemplatedParent+$!
 InactiveSelectionForeground� � ��5-     ^� 50     * 51     �� 52     + 6   ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True53     �� 54     + 6   ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True55     �� 56     + 57     ��  �� *Self+$
 .�$( OneWay=�8  "  , True56     57     .0�5:     �� $ detailsToggle��6    � y�$ Visible=�5<     5>     ^� 5@     * 5A     �� 5B     + 6   ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True5C     �� 5D     + 6   ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True5E     �� 5F     + 5G     ��  �� *Self+$
 .�$( OneWay=�8  "  	, False5F     5G     .0�5J     �� $ detailsToggle��6    � y�$ Hidden=�5L     5N     5Q     �� 5V     "  5W      5\     ��  5]     thicknessConverter  . 5^  #   5_  	   .R�5b     � $ rootGrid��6    5c     �� 5e     $
��Auto �6   �� 5g     $
��Auto �6   �� 5h     $
��Auto �6   �� 5k     $��* �6   .+�5q     �� $ 
rootBorder��6   $��1��5r     $��3��5s      .  #��z��5u     #��z��5v     #��z��5w     # z��5x       5|      .  $��0��5}  5   #��z��5~  5     5     $  groupLevelIndicatorPane��6)    .  $��1��5�  )   #��z��5�  )   �� 5�     $! detailsToggle��6   8��  $	��Top=�5�     $��2��5�     $��2,4,2,0q�5�     #��Z" 5�     # . |�.  $y�	Collapsed=�5�      .  5�     {� 5�     $- indentationDecorator��6   $��3��5�     ._�5�       $$ PART_CellsHost��6#   #��z��5�  #   % 5�  #   ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).ColumnStretchMinWidth�& 5�  #   ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).ColumnStretchMode�' 5�  #   ��  �� *Self+$>
 8(local:DataGridControl.DataGridContext).FixedColumnCount�$( TwoWay=�) 5�  #   ��  �� *Self+$D
 >(local:DataGridControl.DataGridContext).FixedColumnDropMarkPen�5�  #   5�     5�  	    5�     ^� 5�     * 5�     �� 5�     + 6   ��  �� *Self+$8
 2(local:DataGridControl.DataGridContext).HasDetails�, True5�     �� 5�     + 6   ��  �� *Self+$?
 9(local:DataGridControl.DataGridContext).AllowDetailToggle�, True5�     .0�5�     �� $ detailsToggle��6    � y�$ Hidden=�5�     5�     5�     �� 5�     "  5�     .R�5�     �� $ 
rootBorder��6   #��z��5�     #��z��5�     #��z��5�     # z��5�     ._�5�       $. PART_CellContentPresenter��6&   #��z��5�  &   #��z��5�  &   5�  	    5�     ]� 5�     / 5�     �� 5�     0 �@ 	IsCurrent, . 5�     �� 5�     0 �@ HasValidationError, .  5�     ./�5�     �� $ 
rootBorder��6    5�     ��  �� *TemplatedParent+$
 CurrentBackground� � ���� 5�     $ 
rootBorder��6    5�     ��  �� *TemplatedParent+$
 CurrentForeground� � ��5�     ]� 5�     / 5�     �� 5�     0 �@ 	IsCurrent, . 5�     �� 5�     0 �@ HasValidationError, . 5�     �� 5�     , 5�     Z� 0 �@ CellErrorStyle./�5�     �� $ 
rootBorder��6    5�     ��  �� *TemplatedParent+$
 CurrentBackground� � ���� 5�     $ 
rootBorder��6    5      ��  �� *TemplatedParent+$
 CurrentForeground� � ��5     ^� 5     * 5     �� 5     + 6   ��  �� *Self+$
 
IsSelected�, True5	     �� 5     + 6   ��  �� *Self+$k
 e(local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).IsKeyboardFocusWithin�, True5     .0�5     �� $ 
rootBorder��6    5     ��  �� *TemplatedParent+$
 SelectionBackground� � ���� 5     $ 
rootBorder��6    5     ��  �� *TemplatedParent+$
 SelectionForeground� � ��5     ^� 5     * 5     �� 5     + 6   ��  �� *Self+$
 
IsSelected�, True5      �� 5"     + 6   ��  �� *Self+$k
 e(local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).IsKeyboardFocusWithin�	, False5#     �� 5%     + 6   ��  �� *Self+$c
 ](local:DataGridControl.DataGridContext).(local:DataGridContext.DataGridControl).HideSelection�	, False5&     .0�5*     �� $ 
rootBorder��6    5,     ��  �� *TemplatedParent+$!
 InactiveSelectionBackground� � ���� 5.     $ 
rootBorder��6    50     ��  �� *TemplatedParent+$!
 InactiveSelectionForeground� � ��52     �� 5:     $ False��5;      5:     ��  �� *Self+$
 ParentColumn.Visible�.a�5<     ��  � y�$ 	Collapsed=�5=     5>     5B       5H     6.   �� 5J     "  5K     .R�5Q     �� #��z��6   #��z��5R     ._�5U     � .+�5W     �� #��� ��6   $
��Left=�5X     $��Stretch=�5Y     $��1��5Z     $��0,2,0,2q�5[     �� 5]     #��� ��6   $��Right=�5^     $��Stretch=�5_     $��1��5`     $��0,2,0,2q�5a     ]� 5c     .+�5d     �� $! thumbToggleBackgroundBorder��6   $��Right=�5e     ._�5g     � .+�5i     �� $ toggleDelimeterBorder��6   #��� ��5j     $��1,0,0,0q�5k     $��0,4,0,4q�5l     
������ $y�	Collapsed=�5n     ._�5p     �� $ toggleDelimeterBorder2��6!   #��� ��5q  !   $��1,0,0,0q�5r  !   $��0,0,0,0q�5s  !   
������ $y�	Collapsed=�5u  !   5w     5y     d� 5{     $1 toggleButton��6$   |�.  $��Stretch=�5}  $   $y�	Collapsed=�5~  $   $��2,0,0,0q�5  $   $	2 0.5Q�5�  $   5�     5�     �� 5�     #��z��6   ._�5�     � .+�5�     �� # z��6   ._�5�     �� $3 contentPanel��6%   $4 
Horizontal=�5�  %   .+�5�       #��z��68   #��z��5�  8   �� 5�     $ sortGlyphPresenter��6.   ��5�  .   Z� ��5�  .   Z� 5�     5�     5�     5�     5�     n� 5�     $! PART_ColumnResizerThumbLeft��6   8��  $��6��5�     $
��Left=�5�     n� 5�     $ PART_ColumnResizerThumb��6   8�� $��6��5�     $��Right=�5�     5�     5�  	    5�     P� 5�     $5 toggleButton��6   6 �@J�IsMouseOver7 . . �5�     �� $ toggleButton��6    �@J�Opacity$ 1Q�5�     5�     P� 5�     6 �@ 	IsPressed7 . . �5�     �� $ contentPanel��6    � ��$ 	1,1,-1,-1q�5�     5�     �� 5�     $ 	Ascending��5�      5�     ��  �� *Self+$ 
 ParentColumn.SortDirection�.a�5�     �� $ sortGlyphPresenter��6    5�     ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� 5�     $ sortGlyphPresenter��6    � ��$ 6,0,0,0q�5�     5�     �� 5�     $ 
Descending��5�      5�     ��  �� *Self+$ 
 ParentColumn.SortDirection�.a�5�     �� $ sortGlyphPresenter��6    5�     ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� 5�     $ sortGlyphPresenter��6    � ��$ 6,0,0,0q�5�     5�     ^� 5�     * 5�     �� 5�     + 6   ��  �� *Self+$ 
 ParentColumn.HasFixedWidth�, True5�     �� 5�     + 6   ��  �� *Self+$L
 F(local:DataGridControl.DataGridContext).RemoveColumnStretchingOnResize�	, False5�     .0�5�     �� $ PART_ColumnResizerThumb��6    � {� .  5�     5�     ^� 5�     * 5�     �� 5�     + 6   ��  �� *Self+$6
 0ParentColumn.PreviousVisibleColumn.HasFixedWidth�, True5�     �� 5�     + 6   ��  �� *Self+$L
 F(local:DataGridControl.DataGridContext).RemoveColumnStretchingOnResize�	, False5�     .0�5      �� $! PART_ColumnResizerThumbLeft��6    � {� .  5     5     �� 5     $ False��5      5     ��  �� *Self+$!
 ParentRow.AllowColumnResize�.a�5     �� $ PART_ColumnResizerThumb��6    � {� .  5	     �� 5
     $! PART_ColumnResizerThumbLeft��6    � {� .  5     5     �� 5     $ False��5      5     ��  �� *Self+$
 ParentColumn.Visible�.a�5     ��  � y�$ 	Collapsed=�5     5     5     �� 5     "  5     .R�5     �� #��z��6   #��z��5      #��z��5!     # z��5"     ._�5&     � .+�5,     �� $ noGroupContentPresenter��6   #��z8 5-     $��Center=�5.     $y�	Collapsed=�5/     �� 55     57     58  	    5:     P� 5=     6 �@��HasItems7 .  . �5@     �� $ noGroupContentPresenter��6    � y�$ Visible=�5B     5C     5G     �� 5L     "  5M     .R�5O     �� #��z��6   #��z��5P     #��z��5Q     # z��5R     ._�5U     �� $4 
Horizontal=�6   .+�5X     �� #��z��6   #��z��5Y     #��z��5Z     #��z��5[     #��z��5\     �� 5a     $ sortGlyphPresenter��6   ��5b     Z� ��5c     Z� 5e     5f  	    5h     �� 5l     $ 	Ascending��5m      5l     ��  �� *Self+$
 SortDirection�.a�5o     �� $ sortGlyphPresenter��6    5q     ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� 5s     $ sortGlyphPresenter��6    � ��$ 6,0,0,0q�5u     5w     �� 5y     $ 
Descending��5z      5y     ��  �� *Self+$
 SortDirection�.a�5|     �� $ sortGlyphPresenter��6    5~     ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� 5�     $ sortGlyphPresenter��6    � ��$ 6,0,0,0q�5�     5�     5�       5�     6   �� 5�     "  5�     .R�5�       $9 
Horizontal=�6%   ._�5�     ]� .+�5�       $
��Left=�68     5�     $
��Left=�6,   : .  ; 5�  ,   ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�8   $ -1���� 5�     $ 
mainBorder��6   #��z��5�     #��z��5�     #��z��5�     # z��5�     |�. #< z< 5�     = 5�     �� 5�     #? Z> 6   $@ Space��5�     �� 5�     #? ZA 6   $@ Right��5�     �� 5�     #? ZA 6   $	@ Add��5�     �� 5�     #? ZB 6   $
@ Left��5�     �� 5�     #? ZB 6   $@ Subtract��5�     d� 5�     #? Z> 6!   $C LeftDoubleClicke�5�  !   ._�5�     �� $4 
Horizontal=�6   .+�5�     d� 8�� # . #��z��5�  !   |�.  D 5�  !   ��  �� *TemplatedParent+$
 Group.IsExpanded��� 5�     $��3,0,0,0q�6%   #��z��5�  %   #��z��5�  %   #��z��5�  %   #��z��5�  %   5�     5�     5�     5�  	    5�     P� 5�     6 �@ NavigationBehavior$
7 None=�5�     . �5�     �� $ 
mainBorder��6    � |� .  5�     5�     5�     �� 5�     "  5�     .R�5�     �� #��z��6   #��z��5�     #��z��5�     # z��5�     5�     �� 5�     "  5�     .R�5�     �� #��z��6   #��z��5�     #��z��5�     # z��5�     5�     �� 5�     "  5�     .R�5�     � .+�5�     �� $ horizontalBorder��6   #��z��5      #��z��5     ��5     ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top���� 5     $ verticalBorder��6   #��z��5     # z��5     ��5     ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $
 Left��._�5     �� $"3 PART_GroupLevelIndicatorHost��6   $4 
Horizontal=�5	     5
     5  	    5     ]� 5     / 5     �� 5     0 �@ IsLeaf, . 5     �� 5     0 �@ 
IsLastItem, . 5     �� 5     0 �@ HasExpandedDetails, .  5     ./�5     �� $ horizontalBorder��6    5     ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8  $ Top, Bottom�� � ���� 5     $ verticalBorder��6    5     ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8  $ Bottom�� � ��5     ]� 5     / 5      �� 5"     0 �@ CurrentIndicatorCount$, 0��5#     �� 5%     0 �@ IsLeaf, .  5&     ./�5*     �� $ verticalBorder��6    � ��$ 0q�5,     5.     P� 50     6 �@ ShowVerticalBorder7 .  . �52     �� $ verticalBorder��6    � ��$ 0q�54     55     58     �� 5=     "  5>     .R�5?     �� #��z��6   #��z��5@     ._�5A     �� $"3 PART_GroupLevelIndicatorHost��6   $4 
Horizontal=�5B     5C  	   5E     �� 5L     "E  5M     F 5N     �� $
 DetailConfigurations�.R�5P       $G groupByControlNode��6-   ��5Q  -   �� $
 GroupLevelDescriptions�H 5R  -   �� $%
 SourceDetailConfiguration.Title�I 5U     �� 5V      6   �� $
 SourceDetailConfiguration� 5W     Z� .a�5X     �� $ groupByControlNode��6    �@ Title 5Z     �� 5[     $%
 DataGridControl.ItemsSourceName�6   5]     5^     5a     �� 5d     "E   5e     F 5f     �� $
 DetailConfigurations�.R�5h       ��6-   �� $
 GroupLevelDescriptions�H 5i  -   �� *Title+5j     !  5l     $J Visible=�5m  $   K .  5n  $   �� 5p     6"   �� 5s     " Q�5t     .�5v     ��  �@Q�
IsExpanded . 5w     �� 5y      � |� .  5z     �� 5|      � y� 5}     � 5~     .&�5     �� $
 .�6   8   "   5�     �� 5�     $
 Visible�6   8  5�     5�     5�  	   �� 5�      � �� 5�     �� 5�     " Q�6   .R�5�     �  5�     �� 5�     $��19 �6(   �� 5�     $
��Auto �6(   �� 5�     $��* �6(   L 5�     �� 5�     $
��Auto �6%   �� 5�     .+�5�     �� $��treeViewItemBorder��5�     #��z��5�     # z��5�     #��z��5�     #��z��5�      . $��1��5�     ._�5�     �� $��PART_Header��5�  (   #��z��5�  (   #��z��5�  (   $��Header��5�  (   #��z��5�  (   # z 5�  (   5�     �� 5�     $��	ItemsHost��6#   $��1��5�  #   $��1��5�  #   $��2��5�  #   5�     5�     5�  	   5�     �� 5�     " " 5�      5�     ���� 5�     'R�       " R�6   5�  	   .R�5�     � $ rootGrid��6    5�     �� 5�     $
��Auto �6   �� 5�     $
��Auto �6   �� 5�     $��* �6   .+�5�     �� $ 
rootBorder��6   $��1��5�     $��2��5�     #��z��5�     # z��5�     ��5�     ��  �� *Self+$E
 ?(local:DataGridControl.DataGridContext).HorizontalGridLineBrush���5�     ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top��5�     �� 5�     $ verticalGridLineBorder��6   $��1��5�     $��2��5�     ��5�     ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).VerticalGridLineBrush���5�     ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right��  5�     $��0��65     5�     $  groupLevelIndicatorPane��6)   $��1��5�  )   �� 5�     $��2��6   $4 
Horizontal=�5�     .+�5�     R� $-M 'PART_HierarchicalGroupByControlTreeView��6   8�� 
������ 
������ |�.  .@�5�     Q� 8�� 8�� 8�� N . ��6   ��  �� *Self+$-
 '(local:DataGridControl.DataGridContext)���5�     ��  �� *Self+$B
 <(local:DataGridControl.DataGridContext).DetailConfigurations�5�     5�     �� 5�     $ noGroupContentPresenter��6   #��zO 5�     $��Center=�5�     $y�	Collapsed=�5�     $��5,0,0,0q�5�     5�     5�  	    5�     �� 5�     $
 True��5�      5�     ��  �� *Self+$
 	HasGroups�.a�5      �� $ noGroupContentPresenter��6    � y�$ Visible=�5     5     �� 5     $ -1��5      5     ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�.a�5     �� $ groupLevelIndicatorPane��6    � y�$ 	Collapsed=�5
     �� 5     $ verticalGridLineBorder��6    5     ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right, Left�� � ��5     5     �� 5     " " 5     .R�5     � $ rootGrid��6    5     �� 5     $
��Auto �6   �� 5     $
��Auto �6   �� 5      $��* �6   .+�5&     �� $ 
rootBorder��6   $��1��5'     $��2��5(     #��z��5)     # z��5,     ��5*     ��  �� *Self+$E
 ?(local:DataGridControl.DataGridContext).HorizontalGridLineBrush���5+     ��  �� *Self+$I
 C(local:DataGridControl.DataGridContext).HorizontalGridLineThickness�8   $	 Top��5,     �� 5.     $ verticalGridLineBorder��6   $��1��5/     $��2��50     ��51     ��  �� *Self+$C
 =(local:DataGridControl.DataGridContext).VerticalGridLineBrush���52     ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right��  54     $��0��65     58     $  groupLevelIndicatorPane��6)   $��1��59  )     5;     $��2��6    #��z��5<      #��z��5=      #��z��5>      #Q zP 5?      #S zR 5@      #U zT 5A      #8 zO 5B       . 5C      5E  	    5G     �� 5I     $ -1��5J      5I     ��  �� *TemplatedParent+$0
 *(local:GroupLevelIndicatorPane.GroupLevel)�.a�5K     �� $ groupLevelIndicatorPane��6    � y�$ 	Collapsed=�5M     �� 5N     $ verticalGridLineBorder��6    5P     ��  �� *Self+$G
 A(local:DataGridControl.DataGridContext).VerticalGridLineThickness�8  $ Right, Left�� � ��5Q     5U     �� 5Z     "  5[     .R�5]     �� $4 
Horizontal=�6   #��z��5^     .+�5`     �� $V titleTextBlock��6   #��zH 5a     $��0,0,10,0q�5b     �� 5d     $��0,0,0,10q�6   5e  	   5g     �� 5l     " # 5m     .R�5o     �� $ outerBorder��6   #��� ��5p     #��� ��5q     $��0,0,1,1q�5r     $ 1,1,0,0q�5s     ._�5u     �� $ innerBorder��6   #��� ��5v     $��0,0,1,1q�5w     $��1,1,0,0q�5x     #��z��5y     # z��5z     ._�5}     �� $3 contentPanel��6   $4 
Horizontal=�5~     .+�5�     �� #��z��6"   #��z��5�  "   #��z��5�  "   #��z��5�  "   #��z��5�  "   �� 5�     $ sortGlyphPresenter��6"   $��6,0,0,0q�5�  "   $y�Hidden=�5�  "   ��5�  "   Z� ��5�  "   ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph�5�  "   5�     5�     5�  	    5�     P� 5�     6 � ��7 . . �5�     �� $ outerBorder��6   # � ��5�      � ���� 5�     $ outerBorder��6    � ��$ 1q�5�     �� 5�     $ outerBorder��6    �@��Padding$ 0q�5�     �� 5�     $ innerBorder��6    � ��$ 1q�5�     �� 5�     $ innerBorder��6    � ��$ 0q�5�     �� 5�     $ contentPanel��6    � ��$ 	1,1,-1,-1q�5�     5�     �� 5�     $ 	Ascending��5�      5�     ��  �� *Self+$
 SortDirection�.a�5�     �� $ sortGlyphPresenter��6    5�     ��  �� *Self+$@
 :(local:DataGridControl.DataGridContext).AscendingSortGlyph� � ���� 5�     $ sortGlyphPresenter��6    � y�$ Visible=�5�     5�     �� 5�     $ 
Descending��5�      5�     ��  �� *Self+$
 SortDirection�.a�5�     �� $ sortGlyphPresenter��6    5�     ��  �� *Self+$A
 ;(local:DataGridControl.DataGridContext).DescendingSortGlyph� � ���� 5�     $ sortGlyphPresenter��6    � y�$ Visible=�5�     5�     5�     �� 5�     " $ 5�     .R�5�     �� $��Center=�6   $��Right=�5�     #��z��5�     #��z��5�     #��z��5�     5�     5�     