   M S B A M L   `   `   `  ����   
Purofessor6    0Purofessor.Views.Windows.User.NotificationWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 
ResizeMode$  NoResize=�$	��850��$	��400��   MainBackgroundGradient#���    � 	Resources  �� 
StartPoint �� EndPoint  WindowGradientStartColor � Color � Offset��%N   &	        �� $	 0,0&�$	 1,1&�.��� # �  $ 0Q�� # �  $ 1Q�.��� .+���   MainBorderStyle#��[  �� Padding$ 10q�$��30q�._�� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+���   NotificationsTitle#���  $��20(�$
��Bold"�  ForegroundBrush#���  $��Center=�$��0,0,0,0q�&   System.Windows.Controls.DataGrid  -   $��NotificationsDataGrid��   
IsReadOnly$
 True��$��1��	   AutoGenerateColumns$	 False��
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 *   BackgroundBrush#���  #���    PrimaryBrush#��[ $��1q�   HeadersVisibility$ Column=�   GridLinesVisibility$
 None=�   RowBackground# �  $��14(�$��SemiBold"�   	RowHeight$ 35Q�   ColumnHeaderHeight$ 30Q� " AdminDataGridColumnHeaderStyle   ColumnHeaderStyle# [   AdminDataGridRowStyle   RowStyle# [ $��Visible=�$��Disabled=�$��0,0,0,10q�   Columns 0  *System.Windows.Controls.DataGridTextColumn   	 ColumnTitle,  &System.Windows.Controls.DataGridColumn   Header# � 	    Width$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Data.Title+   
 
ColumnBody# � 
 $ *  �� *	Data.Body+    
ColumnType# �  $	 120  �� *	Data.Type+    
ColumnDate# �  $	 180  �� *	CreatedAt+