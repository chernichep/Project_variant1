   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  5   	   +clr-namespace:Project.ViewProject.View  5	   R       Project.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   &localclr-namespace:Project.View  5   	   4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   'local1clr-namespace:Project.View  6R     � Title$  Главное окно��5   	   $	��450��5   	   $	��800��5   	   $��Regular"�5   	   $��16(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5         MaterialDesignPaper#���   5        MaterialDesignFont#���  5        MaterialDesignBody#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ /View/2.png��5   	    � 	Resources 5        StyleTwo �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value5  /System.Windows.Controls.DataGridLengthConverter  
StyleThree��%  &	       &	 Q    �� 5   
   "  6!   .�5      ��  � ��$ Stretch=�6;   �� 5       � ��$ Stretch=�64   �� 5       �@ ColumnHeaderHeight$ 40Q�63   �� 5       �@ ColumnWidth$ * 6,   �� 5       � ��$	 0.5q�60   �� 5       � ��
 �����6,   �� 5       � �� �#FAFAFA6+   5       �� 5!   
   " ��6#   .�5"      ��  � ��$ 50��6'   �� 5#       � ��$ 15q�6(   �� 5$       � ��$	 5,1q�6'   �� 5%       � ��
 ���� 6,   5&      5'      .��5)      � ���#EFEFEF	 � RowDefinitions	 5+   
   �� 5,      $��* �6   �� 5-      $��50 �6   .+�50   
   ,  &MahApps.Metro.Controls.MetroTabControl  -   5        $��TabControl1��56   W   #���  52      $��Center=�53      $��Center=�54      ���#E8E8E8$��10q�56      
 �� TabStripPlacement$

 Left=�6   $��0��6j    �� SelectedItem 62   �� *SelectedTab+.@�57      �� -   5        $��BankTab��59   6   
���   �#���  6    � ContextMenu 5;      �� 5<      .@�5=      m� $ ��Редактировать��6#   m� 5>      $��Удалить��6#    m� Command 64   �� *
DeleteItem+5?      ��5A      �� 5B      $��
Банки��6    .��5D        -   5          Name$ BankDataGrid��5F      $��10q�5D      $��1q�5E         
IsReadOnly$
 True��5G         AutoGenerateColumns$ False��5H         SelectionUnit$ FullRow=�5K         SelectionMode$ Single=�5L      ��5I      �� *Banks+ �� UpdateSourceTrigger$ PropertyChanged=� 5J      �� *SelectedBank+   Columns 5M      0  *System.Windows.Controls.DataGridTextColumn  5N      ,  &System.Windows.Controls.DataGridColumn   Width$	 350 6O   -   5        NameFull��   Header$ Полное имя��5N   m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   ��  �� Path$ NameFull�6m     5O      -   5        	NameShort��$ Короткое имя��5O   c    6-   �� $ 	NameShort�6c     5P      -   5        Inn��$ Инн��5P   W    6-   �� $	 Inn�6W     5Q      -   5        Bik��$ Бик��5Q   W    6-   �� $	 Bik�6W     5R      -   5        
KorAccount��$ Корсчет��5R   e    6-   �� $ 
KorAccount�6e     5S      -	   5        AccountNumber��$$ Номер банк.счета��5S   j    6-   �� $ AccounNumber�6j     5T      -
   5        City��$ 
Город��5T   Y    6-   �� $
 City�6Y   5W      5X      �� 5Y      -   5        $��AccountTypeTab��5\      
���   �#���  5[       5]      �� 5^      .@�5_      m� $ ��Редактировать��6#   m� 5`      $��Удалить��6#    64   �� *
DeleteItem+5a      ��5c      �� 5d      $��Типы��6    .��5f        -   5        $ DataGridAccountTypes��5j      $��10q�5f      $��1q�5g      $
 True��5h      $ False��5i      $ FullRow=�5k      $ Single=�5l       5j   3   �� *SelectedType+��6Y   �� *AccountTypes+$ PropertyChanged=� 5m        5n      $	 350 6F   -   5        Type��$ Тип��5n   `    6-   �� *Type+6`   5r      5t      �� 5u      -   5        $��AggrementTab��5w      
���   �#���  6%    5x      �� 5y      .@�5z      m� $ ��Редактировать��6#   m� 5{      $��Удалить��6#    64   �� *
DeleteItem+5|      ��5~      �� 5      $��Договора��6    .��5�        -   5        $��AggrementDataGrid��5�      $��10q�5�      $��1q�5�      $ False��5�   /    5�      �� *SelectedAggrement+��5�   K   �� *
Aggrements+ 5�        5�      -   5        
Number��$ 
Номер��5�   ]    6-   �� $ Number�6]     5�      -   5        DataOpen��$# Дата заключения��5�   a    6-   �� $ DateOpen�6a     5�      -   5        	DataClose��$ Дата закрытия��5�   c    6-   �� $ 	DataClose�6c     5�      -   5        	Notes��$ Заметки��5�   [    6-   �� $ Notes�6[   5�      5�      �� 5�      -   5        $��
AccountTab��5�      
���   �#���  5�       5�      �� 5�      .@�5�      m� $ ��Редактировать��6#   m� 5�      $��Удалить��6#    64   �� *
DeleteItem+5�      ��5�      �� 5�      $��
Счета��6    .��5�        -   5        $��AccountGrid��5�      $��1q�5�      $��10q�5�      $ False��5�   [    5�      �� *SelectedAccount+��5�      �� *
Accounts+$ PropertyChanged=� 5�        5�      -   5        
TypeID��$ Тип счета��5�   n    6-   �� $ AccountAccountType.Type�6n     5�      -   5        
BankID��$ Банк��5�   l    6-   �� $ AccountBank.NameShort�6l     5�      -   5        AggrementID��$ Договор��5�   s    6-   �� $ AccountAggrement.Number�6s     5�      -   5        AccountNumber2��$8 2Номер ивестиционного счета��5�   l    6-   �� $ AccountNumber�6l   5�      5�      �� 5�      5�      �� 5�   
   -   5        $��	AddButton��5�      $��30��5�      ���#EFEFF1
���   �$��Добавить��5�      $��Right=�5�      $��	0,0,320,0q�5�      $��1��6    $��Center=�5�      $	��125��5�      ��5�      �� *	AddItem+5�      �� 5�   
   -   5        $��DeleteButton��5�      $��30��5�      ���#EFEFF1
���   �$��Удалить��5�   !   $��Right=�5�      $��	0,0,185,0q�6)   $��1��5�      $��Center=�6   $	��125��5�      ��5�      �� *
DeleteItem+5�      �� 5�   
   -   5        $��
EditButton��5�      $��30��5�      ���#EFEFF1
���   �$��Изменить��5�      $��Right=�5�      $��0,0,50,0q�5�      $��1��6   $��Center=�5�      $	��125��5�       J� RenderTransformOrigin$ 0.446,-0.22&�62   ��5�      �� *
EditITem+5�   2   5�      5�      