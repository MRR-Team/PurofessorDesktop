   M S B A M L   `   `   `  ���� E  APurofessor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Purofessor.components.PanelComponents%Purofessor.components.PanelComponents  $    Purofessor.components.TopPanel   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bpc3clr-namespace:Purofessor.components.PanelComponents     $
��Auto��$��60��.��� .+��� $��0��$��2��$��Stretch=�$��Stretch=�$��60������   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,0&�.���    GradientStartColor � Color# �    � Offset$ 0Q��   GradientEndColor# �  $ 1Q�� $��
10,15,10,0q�$	��Top=�$��30�� � ColumnDefinitions �� $��* ��� $
��Auto �.+��  � Orientation$ 
Horizontal=�$��0��.+��� -    ��Name$ KontraButton��  TopPanelButtonStyle#���    CounterButton#���  �� -   $ BuildMakerButton��#���    GenerateBuildButton#���  �� -   $ StatusButton��#���    ServerStatusButton#���  �� -   $ ShowRotationsButton��#���    RotationButton#���  ��  �� Orientation$ 
Horizontal=�$��1��$	��Top=�.+���   ProfileButtonHi#���  $��22�� �� Padding$ 0,4,0,0q�
������   ForegroundBrush#���  $��Center=��� -   	 ��Name$	 ProfileUsername��$��22��$ 0,4,10,0q�
������ #���  $��Center=�
 J� IsHitTestVisible$
 False������ *LoggedUser.Name+ �� StringFormat$ , {0}��:   4Purofessor.components.PanelComponents.SettingsButton  -     Name$ settingsButton���� -   $ NotificationButton��$
��🔔��
�������$��20(�$��30��$��30��$��0,0,10,0q�$��0q� 	 SettingsBrush#��� 	  � ToolTip$ Powiadomienia���� -   $ ProfileButton��$
��👤��
�������$��20(�$��30��$��30��$��0,0,10,0q�$��0q�#��� 	 $ Profil��8   2Purofessor.components.PanelComponents.LogoutButton  $��Center=�$��Right=�$��5,0,0,0q�