   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   -    'Poods.WindowsFolder.CreationOrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$  Создать заказ��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��240��6D   $	��960��6Q   $	��960��6]   $	��240��6l   .��5	      � .+�5   
   �� $&�� Выберите клиента:��6   $
��Bold"�6-   $��	0,10,10,0q�6?   $��14��6R   $	��Top=�6^   $��Right=�6v   $	��310��6�   �� 5   
   -   5         ��Name$ ClientComboBox��5      $	��310��6+   $��	0,31,10,0q�67   $��Right=�6J   $��30��6f   $	��Top=�6r   �� 5   
   -   5        $#��Добавить товары��5      $��Right=�6N   $��0,137,209,0q�6j    J� RenderTransformOrigin$ 0.573,-1.286&�6   $	��111��6�   $��53��6�   $	��Top=�6�   �� 5   
   -   5        $��Создать заказ��5      $��
0,137,10,0q�6K   $	��Top=�6_   $��53��6w   $��Right=�6�   $	��113��6�   $ 
0.312,0.51&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SelectedItemsGrid��5         AutoGenerateColumns .  $��10,10,330,10q�6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
ArticleNum+  5      $ Название��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Y    67   �� *FurnitureName+6Y     5      $ Цена��6%   $	 90 6e    63   �� *Cost+
 �� StringFormat$
 {0} руб.��6e     5      $ Материалы��6%   $	 * 6V    68   �� *	Materials+6V     5      $' !Срок производства��6%    6@   �� *ProductionTime+$
 {0} дней.��5      �� 5   
   -   5        $��finalyCostBox��5      $*��$Итоговая стоимость:��6)    �� TextAlignment$ Right=�6D   $
��Bold"�6Z   $��	0,91,10,0q�6l   $��16��6   $	��Top=�6�   $��Right=�6�   $	��312��6�   �� 5   
   -   5        $��totalProductionTimeBox��5      $ ��Срок поставки:��62   $ Right=�6H   $
��Bold"�6^   $��
0,112,10,0q�6p   $��20��6�   $	��Top=�6�   $ 0.5,0.5&�6�   $��Right=�6�   $	��310��6�   �� 5   
   -   5        $��DeliveryCostTextBox��5   .   $��Right=�6   $��	0,66,10,0q�6I    �� TextWrapping$
 Wrap=�6\   $��0��6p   $	��Top=�6y   $	��132��6�   $��20��6�   6�   �� 5   
   $
��Bold"�6   $��
0,66,147,0q�6&   $��Right=�6:   $	��173��6V   $��20��6b   $	��Top=�6n   $9��3Введите стоимость доставки:��6�   5       5!      