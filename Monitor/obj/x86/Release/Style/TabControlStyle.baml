   M S B A M L   `   `   `  ���� B  >Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MonitorMonitor  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TabControlStyle  �� 
TargetType �� Property �� Value  TabControlNormalBorderBrush �� 
TargetType J� SnapsToDevicePixels-   'System.Windows.Input.KeyboardNavigation    TabNavigation � ColumnDefinitions ��Name ��Name	    DirectionalNavigation
    TabIndex ��Name ��Name K� IsItemsHost �� EndPoint �� 
StartPoint � Color � Offset �� Triggers P� Property P� Value  listTabItemStyle  TabItemFocusVisual  ButtonNormalBackground ��Name F�Name �� Stretch J� RenderTransformOrigin �� Angle ��Name ]� 
Conditions �� Property �� Value �� 
TargetName 
� RadiusX  
� RadiusY  TabItemDisabledBackground  TabItemDisabledBorderBrush  
background  TabControlStyle13  -System.Windows.Media.Effects.DropShadowEffect! � RowDefinitions" ��Name# �� CornerRadius$ ��Name% K� ZIndex& �� Color 	 TabItemHotBackground 
 TabItemSelectedBackground  TabItemHotBorderBrush' �� Padding( �� RelativeSource) �� AncestorType* !� Visual�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     localclr-namespace:Monitor  %*  &	        7  &	 �    7  7  7  7  7  &	 +    &	 w    7  &	 /
    &	 F
    &		 ]
    &	
 t
    &	 �
    &	 �
    &	 �
    '�� �
    7  7  7 	 7  7  7  �� "  ��.���  � ��# � ����  � ��$ 4,4,4,4q���  � ��$ 1q���  � ��8   ��  � �� �#F9F9F9��  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� }�.  . $ Local=� �� $ ColumnDefinition0��$��0.192* ��� $ ColumnDefinition1��$��0.808* �.+��� $ ContentPanel��#��z��#��z��#��z��$��1��$	 	Contained=�$��0��$
 2��$ Local=�$��1��$��1��$
��Auto��$��0q�._��� $ PART_SelectedContentHost��$��SelectedContent��# z $
��Auto��$��0q��� $ HeaderPanel��$��0q� . ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#7AFFFFFF��$ 0Q�� $ 	#42F0FCFF��$ 1Q� P�  � {� .  . ��� # � �� � ���� "  ��.���  �@�FocusVisualStyle8   ��  � ��
 �   ���  � ��$ 6,1,6,1q���  � ��8  ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R��  . $��0q�.+��� $ Bd��$��0q���Z� ._��� $ 	textBlock��$��Stretch=�$��58.75,0,0,0q�$
��Wrap=�$��Center=�#��z��F� $
 path��'����?�5    р<k
�}����ɀ<���}�	
�������$
��Auto��$��0,9.667,-1.583,9.667q�$
 Fill=�$��0��$��11.466��$ 0.5,0.5&�$��Stretch=�$��Right=�$y�Hidden=�z�V� .~��� �� �� $	 -90Q�T� �� $ 	rectangle��$��27,2.25,0,2.75q�$��0��$
��Left=�$��22.25��#��z�� ]�  ��  �@J�IsMouseOver . ��  �@��
IsSelected .  ./��� $ Bd�� �@��CornerRadius$ 3���� $ Bd�� � �� �	#562C94AF�� $ Bd�� � ��$ 1q��� $ Bd�� � ��$ 1q��� $ Bd�� � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#2690D9FF��$ 1Q�� $ 	#47FFFFFF��$ 0Q�P�  �@��
IsSelected . . ���  �@K�ZIndex$ 1���� $ Bd�� � �� 
� $ 0.641Q�$  1.243Q�.��� $ 	#FF6D9EC4��$ 1Q�� $ 	#FFD4E0EB��$ 0Q��� $
 path�� � y�$ Visible=��� $ 	textBlock�� � ��
 �����P�  � {� .  . ��� $ Bd��8   � ���� $ Bd��8   � ���� # � �� � ���� $ 0.5,1&�$ 0.5,0&�.��� $ #d6c79b��$ 1Q�� $ White���� "  ��.���  �@J�Effect   ��  � �� �� " ��.R�� }�.  . $ Local=�! �� $" RowDefinition0��$
��Auto ��� $" RowDefinition1��$��* �.+��� $��0��$# 7,7,0,0��8��  ._��� $$ HeaderPanel�� . $��2,2,2,0q�$
 1��$% 1���� $ ContentPanel��$��1��#��z��#��z��#��z��$	 	Contained=�$
 2��$ Local=�._��� $ PART_SelectedContentHost��$��SelectedContent��#��z��# z �� $& Transparent���� $& Transparent���� $& Transparent���� $& Transparent���� $& Transparent���� $& Transparent���� $& Transparent���� "  ��.���  � ��
 �   ���  � ��$ 6,1,6,1q���  � ��8   ��  � ��8  ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R��  . $��5q�.+��� $ Bd��#��z��$��1,1,1,0q�#��z��$' 
10,5,10,15q�._��� $ Content��$��Header����. # z ���� *HorizontalContentAlignment+( �� ") ������ *VerticalContentAlignment+( �� ") �� P�  �@J�IsMouseOver . . ��� $ Bd��8   � ��P�  �@��
IsSelected . . ���  �@K�ZIndex$ 1����  � ��
 �  ���� $ Bd�� � �� !� * �� $��background1.png��]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver . ./��� $ Bd��8   � ��P�  �@��TabStripPlacement$ Bottom=�. ��� $ Bd�� � ��$ 1,0,1,1q�P�  �@��TabStripPlacement$
 Left=�. ��� $ Bd�� � ��$ 1,1,0,1q�P�  �@��TabStripPlacement$ Right=�. ��� $ Bd�� � ��$ 0,1,1,1q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$	 Top=�./���  � ��$ -2,-2,-2,-1q��� $ Content�� � ��$ 0,0,0,1q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Bottom=�./���  � ��$ -2,-1,-2,-2q��� $ Content�� � ��$ 0,1,0,0q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$
 Left=�./���  � ��$ -2,-2,-1,-2q��� $ Content�� � ��$ 0,0,1,0q�]�  ��  �@��
IsSelected . ��  �@��TabStripPlacement$ Right=�./���  � ��$ -1,-2,-2,-2q��� $ Content�� � ��$ 1,0,0,0q�P�  � {� .  . ��� $ Bd��8   � ���� $ Bd��8   � ���� # � �� � ��