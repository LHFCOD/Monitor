   M S B A M L   `   `   `  ���� B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor      Monitor.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Monitor     
�������.���   � RowDefinitions  �� $	��50* ��� $
��199* ��� $	��44* �.+���  �� Orientation$ 
Horizontal=�$��0��.+��� $��15(�$
��Bold"�$��Center=�$��Center=�$
��Left=�$��59��$��	0,0,0,-11q�$��32��$	��Top=�$��时间���� -    ��Name$ TimeControl��$��15(�$��Center=�$
��Left=�$	��154��$��	0,0,0,-11q�$��32��$	��Top=��� $��15(�$
��Bold"�$��Center=�$
��Left=�$��Center=�$��66��$��温度��$��	0,0,0,-11q�$��32��$	��Top=��� -    ��Name$ TControl��$��Center=�$��Center=�$	��333��$��	0,0,0,-11q�$��77��$��32��$	��Top=��� $��15(�$
��Bold"�$��Center=�$
��Left=�$��Center=�$��65��$��K��$��	0,0,0,-11q�$��32��$	��Top=���    MyImage#��[  $��1��$��0,0,0,41q�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��   RowHeaderWidth$ 0Q�$��2��   AutoGenerateColumns .  �� AlternationCount$ 2��$��1q�   MinColumnWidth$	 160Q�	   ColumnWidth	 �� *ActualWidth+  WholeWidthToLocalConverter
 �� 	Converter#
 [  �� Mode$ OneWay=� �� RelativeSource �� *Self+