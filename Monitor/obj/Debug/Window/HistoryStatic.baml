   M S B A M L   `   `   `  ����B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor  5      Y UWPFVisifire.Charts, Version=5.1.2.0, Culture=neutral, PublicKeyToken=0cd785983078370bM9clr-namespace:Visifire.Charts;assembly=WPFVisifire.ChartsVisifire.Charts 5          Monitor.HistoryStatic   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Monitor     5      Nvisifire9clr-namespace:Visifire.Charts;assembly=WPFVisifire.Charts     5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47Toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      Y UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f=d34http://research.microsoft.com/DynamicDataDisplay/1.0  5	      -   5        .��5      �   � RowDefinitions  5   
   �� 5      $	��20* �6   �� 5      $
��152* �6   �� 5      $
��111* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $
��Left=�6;   .+�5      �� -   5        $��preSelectIndex��5      $
��Left=�6-   $	��103��6H   $��32��6T   $	��Top=�6`   $��Center=�6x   $��	0,0,0,-11q�6�   �� 5      $��温度��6   $��Center=�6!   $��Center=�6E   $��32��6g   $	��Top=�6s   $��	0,0,0,-11q�6�   $��15(�6�   $
��Bold"�6�   6�   �� 5      -   5        $��TControl��5      $	��333��6&   $��Center=�61   $��Center=�6U   $��32��6w   $	��Top=�6�   $��	0,0,0,-11q�6�   $��56��6�   $��15(�6�   6�   �� 5      $��K��6   $��Center=�6    $��Center=�6D   $��32��6f   $	��Top=�6r   $��	0,0,0,-11q�6�   $��15(�6�   $
��Bold"�6�   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5      -   5        $��	startTime��5   X   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6%      FormatString$ yyyy/MM/dd HH:mm:ss��65   $
��Left=�6j   $	��177��6�   $��32��6�   $	��Top=�6�   $��	0,0,0,-11q�6�   6�   �� 5      $	��至��6   $��Center=�6!   $��Center=�6C   $��32��6h   $	��Top=�6t   $
��Left=�6�   $��42��6�   $��15(�6�   $
��Bold"�6�   6�     5      -   5        $��endTime��5   %   $ Custom=�64   $ yyyy/MM/dd HH:mm:ss��6D   $
��Left=�6h   $	��153��6�   $��32��6�   $	��Top=�6�   6�   �� 5      -   5        $
��Left=�5      $��53��61   $��32��6<   $	��Top=�6H   
����·�$��15(�6�   $
��Bold"�6�   .��6�   查询6�   �� 5      -   5           ButtonStyle2#��[  5      $
��Left=�6<   $��32��6W   $��32��6b   $	��Top=�6n    � Cursor$
 Hand��6�   5      5      �� 5   
   $��1��6   ���	#FFD2E60C$��0,0,0,2q�66   ._�5      8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  -   5        $��plotter��5         VerticalAxis 5       ?  9Microsoft.Research.DynamicDataDisplay.Charts.VerticalAxis  5!      -	   5          Name$ yAxis��5!   &      HorizontalAxis 5$      ?  9Microsoft.Research.DynamicDataDisplay.Charts.DateTimeAxis  5%      -
   5          Name$ xAxis��5%   &   3  -Microsoft.Research.DynamicDataDisplay.Plotter	   Children.	 5(      2  ,Microsoft.Research.DynamicDataDisplay.Header  $!��指标历史统计曲线图��6   =  7Microsoft.Research.DynamicDataDisplay.VerticalAxisTitle  5)      $��	指标值��6'   ?	  9Microsoft.Research.DynamicDataDisplay.HorizontalAxisTitle	  5*      $��时间��6)   68   5+      5,      �� 5-   
   -   5        $��LowerWnd��5-      $��2��6   ���	#FFD2E60C$��0,0,0,2q�6F   ._�5.      �� $ Vertical=�6   .+�5/      �� -   5        $��PieLable��5/   F   $!��评价指标历史饼状图��6   $��18(�6,   $��33��6:   6X   
  Visifire.Charts.Chart
  50      -   5        
 
 Name$
 chart��50   !   63   51      52      53      54      