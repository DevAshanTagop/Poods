   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   -    'Poods.WindowsFolder.MaterialsBaseWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$V  PПанель управление базами данных материалов��5       � WindowStartupLocation$ CenterScreen=�6B   $	��450��6g   $	��850��6t   $	��850��6�   $	��450��6�   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridMaterials��5         AutoGenerateColumns .  $��10,10,10,114q�6H      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Номер материала��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *IdMaterials+  5      $ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X    67   �� *MaterialName+6X     5      $ Описание��6%    67   �� *Description+  5      $ Стоимость��6%    68   �� *Cost+  5      $ Количество��6%    69   �� *
Quantity+  5      $% Номер поставшика��6%   $ * 6^    6?   �� *
IdProvider+6^   5      �� 5   
   -   5        $��Добавить��5      $��	11,0,0,10q�6G   $��32��6Z   $��Bottom=�6f   $
��Left=�6�   $��93��6�   �� 5   
   -   5        $��Обновить��5      $��
109,0,0,10q�6J   $��32��6^   $��Bottom=�6j   $
��Left=�6�   $��92��6�   �� 5   
   -   5        $��NameTextBox��5   &   $��
109,0,0,47q�6    �� TextWrapping$
 Wrap=�69   $�� ��6M   $��Bottom=�6U   $
��Left=�6p   $��92��6�   $��41��6�   �� 5   
   -   5        $��CostTextBox��5   &   $��
401,0,0,47q�6   $
 Wrap=�69   $�� ��6M   $��Bottom=�6U   $
��Left=�6p   $��93��6�   $��41��6�   �� 5   
   -   5        $��QuantityTextBox��5   &   $��
499,0,0,47q�6   $
 Wrap=�6=   $�� ��6Q   $��Bottom=�6Y   $
��Left=�6t   $��93��6�   $��41��6�   �� 5   
   $
��Left=�6   $��
109,0,0,93q�6/   $
��Wrap=�6C   $��Название��6W   $��Bottom=�6g   $��92��6�   �� 5   
   $
��Left=�6   $��
402,0,0,93q�6/   $
��Wrap=�6C   $��Стоимость��6W   $��92��6h   $��16��6s   $��Bottom=�6    J� RenderTransformOrigin$ 
1.327,-1.5&�6�   �� 5   
   $
��Left=�6   $��
499,0,0,93q�6/   $
��Wrap=�6C   $��Количество��6W   $��Bottom=�6i   $��93��6�   �� 5   
   $
��Left=�6   $��
598,0,0,93q�6/   $
��Wrap=�6C   $��Поставщик��6W   $	��189��6h   $��16��6t   $��Bottom=�6�   �� 5    
   -   5        $��Удалить��5       $
��Left=�6H   $��
206,0,0,10q�6c   $ 0.454,0.102&�6w   $��92��6�   $��32��6�   $��Bottom=�6�   �� 5!   
   -   5        $��IdMatirialCmBx��5!   .   $
��Left=�6   $��	11,0,0,47q�6D   $��93��6W   $��41��6b   $��Bottom=�6n   �� 5"   
   $
��Left=�6   $��	11,0,0,93q�6/   $
��Wrap=�6B   $��Bottom=�6V   $��93��6q   $ 
0.25,0.499&�6|   $��Артикул��6�   �� 5#   
   -	   5        $/��)Перезагрузить таблицу��5#      $
��Left=�6`   $��
303,0,0,10q�6{   $ 0.454,0.102&�6�   $	��143��6�   $��32��6�   $��Bottom=�6�   �� 5$   
   -
   5        $��ProvidersCmBx��5$   .   $
��Left=�6   $��
598,0,0,47q�6C   $	��189��6W   $��41��6c   $��Bottom=�6o   �� 5%   
   -   5        	 ��Name$	 DescriptionTextBox��5%   &   $��
207,0,0,47q�6   $
 Wrap=�6B   $�� ��6V   $��Bottom=�6^   $
��Left=�6y   $	��189��6�   $��41��6�   �� 5&   
   $
��Left=�6   $��
207,0,0,93q�6/   $
��Wrap=�6C   $��Описание��6W   $��Bottom=�6g   $	��189��6�   5'      5(      