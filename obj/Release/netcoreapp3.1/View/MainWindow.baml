   M S B A M L   `   `   `  ���� B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project.ViewProject.View  +clr-namespace:Project.ViewProject.View      Project.View.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  &localclr-namespace:Project.View  4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  'local1clr-namespace:Project.View    � Title$  Главное окно��$	��450��$	��800��$��Regular"�$��16(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�   MaterialDesignPaper#���     MaterialDesignFont#���    MaterialDesignBody#���   � WindowStartupLocation$ CenterScreen=� � Icon$ /View/2.png�� � 	Resources   StyleTwo �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value5  /System.Windows.Controls.DataGridLengthConverter  
StyleThree��%T  &	       &	 �     �� "  .���  � ��$ Stretch=���  � ��$ Stretch=���  �@ ColumnHeaderHeight$ 40Q���  �@ ColumnWidth$ * ��  � ��$	 0.5q���  � ��
 �������  � �� �#FAFAFA�� " ��.���  � ��$ 50����  � ��$ 15q���  � ��$	 5,1q���  � ��
 ���� .��� ���#EFEFEF	 � RowDefinitions	 �� $��* ��� $��50 �.+�,  &MahApps.Metro.Controls.MetroTabControl  -   $��TabControl1��#���  $��Center=�$��Center=����#E8E8E8$��10q�
 �� TabStripPlacement$

 Left=�$��0�� �� SelectedItem �� *SelectedTab+.@��� -   $��BankTab��
���   �#���   � ContextMenu �� .@�m� $ ��Редактировать��m� $��Удалить�� m� Command �� *
DeleteItem+���� $��
Банки��.��  -     Name$ BankDataGrid��$��10q�$��1q�   
IsReadOnly$
 True��   AutoGenerateColumns$ False��   SelectionUnit$ FullRow=�   SelectionMode$ Single=����� *Banks+ �� UpdateSourceTrigger$ PropertyChanged=� �� *SelectedBank+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$	 350 -   NameFull��   Header$ Полное имя��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ NameFull�  -   	NameShort��$ Короткое имя�� �� $ 	NameShort�  -   Inn��$ Инн�� �� $	 Inn�  -   Bik��$ Бик�� �� $	 Bik�  -   
KorAccount��$ Корсчет�� �� $ 
KorAccount�  -	   AccountNumber��$$ Номер банк.счета�� �� $ AccounNumber�  -
   City��$ 
Город�� �� $
 City��� -   $��AccountTypeTab��
���   �#���   �� .@�m� $ ��Редактировать��m� $��Удалить�� �� *
DeleteItem+���� $��Типы��.��  -   $ DataGridAccountTypes��$��10q�$��1q�$
 True��$ False��$ FullRow=�$ Single=� �� *SelectedType+���� *AccountTypes+$ PropertyChanged=�   $	 350 -   Type��$ Тип�� �� *Type+�� -   $��AggrementTab��
���   �#���   �� .@�m� $ ��Редактировать��m� $��Удалить�� �� *
DeleteItem+���� $��Договора��.��  -   $��AggrementDataGrid��$��10q�$��1q�$ False�� �� *SelectedAggrement+���� *
Aggrements+   -   
Number��$ 
Номер�� �� $ Number�  -   DataOpen��$# Дата заключения�� �� $ DateOpen�  -   	DataClose��$ Дата закрытия�� �� $ 	DataClose�  -   	Notes��$ Заметки�� �� $ Notes��� -   $��
AccountTab��
���   �#���   �� .@�m� $ ��Редактировать��m� $��Удалить�� �� *
DeleteItem+���� $��
Счета��.��  -   $��AccountGrid��$��1q�$��10q�$ False�� �� *SelectedAccount+���� *
Accounts+$ PropertyChanged=�   -   
TypeID��$ Тип счета�� �� $ AccountAccountType.Type�  -   
BankID��$ Банк�� �� $ AccountBank.NameShort�  -   AggrementID��$ Договор�� �� $ AccountAggrement.Number�  -   AccountNumber2��$8 2Номер ивестиционного счета�� �� $ AccountNumber��� �� -   $��	AddButton��$��30�����#EFEFF1
���   �$��Добавить��$��Right=�$��	0,0,320,0q�$��1��$��Center=�$	��125������ *	AddItem+�� -   $��DeleteButton��$��30�����#EFEFF1
���   �$��Удалить��$��Right=�$��	0,0,185,0q�$��1��$��Center=�$	��125������ *
DeleteItem+�� -   $��
EditButton��$��30�����#EFEFF1
���   �$��Изменить��$��Right=�$��0,0,50,0q�$��1��$��Center=�$	��125�� J� RenderTransformOrigin$ 0.446,-0.22&����� *
EditITem+