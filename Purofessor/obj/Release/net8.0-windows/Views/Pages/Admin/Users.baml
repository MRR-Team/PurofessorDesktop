   M S B A M L   `   `   `  ����   
Purofessor(    "Purofessor.Views.Pages.Admin.Users   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  Users��.��� .+���    MainBorderStyle#��[  ._�� $��20q� � RowDefinitions �� $
��Auto ��� $��* �.+���   UserListTitle#���  $��20(�$
��Bold"�  ForegroundBrush#���  $��Center=�$��0,0,0,20q�&   System.Windows.Controls.DataGrid  -   $��UsersDataGrid��   
IsReadOnly$
 True��$��1��   AutoGenerateColumns$ False��  BackgroundBrush#���  #���    PrimaryBrush#��[ $��1q�   HeadersVisibility$ Column=�   GridLinesVisibility$
 None=�   RowBackground# �  $��14(�$��SemiBold"�   	RowHeight$ 35Q�   ColumnHeaderHeight$ 30Q�$
��Auto=�$��0,0,0,10q�  AdminDataGridRowStyle	   RowStyle#	 [  " AdminDataGridColumnHeaderStyle
   ColumnHeaderStyle#
 [    Columns 0  *System.Windows.Controls.DataGridTextColumn    ColumnId,  &System.Windows.Controls.DataGridColumn   Header# �     Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+    
ColumnNick# �  $ *  �� *Name+   	 ColumnEmail# � 	 $ *  �� *Email+4  .System.Windows.Controls.DataGridTemplateColumn   
 ColumnActions# � 
 $
 Auto    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -     TopPanelButtonStyle#���    
EditButton#���  $��0,0,5,0q�$
��10,3q�
 � Tag �� �� -   #���    DeleteButton#���  $��0,0,5,0q�$
��10,3q� �� 