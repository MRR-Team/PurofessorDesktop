   M S B A M L   `   `   `  ����  
Purofessor7    1Purofessor.Views.Windows.Dialogs.CustomMessageBox   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Message��5   	   $	��200��5   	   $	��400��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	      BackgroundBrush#��[  5	   	    � 	Resources 5        DialogBackgroundBrush �� 
StartPoint �� EndPoint  GradientStartColor � Color � Offset  GradientEndColor  TitleBarStyle	 �� 
TargetType
 �� Property �� Value  SecondaryBrush  TitleBarTextStyle  ForegroundBrush  CloseButtonStyle �� 
TargetType �� Triggers P� Property P� Value 	 HoverBackgroundBrush 
 DialogButtonStyle  PrimaryBrush �� CornerRadius��%�  &	       7  7  &	 x     7  &	 �     7  &	 �    7  7 	 &	
      7  7  7 	 �� 5   
   $	 0,0&�6<   $	 1,1&�6M   .��5      � 8   $ 0Q�6G   � 5      8  $ 1Q�6E   5      �� 5   
   "	 �6&   .�5      �� 
 � ��$ 30��6'   �� 5      
 � ��8   6+   5      �� 5   
   "	 ��6*   .�5      �� 
 � ��$ Center=�62   �� 5      
 � ��$
 Bold"�6+   �� 5      
 � ��8   6+   �� 5      
 � ��$ 10,0,0,0q�6'   �� 5      
 � ��$ 14(�6)   5      �� 5    
   "	 ��6)   .�5!      �� 
 � ��$ 30��6&   �� 5"      
 � ��$ 30��6'   �� 5#      
 � ��
 ���� 6+   �� 5$      
 � ��8   6+   �� 5%      
 � ��$
 Bold"�6+   �� 5&      
 � ��$ 14(�6)   �� 5'      
 � �� 6,   Z� �� 5(      
 �@�Cursor$
 Hand��6'   �� 5)      
 � �� 5*      �� 5+      " ��6&   .R�5,      �� #��z��6!   ._�5-      �� $��Center=�6/   $��Center=�6L   5.      5/      51       52      P� 53       �@J�IsMouseOver$
 True��61   . �54      �� 
 � ��8  63   55      57      �� 5:   
   "	 ��6*   .�5<      �� 
 � ��$ 60��61   �� 5>      
 � ��$ 40��61   �� 5@      
 � ��$ 16(�61   �� 5D      
 � ��8   61   �� 5E      
 � ��8  61   �� 5F      
 � ��$
 14,6q�61   �� 5H      
 � ��$ 5q�61   �� 5I      
 � ��$ 0q�61   �� 5J      
 � ��$
 Bold"�61   �� 5K      
 �@�Cursor$
 Hand��61   �� 5N      
 �@�FocusVisualStyle 61   Z� �� 5Q      
 � �� 5R      �� 5S      " ��6&   .R�5T      �� #��z��6!   $ 8��5U      ._�5W      �� $��Center=�6/   $��Center=�5X   '   5Y      5Z      5\       5_      P� 5`       �@J�IsMouseOver$
 True��61   . �5a      �� 
 � ��8  63   5b      P� 5c       � ��$
 True��6/   . �5e      �� 
 �@J�Opacity$
 0.85Q�60   5f      5h      5j      .��5l      �� #��[ 6    �� Padding$ 10q�6A   ._�5m   
   �  � RowDefinitions 5n      �� 5o      $��30 �6    �� 5p      $��* �6    �� 5q      $
��Auto �6    .+�5u      � -   5        $��0��5u      #��[ 6    .+�5v      �� #��[ 5w      ��5v      �� *Title+ �� RelativeSource ��  �� AncestorType
 Window5w      �� 5x      -   5        $��X��5x      #��[ 5y      $��Right=�5z      $	��Top=�5{      5|      5}      �� 5�      -   5         ��Name$ MessageText��5�      $��1��5�      #��[ 5�      $��16(�5�      $
��Wrap=�5�      $��10q�5�       �� TextAlignment$
 Left=�5�      �� 5�      $��2��6    �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��10q�5�      .+�5�      �� -   5         ��Name$ OkButton��5�      $��OK��5�      #��[
 5�      $y�	Collapsed=�5�      �� 5�      -   5        $ 	YesButton��5�      $	��Yes��5�      #��[
 5�      $y�	Collapsed=�5�      �� 5�      -   5        $ NoButton��5�      $��No��5�      #��[
 5�      $y�	Collapsed=�5�      5�      5�      5�      5�      