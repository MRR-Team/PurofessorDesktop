   M S B A M L   `   `   `  ����   
Purofessor,    &Purofessor.Views.Pages.User.BuildMaker   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  
BuildMaker��$
��Auto��$��Stretch=�.��� .+���    MainBorderStyle#��[  ._��� $
��Auto=�.����   ContentStackPanelStyle#��[ .+���   EnterChampionsPrompt#���  $��24(�$
��Bold"�  ForegroundBrush#���   �� TextAlignment$ Center=�$��0,0,0,20q���   YourChampion#���  $��SemiBold"�#���  � .+��� -    ��Name$ MyChampionTextBox��$��30��$��0,5,0,5q�  BackgroundBrush#���  #���  $��Center=�� -   $��MyChampPopup��$��Bottom=� � 	StaysOpen$ False�� � PlacementTarget ��  �� ElementName$ MyChampionTextBox��.���� #���  $��1q�
������� �� CornerRadius$ 4��$	��150��._��� -   $��MyChampSuggestions��#���  #���  $��0q�$
��Auto=����� *ActualWidth+$ MyChampionTextBox����   EnemyChampion#���  $��SemiBold"�#���  � .+��� -   $ EnemyChampionTextBox��$��30��$��0,5,0,5q�#���  #���  $��Center=�� -   $��EnemyChampPopup��$��Bottom=�$ False�� �� $ EnemyChampionTextBox��.���� #���  $��1q�
�������$ 4��$	��150��._��� -   $��EnemyChampSuggestions��#���  #���  $��0q�$
��Auto=����� *ActualWidth+$ EnemyChampionTextBox���� -    ��Name$ GenerateCounterButton��  GenerateBuildButton#���  $��35��  GradientStartBrush#���  #���  $
��Bold"�4  .System.Windows.Automation.AutomationProperties   AutomationId$ GenerateBuildButton���� -   	 ��Name$	 ResultScrollViewer��$��0,15,0,0q�$y�	Collapsed=�$
��Auto=�$��Disabled=�$
��Auto��.���� -	   
 ��Name$
 BuildResultsItemsControl������ .R�� $��Center=�����  �� ResourceKey$ ResultTileTemplate��