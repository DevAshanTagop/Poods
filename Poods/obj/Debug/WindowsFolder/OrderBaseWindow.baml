   M S B A M L   `   `   `  ����@  <Poods, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Poods.WindowsFolderPoods.WindowsFolder  5   	   )    #Poods.WindowsFolder.OrderBaseWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Poods.WindowsFolder     5   	     � Title$P  JПанель управление базами данных заказов��5   	    � WindowStartupLocation$ CenterScreen=�69   $	��450��6^   $
��1100��6k   $
��1100��6x   $	��450��6�   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridOrder��5         AutoGenerateColumns .  $��10,10,10,115q�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Номер ID заказа��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	IdOrder+  5      $ Номер заказа��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[    6;   �� *OrderNumber+6[     5      $ Дата заказа��6%    6:   �� *	DateOrder+  5      $# Дата завершения��6%    6>   �� *CompletionDate+  5      $ Статус оплаты��6%    6<   �� *Paid+  5      $ Статус заказа��6%    6<   �� *Status+  5      $/ )Отвественый сотрудник��6%    6D   �� *	StaffInfo+  5      $" Номер ID клиента��6%    6?   �� *
IdClient+  5      $% Полная стоимость��6%    6?   �� *	TotalCost+  5      $ Состав заказа��6%   $ * 6Z    6<   �� *	Structure+6Z   5      �� 5   
   -   5        $��Обновить��5      $��
144,0,0,10q�6F   $��33��6Z   $��Bottom=�6f   $
��Left=�6�   $��92��6�   �� 5   
   $
��Left=�6   $��
107,0,0,94q�6/   $
��Wrap=�6C   $��Bottom=�6W   $	��189��6r   $��Статус оплаты��6~   �� 5   
   -   5        $��Удалить��5      $
��Left=�6D   $��
241,0,0,10q�6_    J� RenderTransformOrigin$ 0.454,0.102&�6s   $��92��6�   $��33��6�   $��Bottom=�6�   �� 5   
   -   5        $��ComboBoxIdOrder��5   .   $
��Left=�6   $��	10,0,0,48q�6E   $��92��6X   $��41��6c   $��Bottom=�6o   �� 5   
   $
��Left=�6   $��	10,0,0,94q�6/   $
��Wrap=�6B   $ ��Номер ID заказа��6V   $��Bottom=�6m   $��92��6�   $ 0.282,0.624&�6�   �� 5    
   -   5        $��ComboBoxPaidStatus��5    .   $
��Left=�6   $��
107,0,0,48q�6I   $	��189��6]   $��41��6i   $��Bottom=�6u   �� 5!   
   -   5        $��ComboBoxStatusOfOrder��5!   .   $
��Left=�6   $��
301,0,0,48q�6K   $	��185��6_   $��41��6k   $��Bottom=�6w   �� 5"   
   $
��Left=�6   $��
301,0,0,94q�6/   $
��Wrap=�6C   $	��185��6W   $��16��6c   $��Bottom=�6o   $��Статус заказа��6�   �� 5#   
   -   5        $/��)Перезагрузить таблицу��5#      $
��Left=�6R   $��
338,0,0,10q�6m   $ 0.454,0.102&�6�   $	��137��6�   $��33��6�   $��Bottom=�6�   �� 5$   
   -   5        $#��Добавить мебель��5$      $��	10,0,0,10q�6W   $��33��6j   $��Bottom=�6v   $
��Left=�6�   $	��129��6�   5%      5&      