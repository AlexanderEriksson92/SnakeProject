   M S B A M L   `   `   `  ����G  CSnakeProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SnakeProjektSnakeProjekt  5   	       SnakeProjekt.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   &localclr-namespace:SnakeProjekt  5   	   -   5          � Title$  SnakeWindow��5	   	   $	��650��6   $	��950��6*   $	��350��66   $	��500��6F      BackgroundColor#��[  5
   	     GridBackgroundColor#��[ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     	AtariFont#��[ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 	TextScore��5      $��0��5      $��Center=�5      $��Center=�5      $��30(�5      $	��420��5       $	��760��5!      $
��Wrap=�5"      $��Score: 0��5#      $��10q�5$      �� 5%   
   -   5         ��Name$ 
GameBorder��5%      $��1��6%     	GridColor#��[ 5&      $��2q�5'      $��Center=�5(      $��Center=�5)       �� EdgeMode$ Aliased=�5*      ._�5+      A� -   5         A�Name$ GameGrid��5+       A� Columns$ 20��5,      	 A� Rows$	 20��5-      #��[  5.      
 J� SnapsToDevicePixels$

 True��5/       �� BitmapScalingMode$ HighQuality=�50      51      52      �� 53   
   -   5        $ Overlay��53      $��0��6"   #��[  54      $y�Visible=�55      $��0,40,0,0q�6&   $��2��68   ._�56      �� $��Center=�6   $��Center=�66   $	��522��6Q   $	��930��6^   .+�57      �� -   5        $ HighscoreText��58      $��
Highscores��59      $��Center=�5:      $��Center=�5;        HighScoreText#��[ 5<      $��30(�5=      $��10q�5>      $y�Hidden=�5?      �� 5@      -   5         ��Name$ HighscoreList��5@      $��Center=�5A      $��14(�5B      $	��300��5C      $	��300��5D      $y�Hidden=�5E      #��[ 5F        HighScoreTable#��[ 5G      #��[ 5H      $	��172��6I   ��5J      �� 5K      .R�5L      ��  �� Orientation$ 
Horizontal=�6)   .+�5M   "   �� $��Name: ��6,   $��5q�6:   6G   �� 5N   "   $��5q�6B   ��6,   �� *Name+6B   �� 5O   "   $��Score: ��6,   $��5q�6;   6H   �� 5P   "   $��5q�6C   ��6,   �� *Score+6C   5Q      5R      5T      �� 5U      -   5        $ OverLayText��5U      $��Center=�5V      $��Center=�5W      $��30(�5X      $��20q�5Y      $��Press space to start��5Z      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5[      -	   5          Name$ NameInputTextBox��5[   (   $��Center=�5\      $��Center=�5]      $y�	Collapsed=�5^       �� TextAlignment$ Center=�5_         	Watermark$ submit name...��5`      $	��300��5a      $��10q�5b      �� 5c      -
   5         ��Name$ HighscoreButton��5c      $��Center=�5d   
   $��Center=�5e   
   $��30(�5f   
   $��20 10q�5g   
   $��20q�5h   
   $��Submit��5i   
   $y�	Collapsed=�5j   
   5k   
   �� 5l      -   5        $ StartButton��5l      $��30(�5m      $��Start��5n      $��20 10q�5o      $y�Visible=�5p      $	��314��5q   3   �� 5r      -   5        $ SettingsButton��5r      $��Center=�5s      $��Settings��5t      $��10q�5u      $y�Visible=�5v      $	��174��5w   6   $��38��6B   5x      5y      5z      5{      