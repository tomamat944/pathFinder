   M S B A M L   `   `   `  ����F  BcPathFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:cPathFindercPathFinder  5   	       cPathFinder.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:cPathFinder     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      $	��10* �6   6+   �� 5      6   .+�5   
   �� -   5         ��Name$ btnStart��5      $��
Draw start��6#   $��0��68   $��0��6H   6W   �� 5   
   -   5        $ btnEnd��5      $��Draw end��6!   $��1��64   $��0��6D   6S   �� 5   
   -   5        $ btnWall��5      $��	Draw wall��6"   $��2��66   $��0��6F   6U   �� 5   
   -   5        $��canBoard��5      $	��800��6!   $	��400��6-   $��0��6:   $��1��6J   $��3��6W   
�������6   �� 5   
   -   5        $��comboAlgorithm��5      $��0��6)   $��2��69   $��2��6F   .@�5      �� $��Depth first search��6    �� 
IsSelected$
 True��68   6L   �� 5      $��Breadth first search��6   6<   �� 5      $��	A* search��6   61   5      �� 5   
   -   5        $��btnPath��5      $��	Draw path��6    $��2��64   $��2��6D   6S   5      5      