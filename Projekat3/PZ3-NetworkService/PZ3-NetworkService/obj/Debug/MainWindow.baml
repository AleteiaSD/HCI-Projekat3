   M S B A M L   `   `   `  ????M  IPZ3-NetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PZ3_NetworkServicePZ3_NetworkService  5   	   C&clr-namespace:PZ3_NetworkService.ViewsPZ3_NetworkService.Views  5   	   K*clr-namespace:PZ3_NetworkService.ViewModelPZ3_NetworkService.ViewModel  5   	   #    PZ3_NetworkService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PZ3_NetworkService     5   	   8views&clr-namespace:PZ3_NetworkService.Views     5   	   @	viewModel*clr-namespace:PZ3_NetworkService.ViewModel     5   	     ? Title$  Pracenje potrosnje vode??5
   	   $	??960??6)   $	??640??66    ? DataContext 5      ,   &PZ3_NetworkService.MainWindowViewModel  5   
    ? 	Resources 5       ?? DataType0   *PZ3_NetworkService.ViewModel.HomeViewModel'   !PZ3_NetworkService.Views.HomeView3   -PZ3_NetworkService.ViewModel.UredjajViewModel*   $PZ3_NetworkService.Views.UredjajView2   ,PZ3_NetworkService.ViewModel.ReportViewModel)   #PZ3_NetworkService.Views.ReportView.   (PZ3_NetworkService.ViewModel.DDViewModel%	   PZ3_NetworkService.Views.DDView0
   *PZ3_NetworkService.ViewModel.GrafViewModel'   !PZ3_NetworkService.Views.GrafView??%w  (??       5      *, +)(?? 2     5      *, +)(?? d     5      *, +)(?? ?     5      *, +)(?? ?     5      *,
 +)?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5        5      ?? 5   
   "  6   .R?5      	  5      ?? 5   
   " 
 6   .R?5        5      5       .??5!      ? ???	#FF1F81EA ? RowDefinitions 5"   
   ?? 5#      $
??Auto ?6   ?? 5$      $
??Auto ?6   ?? 5%      $
??Auto ?6   ?? 5&      $
??Auto ?6   .+?5(   
   ]? $??0??6   $??5q?6!   .+?5)      o? $	??Top=?6   
????? ?.@?5*      m? $??Tabela??6    m? CommandParameter$ Tabela??5+       m? Command 5*   +   ?? *
NavCommand+5+      m? 5,      $??Izvestaj??6   $ Report??5-       5,   -   ?? *
NavCommand+5-      m? 5.      $??Vizuelni prikaz??6   $ Vizuelni prikaz??5/       5.   4   ?? *
NavCommand+5/      m? 50      $
??Graf??6   $
 Graf??51       50   )   ?? *
NavCommand+51      52      53      ]? 54   
   $??92,780,420,2763q?6   $??1??6-   .+?55      o? $	??120??6   
????? ?.@?56      m? $?? HOME??6   $??30(?6I   $ Pocetak??57      $??45??66   $	??120??6B    56   *   ?? *
NavCommand+57   B   58      59      ? 5;   
   $??1??6   .+?5<      ?? $??4??6B   $??
0,0,0,2632q?6V   ??6   ?? *CurrentViewModel+6V   5=      5>      5?      