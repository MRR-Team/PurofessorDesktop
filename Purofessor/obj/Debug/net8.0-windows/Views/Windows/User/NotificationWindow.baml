   M S B A M L   `   `   `  ����  
Purofessor6    0Purofessor.Views.Windows.User.NotificationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 
ResizeMode$  NoResize=�5      $	��850��5   	   $	��400��5	   	      MainBackgroundGradient#���   5   	    � 	Resources 5       �� 
StartPoint �� EndPoint  WindowGradientStartColor � Color � Offset��%�   &	        �� 5   
   $	 0,0&�6=   $	 1,1&�6N   .��5      � # �  6   $ 0Q�6N   � 5      # �  6   $ 1Q�6N   5      5      .��5      � .+�5   
   ��   MainBorderStyle#��[ 6    �� Padding$ 10q�6:   $��30q�6G   ._�5      � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      ��   NotificationsTitle#���  6   $��20(�5      $
��Bold"�5        ForegroundBrush#���  5      $��Center=�5      $��0,0,0,0q�5       &   System.Windows.Controls.DataGrid  5"      -   5        $��NotificationsDataGrid��5"         
IsReadOnly$
 True��5#      $��1��5$      	   AutoGenerateColumns$	 False��5%      
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 5&        BackgroundBrush#���  5'      #���  5(        PrimaryBrush#��[ 5)      $��1q�5*         HeadersVisibility$ Column=�5+         GridLinesVisibility$
 None=�5,         RowBackground# �  5-      $��14(�5.      $��SemiBold"�5/         	RowHeight$ 35Q�50         ColumnHeaderHeight$ 30Q�51       " AdminDataGridColumnHeaderStyle   ColumnHeaderStyle# [ 52        AdminDataGridRowStyle   RowStyle# [ 53      $��Visible=�54      $��Disabled=�55      $��0,0,0,10q�56         Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59       	 ColumnTitle,  &System.Windows.Controls.DataGridColumn   Header# � 	 6-      Width$	 150 6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *
Data.Title+6s     5:       
 
ColumnBody# � 
 6-   $ * 6q    6S   �� *	Data.Body+6q     5;        
ColumnType# �  6-   $	 120 6q    6S   �� *	Data.Type+6q     5<        
ColumnDate# �  6-   $	 180 6q    6S   �� *	CreatedAt+6q   5>      5?      5@      5A      5B      