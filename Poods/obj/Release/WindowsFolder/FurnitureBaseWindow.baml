   M S B A M L   `   `   `  ���� @  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  -    'Poods.WindowsFolder.FurnitureBaseWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Poods.WindowsFolder       � Title$N  HПанель управление базами данных мебели�� � WindowStartupLocation$ CenterScreen=�$	��450��$	��850��$	��850��$	��450��.��� .+�&   System.Windows.Controls.DataGrid  -   $��DataGridFurniture��   AutoGenerateColumns .  $��10,10,10,115q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ArticleNum+  $ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *FurnitureName+  $ Стоимость�� �� *Cost+  $! Время создания�� �� *ProductionTime+  $ Номер смены�� �� *ShiftNumber+  $ Материалы��$ *  �� *MaterialsList+�� -   $��Добавить��$��
146,0,0,10q�$��33��$��Bottom=�$
��Left=�$��92���� -   $��Обновить��$��
244,0,0,10q�$��33��$��Bottom=�$
��Left=�$��92���� -   $��NameTextBox��$��
108,0,0,48q� �� TextWrapping$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��92��$��41���� -   $��CostTextBox��$��
204,0,0,48q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� -   $��ProductionTimeTextBox��$��
302,0,0,48q�$
 Wrap=�$�� ��$��Bottom=�$
��Left=�$��93��$��41���� $
��Left=�$��
108,0,0,94q�$
��Wrap=�$��Название��$��Bottom=�$��92���� $
��Left=�$��
205,0,0,94q�$
��Wrap=�$��Стоимость��$��92��$��16��$��Bottom=� J� RenderTransformOrigin$ 
1.327,-1.5&��� $
��Left=�$��
302,0,0,94q�$
��Wrap=�$!��Время создания��$��Bottom=�$��93���� $
��Left=�$��
401,0,0,94q�$
��Wrap=�$��Номер смены��$��92��$��16��$��Bottom=��� -   $��Удалить��$
��Left=�$��
340,0,0,10q�$ 0.454,0.102&�$��92��$��33��$��Bottom=��� -   $��ArticleNumCmBx��$
��Left=�$��	10,0,0,48q�$��93��$��41��$��Bottom=��� $
��Left=�$��	10,0,0,94q�$
��Wrap=�$��Bottom=�$��93��$ 
0.25,0.499&�$��Артикул���� -	   $/��)Перезагрузить таблицу��$
��Left=�$��
438,0,0,10q�$ 0.454,0.102&�$	��140��$��33��$��Bottom=��� -
   $��ShiftNumberCmBx��$
��Left=�$��
400,0,0,48q�$��93��$��41��$��Bottom=��� -   $'��!Выбрать материалы��$��	10,0,0,10q�$��33��$��Bottom=�$
��Left=�$	��131��