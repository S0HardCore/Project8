   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2 5   	   &    WpfApplication2.AddProductWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Новый предмет��5	   	   $	��450��6   $	��450��6,    � 
ResizeMode$ CanMinimize=�68    � 	Resources 5
       �� 
TargetType �� Property �� Value��%W   '��       �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   66   5      5      .��5      � .+�5   
   �� $��Center=�6   $
��Wrap=�61   $+��%Основная информация��6E   $	��Top=�6`   $��
0, 5, 0, 0q�6x   $��15(�6�   �� 5   
   $��Stretch=�6   $��58��62   $��0q�6>   $	��Top=�6I   �� 5   
   -   5         ��Name$ 	labelName��5      $
��Left=�6'   $
��Wrap=�6B   $��Название:��6V   $	��Top=�6g   $��20, 40, 0, 0q�6   �� 5   
   -   5         ��Name$ textName��5      $
��Left=�6$   $	��Top=�6?   $	��120��6W   $��100, 38, 0, 0q�6c   6|   �� 5   
   -   5        $ labelDescription��5      $
��Left=�6.   $
��Wrap=�6I   $��Описание:��6]   $	��Top=�6n   $��20, 80, 0, 0q�6�   �� 5   
   -   5        $ textDescription��5      $
��Left=�6+   $	��Top=�6F    �� TextWrapping$
 Wrap=�6^   $	��250��6r   $��70��6~   $��100, 78, 0, 0q�6�   6�   �� 5   
   -   5        $ labelId��5      $
��Left=�6%   $
��Wrap=�6@   $��Номер:��6T   $	��Top=�6b   $��20, 160, 0, 0q�6z   �� 5   
   -   5        $ textId��5      $
��Left=�6"   $	��Top=�6=   $
 Wrap=�6U   $��30��6i   $��20��6t   $��100, 158, 0, 0q�6�   6�   �� 5   
   $��Center=�6   $
��Wrap=�61   $5��/Дополнительные параметры��6E   $��Center=�6e   $��0, 0, 0, 15q�6�   $��15(�6�   �� 5   
   $��Stretch=�6   $��58��62   $��0, 15, 0, 0q�6>   $��Center=�6S   �� 5   
   $��Stretch=�6   $��58��62   $��0, 0, 0, 40q�6>   $��Center=�6S   �� 5   
   $��Center=�6   $��16(�6/   $��25, 60, 0, 0q�6=   1.6W   �� 5   
   -   5        $ 	textProp0��5      $��Center=�6%   $��Center=�6B   $	��105��6]   $��20, 60, 0, 0q�6i   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Имя параметра��6   6�   �� 5   
   -   5        
 ��Name$
 comboBox��5      $
��Left=�6%   $��Center=�6@   $	��120��6[   $��45, 60, 0, 0q�6g   $	 Тип параметра��6}   .@�5      �� 
Текст6   �� 5      
Число6   �� 5       Изображение6%   5!      �� 5"   
   -	   5        $ 
textValue0��5"      $��Center=�6&   $��Center=�6C   $	��120��6^   $��280, 60, 0, 0q�6j   $	 Значение��6�   6�   �� 5#   
   -
   5         ��Name$ 	buttonAdd��5#      $��Добавить��6$   $��Center=�67   $��Bottom=�6T   $��75��6o   $��-175, 0, 0, 15q�6z   �� 5$   
   -   5        $ buttonCancel��5$      $��Отмена��6'   $��Center=�68   $��Bottom=�6U   $��75��6p   $��175, 0, 0, 15q�6{   �� 5%   
   -   5        $ addProp��5%      $!��Новый параметр��6"   $��Center=�6;   $��Center=�6X   $	��110��6s   $��0, 150, 0, 0q�6   5&      5'      