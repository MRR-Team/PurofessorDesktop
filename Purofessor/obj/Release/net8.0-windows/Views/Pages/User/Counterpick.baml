   M S B A M L   `   `   `  ����   
Purofessor-    'Purofessor.Views.Pages.User.Counterpick   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  Counterpick��.��� .+���    MainBorderStyle#���   ._��� $
��Auto=�.����   ContentStackPanelStyle#���  .+���   ChooseChamp#���  $��24(�$
��Bold"�  ForegroundBrush#���   �� TextAlignment$ Center=�$��0,0,0,20q���   ChampionName#���  $��SemiBold"�#���  � .+��� -   $��EnemyChampTextBox��4  .System.Windows.Automation.AutomationProperties   AutomationId$ EnemyChampTextBox��$��30��$��0,5,0,5q�  BackgroundBrush#���  #���  $��Center=�� -   $��SuggestionsPopup��$��Bottom=� � 	StaysOpen$ False�� � PlacementTarget ��  �� ElementName$ EnemyChampTextBox��.���� #���  $��1q�
������� �� CornerRadius$ 4��$	��150��._��� -   $��SuggestionsListBox��#���  #���  $��0q�$
��Auto=����� *ActualWidth+$ EnemyChampTextBox����   	ChoosePos#���  $��SemiBold"�#���  $��0,10,0,5q��� -   $��PositionStackPanel�� �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,15q�.+�	� -   $��	RadioSupp��$ 	RadioSupp��  Supp#���   	� 	GroupName$ Pozycje��  ButtonRadioStyle#���  	� -   $��RadioBottom��$ RadioBottom�� 
	 Bottom#��� 	 $ Pozycje��#���  	� -   $��RadioMid��$ RadioMid�� 
 Mid#��� 
 $ Pozycje��#���  	� -   $��RadioJungle��$ RadioJungle�� 
 Jungle#���  $ Pozycje��#���  	� -	   $��RadioTop��$ RadioTop��  Top#���  $ Pozycje��#���  �� -
     
GenCounter#���  $ GenerateCounterButton��$��35��  GradientStartBrush#���  #���  $
��Bold"��� -   $��ResultScrollViewer��$��0,15,0,0q�$y�	Collapsed=�$
��Auto=�$��Disabled=�$
��Auto��.���� -   $ ��CounterResultsItemsControl��$  CounterResultsItemsControl������ .R�� $��Center=����� 	 �� ResourceKey$	 ResultTileTemplate��