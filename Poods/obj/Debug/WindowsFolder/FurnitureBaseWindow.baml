   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   -    'Poods.WindowsFolder.FurnitureBaseWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$N  HПанель управление базами данных мебели��5       � WindowStartupLocation$ CenterScreen=�6;   $	��450��6`   $	��850��6m   $	��850��6y   $	��450��6�   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridFurniture��5         AutoGenerateColumns .  $��10,10,10,115q�6H      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
ArticleNum+  5      $ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y    67   �� *FurnitureName+6Y     5      $ Стоимость��6%    68   �� *Cost+  5      $! Время создания��6%    6=   �� *ProductionTime+  5      $ Номер смены��6%    6:   �� *ShiftNumber+  5      $ Материалы��6%   $ * 6Z    68   �� *MaterialsList+6Z   5      �� 5   
   -   5        $��Добавить��5      $��
146,0,0,10q�6G   $��33��6[   $��Bottom=�6g   $
��Left=�6�   $��92��6�   �� 5   
   -   5        $��Обновить��5      $��
244,0,0,10q�6J   $��33��6^   $��Bottom=�6j   $
��Left=�6�   $��92��6�   �� 5   
   -   5        $��NameTextBox��5   &   $��
108,0,0,48q�6    �� TextWrapping$
 Wrap=�69   $�� ��6M   $��Bottom=�6U   $
��Left=�6p   $��92��6�   $��41��6�   �� 5   
   -   5        $��CostTextBox��5   &   $��
204,0,0,48q�6   $
 Wrap=�69   $�� ��6M   $��Bottom=�6U   $
��Left=�6p   $��93��6�   $��41��6�   �� 5   
   -   5        $��ProductionTimeTextBox��5   &   $��
302,0,0,48q�6   $
 Wrap=�6C   $�� ��6W   $��Bottom=�6_   $
��Left=�6z   $��93��6�   $��41��6�   �� 5   
   $
��Left=�6   $��
108,0,0,94q�6/   $
��Wrap=�6C   $��Название��6W   $��Bottom=�6g   $��92��6�   �� 5   
   $
��Left=�6   $��
205,0,0,94q�6/   $
��Wrap=�6C   $��Стоимость��6W   $��92��6h   $��16��6s   $��Bottom=�6    J� RenderTransformOrigin$ 
1.327,-1.5&�6�   �� 5   
   $
��Left=�6   $��
302,0,0,94q�6/   $
��Wrap=�6C   $!��Время создания��6W   $��Bottom=�6m   $��93��6�   �� 5   
   $
��Left=�6   $��
401,0,0,94q�6/   $
��Wrap=�6C   $��Номер смены��6W   $��92��6j   $��16��6u   $��Bottom=�6�   �� 5    
   -   5        $��Удалить��5       $
��Left=�6H   $��
340,0,0,10q�6c   $ 0.454,0.102&�6w   $��92��6�   $��33��6�   $��Bottom=�6�   �� 5!   
   -   5        $��ArticleNumCmBx��5!   .   $
��Left=�6   $��	10,0,0,48q�6D   $��93��6W   $��41��6b   $��Bottom=�6n   �� 5"   
   $
��Left=�6   $��	10,0,0,94q�6/   $
��Wrap=�6B   $��Bottom=�6V   $��93��6q   $ 
0.25,0.499&�6|   $��Артикул��6�   �� 5#   
   -	   5        $/��)Перезагрузить таблицу��5#      $
��Left=�6`   $��
438,0,0,10q�6{   $ 0.454,0.102&�6�   $	��140��6�   $��33��6�   $��Bottom=�6�   �� 5$   
   -
   5        $��ShiftNumberCmBx��5$   .   $
��Left=�6   $��
400,0,0,48q�6E   $��93��6Y   $��41��6d   $��Bottom=�6p   �� 5%   
   -   5        $'��!Выбрать материалы��5%      $��	10,0,0,10q�6S   $��33��6f   $��Bottom=�6r   $
��Left=�6�   $	��131��6�   5&      5'      