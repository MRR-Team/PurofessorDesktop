   M S B A M L   `   `   `  ����E  APurofessor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Purofessor.components.PanelComponents%Purofessor.components.PanelComponents  5      $    Purofessor.components.TopPanel   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Bpc3clr-namespace:Purofessor.components.PanelComponents     5      $
��auto��5      $��60��5        � 	Resources  5         TopPanelButtonStyle �� 
TargetType �� Property �� Value  ForegroundBrush  SecondaryBrush �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value  HoverBackgroundBrush  PrimaryBrush��%�  &	        �� 5   
   " ��6,   .�5	      ��  � ��
 ���� 6+   �� 5
       � ��# �  6+   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$
 10,6q�6(   �� 5       � ��$ 0,0,10,0q�6'   �� 5       � ��# �  6,   �� 5       � ��$ 0,0,0,2q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 6��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
	 True��61   . �5       ��  � ��# �  63   �� 5!       � ��# �  64   5"      5$      5%      .��5'      � .+�5(   
   �� $��Center=�6   $��60��6/   ��5)      �� 5*      
 �� 
StartPoint$	
 0,0&�6&    �� EndPoint$	 1,0&�67   .��5+      �   GradientStartColor � Color# �  6#    � Offset$ 0Q�6P   � 5,        GradientEndColor# �  6#   $ 1Q�6N   5-      5/      � 51   
   $��
10,15,10,0q�6   $	��Top=�6#   $��30��6;    � ColumnDefinitions 52      �� 53      $
��Auto �6#   �� 54      $��* �6#   �� 55      $
��Auto �6#   .+�59      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $
��Left=�6B   $��Center=�6]   .+�5:      �� -   5         ��Name$ KontraButton��5<      #���   5:        CounterButton#���  5;      5=      �� 5>      -   5        $ StatusButton��5@      #���   5>        ServerStatusButton#���  5?      5A      5B      �� 5E      $ 
Horizontal=�6   $��2��62   $��Center=�6B   $��5,0,0,0q�6]   .+�5F      9   3Purofessor.components.PanelComponents.ThemeSelector  $��Center=�6#   $��0,0,5,0q�6>   �� 5H       	 ProfileButtonHi#��� 	 6   $��22��5I       �� Padding$ 0,4,0,0q�5J      
������ #���  5L      $��Right=�5M      $��Center=�5N      �� 5P      -   5         ��Name$ ProfileUsername��5P      $��22��5Q      $ 0,4,0,0q�5R      
������ #���  5T      $��Right=�5U      $��Center=�5V       J� IsHitTestVisible$ False��5W      �� 5Y      -   5        $ ProfileButton��5Y      $��30��5Z      $��30��5[      $��0,0,10,0q�5\      $��0q�5]      
������  � ToolTip$ Profil��5_      .��5a      �� $0��*pack://application:,,,/Images/UserIcon.png��6   $��30��6P   $��30��6[   5b      8   2Purofessor.components.PanelComponents.LogoutButton  5d      $��Center=�6"   $��Right=�6=   $��5,0,0,0q�6Y   5e      5f      5g      5h      