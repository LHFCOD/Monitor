   M S B A M L   `   `   `  ����B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor  5          Monitor.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Monitor     5      
�������.��5      �   � RowDefinitions  5	   
   �� 5
      $	��50* �6   �� 5      $
��199* �6   �� 5      $	��44* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �� $��15(�6   $
��Bold"�6"   $��Center=�64   $��Center=�6X   $
��Left=�6{   $��59��6�   $��	0,0,0,-11q�6�   $��32��6�   $	��Top=�6�   $��时间��6�   �� 5      -   5         ��Name$ TimeControl��5   #   $��15(�6   $��Center=�68   $
��Left=�6Z   $	��154��6u   $��	0,0,0,-11q�6�   $��32��6�   $	��Top=�6�   �� 5      $��15(�6   $
��Bold"�6"   $��Center=�64   $
��Left=�6W   $��Center=�6r   $��66��6�   $��温度��6�   $��	0,0,0,-11q�6�   $��32��6�   $	��Top=�6�   �� 5      -   5         ��Name$ TControl��5      $��Center=�6(   $��Center=�6J   $	��333��6n   $��	0,0,0,-11q�6y   $��77��6�   $��32��6�   $	��Top=�6�   �� 5      $��15(�6   $
��Bold"�6"   $��Center=�64   $
��Left=�6X   $��Center=�6s   $��65��6�   $��K��6�   $��	0,0,0,-11q�6�   $��32��6�   $	��Top=�6�   5      �� 5   
      MyImage#��[  6   $��1��62   $��0,0,0,41q�6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         RowHeaderWidth$ 0Q�6&   $��2��6:      AutoGenerateColumns .  �� AlternationCount$ 2��6b   $��1q�6w      MinColumnWidth$	 160Q�6�   	   ColumnWidth	 6�   �� *ActualWidth+  WholeWidthToLocalConverter
 �� 	Converter#
 [  �� Mode$ OneWay=� �� RelativeSource �� *Self+5!      5#      5$      