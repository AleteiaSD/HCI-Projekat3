   M S B A M L   `   `   `  ????M  IPZ3-NetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PZ3_NetworkService.ViewsPZ3_NetworkService.Views  5      K*clr-namespace:PZ3_NetworkService.ViewModelPZ3_NetworkService.ViewModel  5      ?$clr-namespace:PZ3_NetworkService.VMLPZ3_NetworkService.VML  5      C&clr-namespace:PZ3_NetworkService.ModelPZ3_NetworkService.Model  5
      *    $PZ3_NetworkService.Views.UredjajView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PZ3_NetworkService.Views     5      @	ViewModel*clr-namespace:PZ3_NetworkService.ViewModel     5      4vml$clr-namespace:PZ3_NetworkService.VML     5      7data&clr-namespace:PZ3_NetworkService.Model     5
      -   'PZ3_NetworkService.VML.ViewModelLocator    AutoHookedUpViewModel  . .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   .+?5      &   System.Windows.Controls.DataGrid  
???????   AutoGenerateColumns .     CanUserAddRows .  $	??406??6?   $
??10,0q?6?   ??6G   ??  ?? Path$ Uredjaji? ?? UpdateSourceTrigger$ PropertyChanged=? ?? SelectedItem 6?   ?? *SelectedUredjaj+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   ?? *Id+6L     5      $
 Name??6)   $		 220 6P   
 67   ?? *Name+6P     5      $ Value??6)   $		 150 6w   
 68   ?? *Value+$ PropertyChanged=?6w     5      $
 Type??6)   $	 * 6\   
 67   ?? *TypeUredjaj.Name+6\   5      ?? 5      $ 
Horizontal=?6   $??Bottom=?62   $??Center=?6M   $	??120??6j   $??10,30,118,0q?6w   $	??512??6?   .+?5      ?? $ Vertical=?6   .+?5      ?? $??ID??6    $??20(?6*   $??80??68   $??40??6C    ?? TextAlignment$ Center=?6O   ?? 5      $
??Name??6    $??20(?6,   $??80??6:   $??40??6E   $ Center=?6Q   ?? 5      $
??Type??6    $??20(?6,   $??80??6:   $??40??6E   $ Center=?6Q   5      ?? 5      $ Vertical=?6   .+?5      ?? $	??200??6C   $??40??6O    ? ToolTip$ ID must be unique??6[   
?????????6   ?? *IdText+ ?? Mode$ TwoWay=?6w   ?? 5       $	??200??6E   $??40??6Q   
?????????6   ?? *
NameText+$ TwoWay=?6]   ?? 5!      -   5         ??Name$ cbType2??5!      
??????? ?? Text$ Select option??6?   $	??200??6?   $??40??6?   ??6D   ?? *UredjajTypes+$ TwoWay=?$ PropertyChanged=? 6?   ?? *SelectedTypeUredjaj2+6?   5#      ?? 5$      $??13??6   ?? 5%      -   5         ??Name$ 	imgImgSrc??5%      $	??100??6h   $	??100??6t   ??6+   ?? *Path+$ PropertyChanged=?6t   ?? 5&      $??10??6   ?? 5'      $ Vertical=?6   $??Center=?64   .+?5(      ?? -   5         ??Name$ btnAdd??5(      ???	#FF61F759$	??Add??6D   $	??100??6R   $??40??6^   $
??Bold"?6?   $??16(?6?   ??6j   ?? *
AddCommand+6?   ?? 5)      -   5        $ 	btnDelete??5)      ???	#FF61F759$??Delete??6G   $	??100??6X   $??40??6d   $??16(?6?   $
??Bold"?6?   ??6p   ?? *DeleteCommand+6?   5*      5,      5-      ?? 5.   
   $1??+Normal value is between 670 and 735 liters.??6   $ Center=?6H   $
??Wrap=?6_   $??297,410,10,524q?6s   
???????$
??Bold"?6?   $??14(?6?   $??Italic$?6?   	? 50   
   -   5         	?Name$ rbName??50      $
??Name??6&   $??20(?65   $	??rb1??6w   $??122,584,414,346q?6?   $??Center=?6?    d? 	IsChecked 6C   ?? *RbName_isChecked+$ TwoWay=?6?   	? 51   
   -   5        $ rbType??51      $
??Type??6&   $??20(?65   $	??rb2??6w   $??122,619,414,306q?6?   $??Center=?6?    6C   ?? *RbType_isChecked+$ TwoWay=?6?   ?? 52   
   -   5         ??Name$ 	tblSearch??52      $??
Search in:??6'   $??20,605,523,323q?69   $??20(?6Q   ?? 53   
   -   5         ??Name$ tbSearch??53      
???????$??17(?6P   $??297,596,203,323q?6^   ??68   ?? *Search+6^   ?? 54   
   -	   5        $ btnReset??54      ???	#FFE6E655$??RESET??6:   $??20(?6J   $??297,700,237,225q?6X   ??6q   ?? *ResetCommand+?? 55   
   -
   5        $ search??55      ???	#FFE6E655$??SEARCH??68   $??100,700,434,225q?6?    ? Cursor$
 Hand??6?   $??20(?6?   ??6I   ?? *SearchCommand+$ PropertyChanged=?6?   ?? 57   
   -   5        $
 undo??57      ???	#FFFF6060$
??UNDO??66   $??30(?6E   $??373,779,72,131q?6?   $
 Hand??6?   ??6S   ?? *UndoCommand+$ PropertyChanged=?59      5;      5<      