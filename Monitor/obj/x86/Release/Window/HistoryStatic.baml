   M S B A M L   `   `   `  ���� B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor  Y UWPFVisifire.Charts, Version=5.1.2.0, Culture=neutral, PublicKeyToken=0cd785983078370bM9clr-namespace:Visifire.Charts;assembly=WPFVisifire.ChartsVisifire.Charts     Monitor.HistoryStatic   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Monitor     Nvisifire9clr-namespace:Visifire.Charts;assembly=WPFVisifire.Charts     X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47Toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  Y UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f=d34http://research.microsoft.com/DynamicDataDisplay/1.0  -   .���   � RowDefinitions  �� $	��20* ��� $
��152* ��� $
��111* �.+���  �� Orientation$ 
Horizontal=�$��0��$
��Left=�.+��� -   $��preSelectIndex��$
��Left=�$	��103��$��32��$	��Top=�$��Center=�$��	0,0,0,-11q��� $��温度��$��Center=�$��Center=�$��32��$	��Top=�$��	0,0,0,-11q�$��15(�$
��Bold"��� -   $��TControl��$	��333��$��Center=�$��Center=�$��32��$	��Top=�$��	0,0,0,-11q�$��56��$��15(��� $��K��$��Center=�$��Center=�$��32��$	��Top=�$��	0,0,0,-11q�$��15(�$
��Bold"�&   Xceed.Wpf.Toolkit.DateTimePicker  -   $��	startTime��&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�   FormatString$ yyyy/MM/dd HH:mm:ss��$
��Left=�$	��177��$��32��$	��Top=�$��	0,0,0,-11q��� $	��至��$��Center=�$��Center=�$��32��$	��Top=�$
��Left=�$��42��$��15(�$
��Bold"�  -   $��endTime��$ Custom=�$ yyyy/MM/dd HH:mm:ss��$
��Left=�$	��153��$��32��$	��Top=��� -   $
��Left=�$��53��$��32��$	��Top=�
����·�$��15(�$
��Bold"�.��查询�� -      ButtonStyle2#��[  $
��Left=�$��32��$��32��$	��Top=� � Cursor$
 Hand���� $��1�����	#FFD2E60C$��0,0,0,2q�._�8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  -   $��plotter��   VerticalAxis ?  9Microsoft.Research.DynamicDataDisplay.Charts.VerticalAxis  -	     Name$ yAxis��   HorizontalAxis ?  9Microsoft.Research.DynamicDataDisplay.Charts.DateTimeAxis  -
     Name$ xAxis��3  -Microsoft.Research.DynamicDataDisplay.Plotter	   Children.	 2  ,Microsoft.Research.DynamicDataDisplay.Header  $!��指标历史统计曲线图��=  7Microsoft.Research.DynamicDataDisplay.VerticalAxisTitle  $��	指标值��?	  9Microsoft.Research.DynamicDataDisplay.HorizontalAxisTitle	  $��时间���� -   $��LowerWnd��$��2�����	#FFD2E60C$��0,0,0,2q�._��� $ Vertical=�.+��� -   $��PieLable��$!��评价指标历史饼状图��$��18(�$��33��
  Visifire.Charts.Chart
  -   
 
 Name$
 chart��