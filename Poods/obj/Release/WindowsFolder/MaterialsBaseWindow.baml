   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  -    'Poods.WindowsFolder.MaterialsBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$V  PПанель управление базами данных материалов�� � WindowStartupLocation$ CenterScreen=�$	��450��$	��850��$	��850��$	��450��.��� .+�&   System.Windows.Controls.DataGrid  -   $��DataGridMaterials��   AutoGenerateColumns .  $��10,10,10,114q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$# Номер материала��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *IdMaterials+  $ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *MaterialName+  $ Описание�� �� *Description+  $ Стоимость�� �� *Cost+  $ Количество�� �� *
Quantity+  $% Номер поставшика��$ *  �� *
IdProvider+�� -   $��Добавить��$��	11,0,0,10q�$��32��$��Bottom=�$
��Left=�$��93���� -   $��Обновить��$��
109,0,0,10q�$��32��$��Bottom=�$
��Left=�$��92���� -   $��NameTextBox��$��
109,0,0,47q� �� TextWrapping$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��CostTextBox��$��
401,0,0,47q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� -   $��QuantityTextBox��$��
499,0,0,47q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� $
��Left=�$��
109,0,0,93q�$
��Wrap=�$��Название��$��Bottom=�$��92���� $
��Left=�$��
402,0,0,93q�$
��Wrap=�$��Стоимость��$��92��$��16��$��Bottom=� J� RenderTransformOrigin$ 
1.327,-1.5&��� $
��Left=�$��
499,0,0,93q�$
��Wrap=�$��Количество��$��Bottom=�$��93���� $
��Left=�$��
598,0,0,93q�$
��Wrap=�$��Поставщик��$	��189��$��16��$��Bottom=��� -   $��Удалить��$
��Left=�$��
206,0,0,10q�$ 0.454,0.102&�$��92��$��32��$��Bottom=��� -   $��IdMatirialCmBx��$
��Left=�$��	11,0,0,47q�$��93��$��41��$��Bottom=��� $
��Left=�$��	11,0,0,93q�$
��Wrap=�$��Bottom=�$��93��$ 
0.25,0.499&�$��Артикул���� -	   $/��)Перезагрузить таблицу��$
��Left=�$��
303,0,0,10q�$ 0.454,0.102&�$	��143��$��32��$��Bottom=��� -
   $��ProvidersCmBx��$
��Left=�$��
598,0,0,47q�$	��189��$��41��$��Bottom=��� -   	 ��Name$	 DescriptionTextBox��$��
207,0,0,47q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$	��189��$��41���� $
��Left=�$��
207,0,0,93q�$
��Wrap=�$��Описание��$��Bottom=�$	��189��