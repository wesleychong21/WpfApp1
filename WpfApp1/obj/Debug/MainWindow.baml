   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Unsafe Record��5   	   $	��650��6   $
��1000��6,   .��5	      ]� ��. $	��Top=�6%   .+�5
   
   �� -   5         ��Name$ tbtMain��5
      $��47��6&   $��0q�62   $��Center=�6=   $	��Top=�6X    �� Orientation$ 
Horizontal=�6m   .+�5      �� -   5         ��Name$ btnNew��5   1    � ToolTip$	 New��6   $	��New��6#   $��Center=�6A   $��Stretch=�6^   $��30��6z   $��80��6�   $��5q�6�   6�   �� 5      -   5        $ btnEdit��5      $
 Edit��6&   $
��Edit��65   $��Center=�6D   $��Stretch=�6a   $��30��6}   $��80��6�   6�   �� 5      -   5        $ 	btnDelete��5   7   $ Delete��6   $��Delete��6&   $��Center=�6J   $��Stretch=�6g   $��30��6�   $��80��6�   $��5q�6�   6�   �� 5      -   5        $ 
btnRefresh��5      $ Refresh��6)   $��Refresh��6;   $��Center=�6M   $��Stretch=�6j   $��30��6�   $��80��6�   $��5q�6�   6�   �� 5      -   5        $ 	btnReport��5      $ Report��6(   $��Report��69   $��Center=�6J   $��Stretch=�6g   $��30��6�   $��80��6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgRecords��5      $	��Top=�6?      
IsReadOnly .    SelectionMode$ Single=�6f      AutoGenerateColumns .  ��6'   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Observer��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
Observer+  5      $
 Observee��6%   $ * 67    6A   �� *
Observee+  5      $
 Title��6%   $ * 64    6>   �� *Title+  5      $

 Task��6%   $ * 63    6=   �� *Detail+  5      $
 Obsevertion Date��6%   $ * 6?    6I   �� *
ReportDate+ �� StringFormat$ {0:dd-MM-yyyy }��5      5      5      