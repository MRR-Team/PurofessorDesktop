   M S B A M L   `   `   `  ����   
Purofessor7    1Purofessor.Views.Windows.Dialogs.CustomMessageBox   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Message��$	��200��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�   BackgroundBrush#��[   � 	Resources   DialogBackgroundBrush �� 
StartPoint �� EndPoint  GradientStartColor � Color � Offset  GradientEndColor  TitleBarStyle	 �� 
TargetType
 �� Property �� Value  SecondaryBrush  TitleBarTextStyle  ForegroundBrush  CloseButtonStyle �� 
TargetType �� Triggers P� Property P� Value 	 HoverBackgroundBrush 
 DialogButtonStyle  PrimaryBrush �� CornerRadius��%|  &	       7  7  &	 @     7  &	 u     7  &	 �     7  7 	 &	
 G    7  7  7 	 �� $	 0,0&�$	 1,1&�.��� 8   $ 0Q�� 8  $ 1Q��� "	 �.��� 
 � ��$ 30���� 
 � ��8   �� "	 ��.��� 
 � ��$ Center=��� 
 � ��$
 Bold"��� 
 � ��8   �� 
 � ��$ 10,0,0,0q��� 
 � ��$ 14(��� "	 ��.��� 
 � ��$ 30���� 
 � ��$ 30���� 
 � ��
 ���� �� 
 � ��8   �� 
 � ��$
 Bold"��� 
 � ��$ 14(��� 
 � �� Z� �� 
 �@�Cursor$
 Hand���� 
 � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 
 � ��8  �� "	 ��.��� 
 � ��$ 60���� 
 � ��$ 40���� 
 � ��$ 16(��� 
 � ��8   �� 
 � ��8  �� 
 � ��$
 14,6q��� 
 � ��$ 5q��� 
 � ��$ 0q��� 
 � ��$
 Bold"��� 
 �@�Cursor$
 Hand���� 
 �@�FocusVisualStyle Z� �� 
 � �� �� " ��.R��� #��z��$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 
 � ��8  P�  � ��$
 True��. ��� 
 �@J�Opacity$
 0.85Q�.���� #��[  �� Padding$ 10q�._��  � RowDefinitions �� $��30 ��� $��* ��� $
��Auto �.+�� -   $��0��#��[ .+��� #��[ ���� *Title+ �� RelativeSource ��  �� AncestorType
 Window�� -   $��X��#��[ $��Right=�$	��Top=��� -    ��Name$ MessageText��$��1��#��[ $��16(�$
��Wrap=�$��10q� �� TextAlignment$
 Left=��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -    ��Name$ OkButton��$��OK��#��[
 $y�	Collapsed=��� -   $ 	YesButton��$	��Yes��#��[
 $y�	Collapsed=��� -   $ NoButton��$��No��#��[
 $y�	Collapsed=�