   M S B A M L   `   `   `  ����  
Purofessor(    "Purofessor.Views.Pages.Admin.Users   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Users��5	      .��5      � .+�5   
   ��    MainBorderStyle#��[  6   ._�5      � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      ��   UserListTitle#���  6   $��20(�5      $
��Bold"�5        ForegroundBrush#���  5      $��Center=�5      $��0,0,0,20q�5      &   System.Windows.Controls.DataGrid  5      -   5        $��UsersDataGrid��5         
IsReadOnly$
 True��5      $��1��5         AutoGenerateColumns$ False��5        BackgroundBrush#���  5      #���  5        PrimaryBrush#��[ 5       $��1q�5!         HeadersVisibility$ Column=�5"         GridLinesVisibility$
 None=�5#         RowBackground# �  5$      $��14(�5%      $��SemiBold"�5&         	RowHeight$ 35Q�5'         ColumnHeaderHeight$ 30Q�5(      $
��Auto=�5)      $��0,0,0,10q�5*        AdminDataGridRowStyle	   RowStyle#	 [ 5+       " AdminDataGridColumnHeaderStyle
   ColumnHeaderStyle#
 [ 5,         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/        ColumnId,  &System.Windows.Controls.DataGridColumn   Header# �  6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *Id+6h     50        
ColumnNick# �  6-   $ * 6l    6S   �� *Name+6l     51       	 ColumnEmail# � 	 6-   $ * 6n    6T   �� *Email+6n   4  .System.Windows.Controls.DataGridTemplateColumn  52       
 ColumnActions# � 
 61   $
 Auto 6Z      CellTemplate 53      �� 54   "   .R�55   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�56   *   �� -   5          TopPanelButtonStyle#���  56   1     
EditButton#���  57   1   $��0,0,5,0q�59   1   $
��10,3q�5:   1   
 � Tag 5;   1   �� �� 5=   *   -   5        #���  5=   1     DeleteButton#���  5>   1   $��0,0,5,0q�5?   1   $
��10,3q�5A   1    5B   1   �� 5C   '   5D   #   5F      5H      5J      5K      5L      5M      